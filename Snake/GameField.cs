using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameField
    {
        public void PrintFieldN1()
        {
            Boundary boundary = new Boundary();
            boundary.DrawWall(0, 0, 80, 0, Brick.WallType.Horizontal);
            boundary.DrawWall(0, 30, 80, 0, Brick.WallType.Horizontal);
            boundary.DrawWall(0, 0, 0, 30, Brick.WallType.Vertical);
            boundary.DrawWall(80, 0, 0, 30, Brick.WallType.Vertical);
            boundary.DrawBrick(0, 0, Brick.WallType.LeftTopCorner);
            boundary.DrawBrick(0, 30, Brick.WallType.LeftBotCorner);
            boundary.DrawBrick(80, 0, Brick.WallType.RightTopCorner);
            boundary.DrawBrick(80, 30, Brick.WallType.RightBotCorner);
        }
    }
}
