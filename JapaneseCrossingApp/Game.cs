namespace JapaneseCrossingApp
{
	public class Game
	{
		private SideKind? _targetSide;

		public Game()
		{
			Passengers = CreatePassengers();

			LeftSide = new RiverSide(SideKind.Left);
			RightSide = new RiverSide(SideKind.Right);

			LeftSide.AddRange(Passengers);

			Boat = new Boat(
				GameConstants.BoatLeftX,
				GameConstants.BoatY);
		}

		public RiverSide LeftSide { get; }

		public RiverSide RightSide { get; }

		public Boat Boat { get; }

		public List<Person> Passengers { get; }

		public int MoveCount { get; private set; }

		public SideKind ActiveSide =>
			Boat.IsOnLeftSide
				? SideKind.Left
				: SideKind.Right;

		public bool IsAnimationRunning { get; private set; }

		public bool IsSuccess =>
			LeftSide.Passengers.Count == 0 &&
			Boat.Passengers.Count == 0;

		public void Embark(Person person)
		{
			if (IsAnimationRunning)
				return;

			if (person.InBoat)
				return;

			var personSide = GetSideByPerson(person);

			if (personSide != ActiveSide)
			{
				throw new InvalidOperationException(
					"Персонаж находится на другом берегу");
			}

			if (!Boat.TryEmbark(
					person,
					out var seatPosition,
					out var seat))
			{
				throw new InvalidOperationException(
					"В лодке нет больше места");
			}

			person.MoveToBoatSeat(seatPosition, seat);

			GetRiverSide(ActiveSide).Remove(person);
		}

		public void Disembark(Person person)
		{
			if (IsAnimationRunning)
				return;

			if (!person.InBoat)
				return;

			Boat.Disembark(person);

			if (ActiveSide == SideKind.Left)
			{
				person.MoveToLeftSide();
				LeftSide.Add(person);
			}
			else
			{
				person.MoveToRightSide();
				RightSide.Add(person);
			}
		}

		public void StartMove(SideKind targetSide)
		{
			if (IsAnimationRunning)
				return;

			if (targetSide == ActiveSide)
			{
				throw new InvalidOperationException(
					"Лодка уже находится на выбранном берегу");
			}

			GameRules.ValidateBoatCanMove(
				Boat.Passengers);

			GameRules.ValidateRiverSide(
				GetRiverSide(ActiveSide).Passengers);

			_targetSide = targetSide;

			IsAnimationRunning = true;

			MoveCount++;
		}

		public void AnimationStep()
		{
			if (!IsAnimationRunning || _targetSide is null)
				return;

			var delta = _targetSide == SideKind.Right
				? GameConstants.BoatMoveStep
				: -GameConstants.BoatMoveStep;

			Boat.Move(delta);

			if (_targetSide == SideKind.Right &&
				Boat.Right >= GameConstants.BoatRightX)
			{
				Boat.SetPosition(
					GameConstants.BoatRightX - Boat.Width);

				IsAnimationRunning = false;

				_targetSide = null;

				GameRules.ValidateRiverSide(
					LeftSide.Passengers);
			}
			else if (_targetSide == SideKind.Left &&
					 Boat.X <= GameConstants.BoatLeftX)
			{
				Boat.SetPosition(
					GameConstants.BoatLeftX);

				IsAnimationRunning = false;

				_targetSide = null;

				GameRules.ValidateRiverSide(
					RightSide.Passengers);
			}
		}

		public Person? FindPersonAt(int x, int y)
		{
			return Passengers.LastOrDefault(
				person => person.IsActive(x, y));
		}

		public void Draw(Graphics graphics)
		{
			Boat.Draw(graphics);

			foreach (var passenger in Passengers)
			{
				passenger.Draw(graphics);
			}
		}

		private RiverSide GetRiverSide(SideKind side)
		{
			return side == SideKind.Left
				? LeftSide
				: RightSide;
		}

		private SideKind GetSideByPerson(Person person)
		{
			if (LeftSide.Passengers.Contains(person))
				return SideKind.Left;

			if (RightSide.Passengers.Contains(person))
				return SideKind.Right;

			return ActiveSide;
		}

		private static List<Person> CreatePassengers()
		{
			return new List<Person>
			{
				new Police(100, 250, 900, 100),

				new Criminal(160, 250, 900, 220),

				new Daughter(40, 270, 1030, 100),
				new Daughter(5, 300, 1030, 220),

				new Son(40, 350, 1030, 340),
				new Son(5, 380, 1030, 460),

				new Mother(70, 300, 900, 340),

				new Father(120, 300, 900, 460),
			};
		}
	}
}