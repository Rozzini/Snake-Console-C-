using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class SnakeNode : Point
    {
        public char symbol = 'o';
        public SnakeNode(int x, int y)
        {
            this.xCoords = x;
            this.yCoords = y;
            this.charSymbol = symbol;           
        }
        
    }
}
