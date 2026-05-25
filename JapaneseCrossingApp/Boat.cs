namespace JapaneseCrossingApp
{
    public class Boat
    {
        private readonly Image _image = Properties.Resources.boat;
		
        private readonly List<Person> _passengers = new();

        public Boat(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; }
		public int Width { get; } = 200;
		public int Height { get; } = 100;
		public int Capacity { get; } = 2;
        public IReadOnlyList<Person> Passengers => _passengers;

        public bool HasFreeSeat => _passengers.Count < Capacity;
        public bool IsOnLeftSide => X <= GameConstants.BoatLeftX;
        public bool IsOnRightSide => X >= GameConstants.BoatRightX;

        public SideKind CurrentSide => IsOnLeftSide ? SideKind.Left : SideKind.Right;

        public BoatSeat GetFreeSeat()
        {
            if (_passengers.All(passenger => passenger.Seat != BoatSeat.Left))
            {
                return BoatSeat.Left;
            }

            if (_passengers.All(passenger => passenger.Seat != BoatSeat.Right))
            {
                return BoatSeat.Right;
            }

            return BoatSeat.None;
        }

        public void Embark(Person person, SideKind side)
        {
            if (!HasFreeSeat)
            {
                throw new InvalidOperationException("В лодке нет свободных мест");
            }

            if (_passengers.Contains(person))
            {
                return;
            }

            var freeSeat = GetFreeSeat();
            if (freeSeat == BoatSeat.None)
            {
                throw new InvalidOperationException("В лодке нет свободных мест");
            }

            _passengers.Add(person);
            person.MoveToBoatSeat(freeSeat, side);
        }

        public void Disembark(Person person, SideKind side)
        {
            if (!_passengers.Remove(person))
            {
                return;
            }

            if (side == SideKind.Left)
            {
                person.MoveToLeftSide();
            }
            else
            {
                person.MoveToRightSide();
            }
        }

        public void Move(int delta)
        {
            GameRules.ValidateBoatCanMove(_passengers);

            X += delta;

            foreach (var passenger in _passengers)
            {
                passenger.MoveBy(delta);
            }
        }

        public void Draw(Graphics graphics)
        {
			graphics.DrawImage(_image, X, Y, Width, Height);
		}
    }
}
