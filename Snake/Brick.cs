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
        public Brick(int x, int y, WallType type)
        {
            this.xCoords = x;
            this.yCoords = y;
            this.charSymbol = (char)type;
            this.wallType = type;
        }
               
        
    }
  
}

