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
            this.charSymbol = (char)type;
            this.wallType = type;
        }
               
        
    }
  
}

