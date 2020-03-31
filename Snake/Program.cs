using System;

namespace Snake
{
    class Program
    {       
       
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameField gameField = new GameField();
           
            Snake snake = new Snake(40, 15);

            gameField.PrintFieldN1();
            snake.test();
           
           // snake.InitMove();

            //for (int i=0; i<2;i++)
            //{
            //    i = 0;
            //}
        }
    }
}
