namespace JapaneseCrossingApp
{
	public abstract class Person
	{
		protected Person(
			int leftX,
			int leftY,
			int rightX,
			int rightY)
		{
			LeftSidePosition = new Point(leftX, leftY);
			RightSidePosition = new Point(rightX, rightY);

			Position = LeftSidePosition;
		}

		public int Width { get; } = 100;
		public int Height { get; } = 100;

		public abstract Bitmap Image { get; }

		public Point Position { get; private set; }

		public int X => Position.X;
		public int Y => Position.Y;

		protected Point LeftSidePosition { get; }
		protected Point RightSidePosition { get; }

		public abstract string Name { get; }

		public abstract bool CanOperateBoat { get; }

		public BoatSeat Seat { get; private set; } = BoatSeat.None;

		public bool InBoat { get; private set; }

		public void MoveToLeftSide()
		{
			Seat = BoatSeat.None;
			InBoat = false;

			Position = LeftSidePosition;
		}

		public void MoveToRightSide()
		{
			Seat = BoatSeat.None;
			InBoat = false;

			Position = RightSidePosition;
		}

		public void MoveToBoatSeat(Point seatPosition, BoatSeat seat)
		{
			if (seat == BoatSeat.None)
			{
				throw new ArgumentException(
					"Для посадки нужно указать место в лодке",
					nameof(seat));
			}

			Seat = seat;
			InBoat = true;

			Position = seatPosition;
		}

		public void MoveBy(int dx, int dy = 0)
		{
			Position = new Point(
				Position.X + dx,
				Position.Y + dy);
		}

		public virtual void Draw(Graphics graphics)
		{
			graphics.DrawImage(
				Image,
				X,
				Y,
				Width,
				Height);
		}

		public virtual bool IsActive(int x, int y)
		{
			if (x < X ||
				y < Y ||
				x >= X + Width ||
				y >= Y + Height)
			{
				return false;
			}

			int localX = x - X;
			int localY = y - Y;

			using var bitmap = new Bitmap(Image, Width, Height);

			Color pixel = bitmap.GetPixel(localX, localY);

			return pixel.A > 10;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}