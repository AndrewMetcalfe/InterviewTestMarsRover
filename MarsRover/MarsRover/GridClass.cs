using System;
namespace MarsRover
{
    public class GridClass
    {
        public GridClass()
        {
        }

		const int gridMinX = 1;
		const int gridMaxX = 100;

		const int gridMinY = 1;
		const int gridMaxY = 100;

        public string GetGridRef(int x, int y)
        {
            return (x + ((y - 1) * gridMaxX)).ToString();
        }

		public int GetGridRefInt(int x, int y)
		{
			return x + ((y - 1) * gridMaxX);
		}
        public int GetY(string gridRef) 
        {
            var gf = int.Parse(gridRef);
			var mod = gf % gridMaxX;
            			
			if (mod == 0)
			{
                return (gf / gridMaxX);
			}
			else
			{
				return (gf / gridMaxX) + 1; ;
			}
        }

        public int GetX(string gridRef)
        {
            var gf = int.Parse(gridRef);
            var mod = gf % gridMaxX;

            if (mod == 0)
            {
                return gridMaxX;
            }
            else
            {
                return mod;
            }
		}
		
    }
}
