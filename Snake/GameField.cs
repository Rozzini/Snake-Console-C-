using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameField: ISnakeResponder, IFoodResponder
    {
        public static int Width = 0;
        public static int Height = 0;
        public static List<Boundary> boundaries = new List<Boundary>();
        public Snake Snake;
        public static Food Food;
        public static int GameScore = 0;
        

        public GameField(int W, int H)
        {
            Width = W;
            Height = H;
            Boundary boundaryTop = new Boundary(new Vector2(0, 0), Width, 0, Brick.WallType.Horizontal);
            Boundary boundaryBot = new Boundary(new Vector2(0, Height), Width, 0, Brick.WallType.Horizontal);
            Boundary boundaryLeft = new Boundary(new Vector2(0, 0), 0, Height, Brick.WallType.Vertical);
            Boundary boundaryRight = new Boundary(new Vector2(Width, 0), 0, Height, Brick.WallType.Vertical);
            boundaries.Add(boundaryTop);
            boundaries.Add(boundaryBot);
            boundaries.Add(boundaryLeft);
            boundaries.Add(boundaryRight);
        }

        public void Start()
        {
            Draw();

            Snake = new Snake(Width / 2, Height / 2)
            {
                Delegate = this
            };
            FoodSpawn();

            
            do
            { 
                Loger();
                Snake.Draw();
                System.Threading.Thread.Sleep(500);
                Snake.InitMove();
                Food.Draw();
            } while (!Snake.isDead);

            Snake.WinCodition(Width / 2, Height / 2, GameScore);
        }

        public void Loger()
        {
            Console.SetCursorPosition(Width + 2, Height - 4);
            Console.WriteLine("Food coords X/Y: " + Food.Coords.X + "/" + Food.Coords.Y);
            Console.SetCursorPosition(Width + 2, Height - 2);
            Console.WriteLine("SnakeHeadCoords: " + Snake.snakeNodes[0].xCoords + "/" + Snake.snakeNodes[0].yCoords);              
        }

        public static void Score()
        {           
            if(Snake.snakeNodes[0].xCoords == Food.Coords.X && Snake.snakeNodes[0].yCoords == Food.Coords.Y)
            {               
                GameScore = GameScore + 100;
            }
            Console.SetCursorPosition(Width + 2, Height / 3);
            Console.WriteLine("SCORE: " + GameScore);
        }

        public void Draw()
        {
            boundaries.ForEach(item => item.Draw());
        }

        public void FoodSpawn()
        {

            bool CanSpawn = true;
            Random random = new Random();
            Vector2 Purpose;
            do
            {
                Purpose = new Vector2(random.Next((Width - Width + 1), (Width - 1)), random.Next((Height - Height + 1), (Height - 1)));
                Food = new Food(Purpose)
                {
                    Delegate = this
                };
                foreach (var node in Snake.snakeNodes)
                {
                    if (Purpose.X == node.xCoords && Purpose.Y == node.yCoords && Purpose.X == Snake.TracksDeleter.X && Purpose.Y == Snake.TracksDeleter.Y)
                    {
                        CanSpawn = false;
                        break;
                    }
                    else
                    {
                        CanSpawn = true;
                    }
                }
                //CanSpawn = CanPlaceTo(Purpose);

            } while (CanSpawn == false);           
            Food.Draw();
        }

        //IFoodREsponder

        public bool CanPlaceTo(Vector2 point)
        {
            bool canplace = true;
            foreach (var node in Snake.snakeNodes)
            {
                if (point.X == node.xCoords && point.Y == node.yCoords && point.X == Snake.TracksDeleter.X && point.Y == Snake.TracksDeleter.Y)
                {
                    canplace = false;
                    break;
                }
                else
                {
                    canplace = true;
                }
            }
            return !Food.IntersectWith(point) && Snake.IntersectWith(point) && canplace;
            
        }

        //ISnakeResponder

        public bool CanMoveTo(Vector2 point)
        {
            bool result = false;
            boundaries.ForEach(item => result =  result || item.IntersectWith(point));
            result = result || Snake.IntersectWith(point);
            
            return !result;
        }

        public bool CanEatAt(Vector2 point)
        {
            if (Food == null)
            {
                return true;
            }
            return point.X == Food.Coords.X && point.Y == Food.Coords.Y;
        }

        public void FoodDidEaten()
        {
            FoodSpawn();
        }
    }
}
