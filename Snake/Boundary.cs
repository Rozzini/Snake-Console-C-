using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Boundary
    {

        public Vector2 Origin;
        public Brick.WallType Type;
        public int Width;
        public int Hight;
  
        public Boundary(Vector2 origin, int width, int hight, Brick.WallType type)
        {
            Origin = origin;
            Type = type;
            Width = width;
            Hight = hight;
        }

        public void Draw()
        {
            for (int i = Origin.X; i <= (Width + Origin.X); i++)
            {
                for (int j = Origin.Y; j <= (Hight + Origin.Y); j++)
                {
                    Brick brick = new Brick(new Vector2(i, j), Type);
                    brick.Draw();
                }
            }
        }

        public bool IntersectWith(Vector2 Point)
        {
            bool XPred = Point.X <= Width + Origin.X && Point.X >= Origin.X;
            bool YPred = Point.Y <= Hight + Origin.Y && Point.Y >= Origin.Y;

            return XPred && YPred;
        }

    }
}
