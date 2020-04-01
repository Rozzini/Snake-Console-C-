using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public interface SnakeDelegate
    {
        bool CanMoveTo(Vector2 point);
    }

    class Snake
    {
        public bool isDead = false;
        public bool notEaten = true;
        public int SnakeLenght = 3;
        private int headCoordX = 0;
        private int headCoordY = 0;
        List<SnakeNode> snakeNodes = new List<SnakeNode>();
        public SnakeDelegate Delegate;

        Vector2 velocity = new Vector2(1, 0);

        public int HeadCoordX
        {
            get
            {
                return headCoordX;
            }

            set
            {
                headCoordX = value;
            }
        }

        public int HeadCoordY
        {
            get
            {
                return headCoordY;
            }

            set
            {
                headCoordY = value;
            }
        }
        public Snake(int x, int y)
        {
            HeadCoordX = x;
            HeadCoordY = y;          
            
            for(int i=0; i< SnakeLenght; i++)
            {
                SnakeNode snakeNode = new SnakeNode(new Vector2(HeadCoordX-i, HeadCoordY));
                snakeNodes.Add(snakeNode);
            }
          
        }

        public void Draw()
        {
            foreach(var node in snakeNodes)
            {
                node.Draw();
            }
        }

        public bool IntersectWith(Vector2 Point)
        {            
            foreach(var item in snakeNodes)
            {
                if(item.xCoords == Point.X && item.yCoords == Point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void InitMove()
        {                        
            Vector2 temp = new Vector2(1, 0);
           
            DetectMove();
            if (this.Delegate.CanMoveTo(new Vector2(snakeNodes[0].xCoords + velocity.X, snakeNodes[0].yCoords + velocity.Y)))
            {
                temp.X = snakeNodes[snakeNodes.Count - 1].xCoords;
                temp.Y = snakeNodes[snakeNodes.Count - 1].yCoords;

                snakeNodes[0].xCoords += velocity.X;
                snakeNodes[0].yCoords += velocity.Y;

                if(Food.vec.X == snakeNodes[0].xCoords && Food.vec.Y == snakeNodes[0].yCoords)
                {
                    SnakeNode snakeNode = new SnakeNode(new Vector2(snakeNodes[snakeNodes.Count - 1].xCoords, snakeNodes[snakeNodes.Count - 2].yCoords));
                    notEaten = false;
                    snakeNodes.Add(snakeNode);
                    this.SnakeLenght++;
                }

                for (int i = snakeNodes.Count - 1; i >= 1; i--)
                { 
                    snakeNodes[i].xCoords = snakeNodes[i - 1].xCoords;
                    snakeNodes[i].yCoords = snakeNodes[i - 1].yCoords;
                }

                snakeNodes[1].xCoords = snakeNodes[0].xCoords - velocity.X;
                snakeNodes[1].yCoords = snakeNodes[0].yCoords - velocity.Y;

                //TODO: remove
                Brick brick = new Brick(new Vector2(temp.X, temp.Y), Brick.WallType.Del);
                brick.Draw();
            }
            else
            {
                isDead = true;
            }
        }

        public void WinCodition(int x, int y, int score)
        {
            if(score == 1000)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("YOU WIN");
            }
            if (isDead == true)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Death");
            }
            Console.ReadKey();
        }

        private void DetectMove()
        {
           
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (velocity.X == 1 || velocity.X == -1)
                            {                               
                                velocity.UPDVector(0, -1);
                                break;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if(velocity.X == 1 || velocity.X == -1)
                            {
                               
                                velocity.UPDVector(0, 1);
                                break;
                            }                            
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if(velocity.Y == 1 || velocity.Y == -1)
                            {
                                
                                velocity.UPDVector(-1, 0);
                                break;
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if(velocity.Y == 1 || velocity.Y == -1)
                            {
                                
                                velocity.UPDVector(1, 0);
                                break;
                            }
                            break;
                        }
                }
            }
        }

    }
}
