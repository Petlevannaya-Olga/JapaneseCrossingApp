using System.Drawing.Drawing2D;

namespace JapaneseCrossingApp
{
    public class Game
    {
        public Game()
        {
            Passengers = CreatePassengers();
            LeftSide = new RiverSide(SideKind.Left);
            RightSide = new RiverSide(SideKind.Right);
            LeftSide.AddRange(Passengers);
            Boat = new Boat(GameConstants.BoatStartX, GameConstants.BoatY);
        }

        public RiverSide LeftSide { get; }
        public RiverSide RightSide { get; }
        public Boat Boat { get; }
        public List<Person> Passengers { get; }
        public int MoveCount { get; private set; }

        public SideKind ActiveSide => Boat.IsOnLeftSide ? SideKind.Left : SideKind.Right;
        public bool IsAnimationRunning { get; private set; }

        public bool IsSuccess => LeftSide.Passengers.Count == 0 && Boat.Passengers.Count == 0;

        public void Embark(Person person)
        {
            var side = GetSideByPerson(person);
            if (side != ActiveSide)
            {
                throw new InvalidOperationException("Персонаж находится не на том берегу, где стоит лодка");
            }

            Boat.Embark(person, ActiveSide);
            GetRiverSide(ActiveSide).Remove(person);
        }

        public void Disembark(Person person)
        {
            if (!person.InBoat)
            {
                return;
            }

            var side = GetRiverSide(ActiveSide);
            GameRules.ValidateRiverSide(side.Passengers.Concat(new[] { person }));

            Boat.Disembark(person, ActiveSide);
            side.Add(person);
        }

        public void StartMove(SideKind targetSide)
        {
            if (IsAnimationRunning)
            {
                return;
            }

            if (targetSide == ActiveSide)
            {
                throw new InvalidOperationException("Лодка уже находится на выбранном берегу");
            }

            GameRules.ValidateBoatCanMove(Boat.Passengers);
            GameRules.ValidateRiverSide(GetRiverSide(ActiveSide).Passengers);

            IsAnimationRunning = true;
            MoveCount++;
        }

        public void AnimationStep()
        {
            if (!IsAnimationRunning)
            {
                return;
            }

            var delta = Boat.IsOnLeftSide ? GameConstants.BoatMoveStep : -GameConstants.BoatMoveStep;
            Boat.Move(delta);

            if (Boat.X >= GameConstants.BoatRightX || Boat.X <= GameConstants.BoatLeftX)
            {
                IsAnimationRunning = false;
                GameRules.ValidateRiverSide(GetRiverSide(ActiveSide).Passengers);
            }
        }

        public Person? FindPersonAt(int x, int y)
        {
            return Passengers.FirstOrDefault(person => person.IsActive(x, y));
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
            return side == SideKind.Left ? LeftSide : RightSide;
        }

        private SideKind GetSideByPerson(Person person)
        {
            if (LeftSide.Passengers.Contains(person))
            {
                return SideKind.Left;
            }

            if (RightSide.Passengers.Contains(person))
            {
                return SideKind.Right;
            }

            return ActiveSide;
        }

        private static List<Person> CreatePassengers()
        {
            return new List<Person>
            {
                new Police(100, 250, 770, 40, 180, 280, 260, 280),
                new Criminal(160, 250, 747, 80, 155, 255, 240, 255),
                new Daughter(40, 270, 770, 290, 175, 255, 260, 255),
                new Daughter(5, 300, 770, 360, 175, 255, 260, 255),
                new Son(40, 350, 770, 480, 175, 305, 260, 305),
                new Son(5, 380, 770, 550, 175, 305, 250, 305),
				new Mother(70, 300, 747, 150, 155, 255, 240, 255),
				new Father(120, 300, 747, 220, 155, 255, 240, 255),
			};
        }
    }
}
