using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Brick : Point
    {        
        public enum WallType
        {
            Horizontal = '═',
            Vertical = '║',
            LeftTopCorner ='╔',
            LeftBotCorner ='╚',
            RightTopCorner = '╗',
            RightBotCorner = '╝',
            Del = ' '
        }

        public WallType wallType; 
        public Brick(Vector2 vector2, WallType type)
        {
            this.xCoords = vector2.X;
            this.yCoords = vector2.Y;
            if (vector2.X == 0 && vector2.Y == 0)
            {
                this.wallType = WallType.LeftTopCorner;
                this.charSymbol = (char)this.wallType;
            }
            else if (vector2.X == 0 && vector2.Y == GameField.Height)
            {
                this.wallType = WallType.LeftBotCorner;
                this.charSymbol = (char)this.wallType;
            }
            else if (vector2.X == GameField.Width && vector2.Y == 0)
            {
                this.wallType = WallType.RightTopCorner;
                this.charSymbol = (char)this.wallType;
            }
            else if (vector2.X == GameField.Width && vector2.Y == GameField.Height)
            {
                this.wallType = WallType.RightBotCorner;
                this.charSymbol = (char)this.wallType;
            }
            else
            {
                this.charSymbol = (char)type;
                this.wallType = type;
            }
        }
               
        
    }
  
}

