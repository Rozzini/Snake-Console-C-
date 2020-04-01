using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Vector2
    {

        private int x;
        private int y;

        public int X
        {
            set
            {
                x = value;
            }

            get
            {
                return x;
            }
        }

        public int Y
        {

            set
            {
                y = value;
            }

            get
            {

                return y;
            }
        }

        public Vector2(int xc, int xy)
        {
            this.X = xc;
            this.Y = xy;
        }

        public void UPDVector(int xc, int xy)
        {
            this.X = xc;
            this.Y = xy;
        }
    }

    
}
