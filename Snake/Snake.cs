using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        public bool isDead = false;
        public int SnakeLenght = 14;
        private int headCoordX = 0;
        private int headCoordY = 0;
        List<SnakeNode> snakeNodes = new List<SnakeNode>();



        public void AAA()
        {
            Console.WriteLine("Nodes count: " + snakeNodes.Count);           
        }
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
                SnakeNode snakeNode = new SnakeNode(HeadCoordX-i, HeadCoordY);
                snakeNodes.Add(snakeNode);
            }

          
        }

        public void test()
        {
            foreach(var node in snakeNodes)
            {
                node.Draw();
            }
        }

        public void InitMove()
        {
            int tempX = 0;
            int tempY = 0;
            int dx = 1;
            int dy = 0;            
            int delayInMillisecs = 300;
            do
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                dx = 0;
                                dy = -1;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                dx = 0;
                                dy = 1;
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                dx = -1;
                                dy = 0;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                dx++;
                                dy = 0;
                                break;
                            }
                    }
                }                

                tempX = snakeNodes[snakeNodes.Count - 1].xCoords;
                tempY = snakeNodes[snakeNodes.Count - 1].yCoords;

                snakeNodes[0].xCoords += dx;
                snakeNodes[0].yCoords += dy;

                for (int i = snakeNodes.Count-1; i >=1; i--)
                {
                   snakeNodes[i].xCoords = snakeNodes[i-1].xCoords;
                   snakeNodes[i].yCoords = snakeNodes[i-1].yCoords;                  
                }

                snakeNodes[1].xCoords = snakeNodes[0].xCoords - dx;
                snakeNodes[1].yCoords = snakeNodes[0].yCoords - dy;

                Brick brick = new Brick(tempX, tempY, Brick.WallType.Del);

                brick.Draw();

                foreach (var node in snakeNodes)
                    {
                        node.Draw();
                    }
                    System.Threading.Thread.Sleep(delayInMillisecs);
                
            } while (isDead == false);
        }
       
    }
}
