using System.Drawing.Drawing2D;

namespace JapaneseCrossingApp
{
    public class Daughter : Person
    {
        public Daughter(int leftX, int leftY, int rightX, int rightY)
            : base(leftX, leftY, rightX, rightY)
        {
        }

		public override Bitmap Image => Properties.Resources.dauther;
		
        public override string Name => "Дочь";
        public override bool CanOperateBoat => false;
    }
}
