using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameField: SnakeDelegate
    {
        public int Width = 0;
        public int Height = 0;
        public static List<Boundary> boundaries = new List<Boundary>();
        public Snake Snake;
        public Food food;
        public int GameScore = 0;
        

        public GameField(int W, int H)
        {
            this.Width = W;
            this.Height = H;
        }

        public void Start()
        {
            PrintFieldN1();
            
            Snake = new Snake(Width / 2, Height / 2);
            Snake.Delegate = this;

            FoodSpawn();
            do
            {
                Score();
                if(Snake.notEaten == false )
                {
                    FoodSpawn();
                    Snake.notEaten = true;
                }
                Snake.Draw();
                System.Threading.Thread.Sleep(100);
                Snake.InitMove();
            } while (!Snake.isDead);

            Snake.WinCodition(Width / 2, Height / 2, GameScore);
        }


        public void Score()
        {
            if(Snake.notEaten == false)
            {
                GameScore = GameScore + 100;
            }
            Console.SetCursorPosition(Width + 2, Height/1/3);
            Console.WriteLine("SCORE: " + GameScore);
        }
        public void FoodSpawn()
        {           
            int x;
            int y;
            bool a = true;
            Random random = new Random();
            do
            {
                x = random.Next((Width - Width + 2), (Width - 2));
                y = random.Next((Height - Height + 2), (Height - 2));
            } while (a != true);
            food = new Food(new Vector2(x, y));
        }
        public void PrintFieldN1()
        {
  
            Boundary boundaryTop = new Boundary(new Vector2(0,0), Width, 0, Brick.WallType.Horizontal);
            Boundary boundaryBot = new Boundary(new Vector2(0, Height), Width, 0, Brick.WallType.Horizontal);
            Boundary boundaryLeft = new Boundary(new Vector2(0, 0), 0, Height, Brick.WallType.Vertical);
            Boundary boundaryRight = new Boundary(new Vector2(Width, 0), 0, Height, Brick.WallType.Vertical);
            boundaries.Add(boundaryTop);
            boundaries.Add(boundaryBot);
            boundaries.Add(boundaryLeft);
            boundaries.Add(boundaryRight);
        }

        public bool CanPlaceTo(Vector2 point)
        {
            bool result = false;
            result = result || food.IntersectFood(point);

            return !result;
        }

        public bool CanMoveTo(Vector2 point)
        {
            bool result = false;
            boundaries.ForEach(item => result =  result || item.IntersectWith(point));
            result = result || Snake.IntersectWith(point);
            
            return !result;
        }
    }
}
