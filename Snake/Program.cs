using System;

namespace Snake
{
    class Program
    {       
       
        static void Main(string[] args)
        {
            int FieldWidth = 15;
            int FieldHight = 8;
            Console.CursorVisible = false;
            GameField gameField = new GameField(FieldWidth, FieldHight);

            gameField.Start();
                     
        }
    }
}
