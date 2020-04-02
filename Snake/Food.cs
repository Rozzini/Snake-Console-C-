using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public interface IFoodResponder
    {
        public bool CanPlaceTo(Vector2 point);
    }

    class Food
    {
        static public char Symbol = '¤';
        public Vector2 Coords;
        public IFoodResponder Delegate;

        private FoodNode FoodNode;
        public Food(Vector2 vector2)
        {
            Coords = vector2;
            FoodNode = new FoodNode(vector2, Symbol);
        }

        public void Draw()
        {
            FoodNode.Draw();
        }

        public bool IntersectWith(Vector2 Point)
        {
            bool XPred = Point.X == Coords.X;
            bool YPred = Point.Y == Coords.Y;

            return XPred && YPred;
        }
    }
}
