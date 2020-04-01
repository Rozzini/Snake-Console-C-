using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Boundary
    {

        public Vector2 Origin;
        public int Width;
        public int Hight;


        public Boundary(Vector2 vector2, int width, int hight, Brick.WallType type)
        {
            Origin = vector2;
            Width = width;
            Hight = hight;
            for(int i = vector2.X; i <=(width+vector2.X); i++)
            {
                for(int j = vector2.Y; j<=(hight+vector2.Y); j++)
                {
                    Brick brick = new Brick(new Vector2(i,j), type);
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
