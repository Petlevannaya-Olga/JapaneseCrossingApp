using static System.Net.Mime.MediaTypeNames;

namespace JapaneseCrossingApp
{
    public abstract class Person
    {
        protected Person(int leftX, int leftY, int rightX, int rightY, int boatLeftX, int boatLeftY, int boatRightX, int boatRightY)
        {
            LeftSidePosition = new Point(leftX, leftY);
            RightSidePosition = new Point(rightX, rightY);
            BoatLeftPosition = new Point(boatLeftX, boatLeftY);
            BoatRightPosition = new Point(boatRightX, boatRightY);

            Position = LeftSidePosition;
        }

		public int Width { get; } = 100;
		public int Height { get; } = 100;
		
        public abstract Bitmap Image { get; }

        public Point Position { get; private set; }

        public int X => Position.X;
        public int Y => Position.Y;

        public abstract string Name { get; }
        public abstract bool CanOperateBoat { get; }

        public Point LeftSidePosition { get; }
        public Point RightSidePosition { get; }
        public Point BoatLeftPosition { get; }
        public Point BoatRightPosition { get; }

        public BoatSeat Seat { get; private set; } = BoatSeat.None;
        public bool InBoat => Seat != BoatSeat.None;

        public void MoveToLeftSide()
        {
            Seat = BoatSeat.None;
            Position = LeftSidePosition;
        }

        public void MoveToRightSide()
        {
            Seat = BoatSeat.None;
            Position = RightSidePosition;
        }

        public void MoveToBoatSeat(BoatSeat seat, SideKind boatSide)
        {
            if (seat == BoatSeat.None)
            {
                throw new ArgumentException("Для посадки нужно выбрать место в лодке", nameof(seat));
            }

            var basePosition = seat == BoatSeat.Left ? BoatLeftPosition : BoatRightPosition;
            var offsetX = boatSide == SideKind.Left ? 0 : GameConstants.RightSideOffset;

            Seat = seat;
            Position = new Point(basePosition.X + offsetX, basePosition.Y);
        }

        public void MoveBy(int dx, int dy = 0)
        {
            Position = new Point(Position.X + dx, Position.Y + dy);
        }

		public virtual void Draw(Graphics graphics)
		{
			graphics.DrawImage(Image, X, Y, Width, Height);
		}

		public virtual bool IsActive(int x, int y)
		{
			if (x < X || y < Y || x >= X + Width || y >= Y + Height)
				return false;

			int localX = x - X;
			int localY = y - Y;

			using var bitmap = new Bitmap(Image, Width, Height);

			Color pixel = bitmap.GetPixel(localX, localY);

			return pixel.A > 10;
		}

		public override string ToString() => Name;
    }
}
