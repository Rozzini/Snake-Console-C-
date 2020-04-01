﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class SnakeNode : Point
    {
        public char symbol = 'o';
        public SnakeNode(Vector2 vector2)
        {
            this.xCoords = vector2.X;
            this.yCoords = vector2.Y;
            this.charSymbol = symbol;           
        }
        
    }
}
