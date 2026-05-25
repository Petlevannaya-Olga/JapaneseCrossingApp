using System.Drawing.Drawing2D;

namespace JapaneseCrossingApp
{
    public class Son : Person
    {
        public Son(int leftX, int leftY, int rightX, int rightY)
            : base(leftX, leftY, rightX, rightY)
        {
        }

		public override Bitmap Image => Properties.Resources.son;
		public override string Name => "Сын";
        public override bool CanOperateBoat => false;
    }
}
