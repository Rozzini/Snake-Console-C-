using System;

namespace Snake
{
    class Program
    {       
       
        static void Main(string[] args)
        {
            int FieldWidth = 80;
            int FieldHight = 30;
            Console.CursorVisible = false;
            GameField gameField = new GameField(FieldWidth, FieldHight);

            gameField.Start();
          
            //snake.InitMove(FieldWidth, FieldHight);

            //snake.WinCodition(FieldWidth / 2, FieldHight / 2);
            //for (int i=0; i<2;i++)
            //{
            //    i = 0;
            //}
        }
    }
}
