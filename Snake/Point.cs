using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Point
    {
        private int x;
        private int y;
        private char ch;
        

        public int xCoords
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int yCoords
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int charSymbol
        {
            get
            {
                return ch;
            }

            set
            {
                ch = (char)value;
            }
        }
        public void Clear()
        {
            DrawPoint(' ');
        }

        private void DrawPoint(char _ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_ch);
        }
        public void Draw()
        {
            DrawPoint(ch);
        }

    }
}
