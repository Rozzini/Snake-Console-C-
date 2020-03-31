using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Boundary
    {
        List<Brick> walls = new List<Brick>();

        public void DrawWall(int x, int y, int width, int hight, Brick.WallType type)
        {
            for(int i = x; i <=(width+x); i++)
            {
                for(int j = y; j<=(hight+y); j++)
                {
                    Brick brick = new Brick(i, j, type);
                    brick.Draw();
                }
            }
        }

        public void DrawBrick(int x, int y, Brick.WallType type)
        {
            Brick brick = new Brick(x, y, type);
            brick.Draw();
        }

    }
}
