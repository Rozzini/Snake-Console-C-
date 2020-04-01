using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class FoodNode : Point
    {
        
        public FoodNode(Vector2 vector2, char ch)
        {
            this.xCoords = vector2.X;
            this.yCoords = vector2.Y;
            this.charSymbol = ch;
        }
    }
}
