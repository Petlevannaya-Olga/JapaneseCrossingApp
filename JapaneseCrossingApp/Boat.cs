namespace JapaneseCrossingApp
{
	public class Boat
	{
		private readonly Dictionary<Person, BoatSeat> _seats = new();

		private readonly Bitmap _image = Properties.Resources.boat;

		public Boat(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; private set; }

		public int Y { get; }

		public int Width { get; } = 260;

		public int Height { get; } = 140;

		public int Right => X + Width;

		public int Capacity { get; } = 2;

		public bool IsOnLeftSide => X <= GameConstants.BoatLeftX;

		public IReadOnlyCollection<Person> Passengers => _seats.Keys;

		public SideKind MovingToSide { get; private set; } = SideKind.Right;

		public void Draw(Graphics graphics)
		{
			if (MovingToSide == SideKind.Left)
			{
				graphics.TranslateTransform(X + Width, Y);
				graphics.ScaleTransform(-1, 1);

				graphics.DrawImage(
					_image,
					0,
					0,
					Width,
					Height);

				graphics.ResetTransform();

				return;
			}

			graphics.DrawImage(
				_image,
				X,
				Y,
				Width,
				Height);
		}

		public bool TryEmbark(
			Person person,
			out Point seatPosition,
			out BoatSeat seat)
		{
			seatPosition = Point.Empty;
			seat = BoatSeat.None;

			if (_seats.Count >= Capacity)
				return false;

			seat = GetFreeSeat();

			_seats.Add(person, seat);

			seatPosition = GetSeatPosition(seat);

			return true;
		}

		public void Disembark(Person person)
		{
			_seats.Remove(person);
		}

		public void Move(int delta)
		{
			ValidateMove();

			X += delta;

			UpdatePassengersPositions();
		}

		public void SetPosition(int x)
		{
			X = x;

			UpdatePassengersPositions();
		}

		private void ValidateMove()
		{
			if (_seats.Count == 0)
			{
				throw new InvalidOperationException(
					"Лодка не может двигаться без пассажиров");
			}

			if (_seats.Keys.All(person => !person.CanOperateBoat))
			{
				throw new InvalidOperationException(
					"Никто не может управлять лодкой");
			}
		}

		private void UpdatePassengersPositions()
		{
			foreach (var pair in _seats)
			{
				var person = pair.Key;
				var seat = pair.Value;

				var position = GetSeatPosition(seat);

				person.MoveToBoatSeat(
					position,
					seat,
					MovingToSide);
			}
		}

		private BoatSeat GetFreeSeat()
		{
			if (!_seats.Values.Contains(BoatSeat.Left))
				return BoatSeat.Left;

			return BoatSeat.Right;
		}

		private Point GetSeatPosition(BoatSeat seat)
		{
			return seat switch
			{
				BoatSeat.Left => new Point(X + 45, Y - 10),
				BoatSeat.Right => new Point(X + 130, Y - 10),

				_ => throw new ArgumentOutOfRangeException(nameof(seat))
			};
		}

		public void StartMove(SideKind targetSide)
		{
			MovingToSide = targetSide;
		}
	}
}