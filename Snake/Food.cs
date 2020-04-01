using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food
    {
        static public char Symbol = '¶';
        static public Vector2 vec;
        public Food(Vector2 vector2/*, char ch*/)
        {
            vec = vector2;
            //Symbol = ch;
            FoodNode foodNode = new FoodNode(vector2, Symbol);
            foodNode.Draw();
        }

        public bool IntersectFood(Vector2 Point)
        {
            bool XPred = Point.X <= vec.X && Point.X >= vec.X;
            bool YPred = Point.Y <= vec.Y && Point.Y >= vec.Y;

            return XPred && YPred;
        }
    }
}
