//Matias Puputti 17.10.2019
using System;
using static System.Console;

namespace Teht4
{
    class Operation
    {
        public int Id { get; set; }
        public int TotalTimeInSeconds { get; set; }
        public int SpendTimeInSeconds { get; set; }
        public int Breaks { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }

        public Operation()
        {
            Started = DateTime.Now;
        }

        public void Print()
        {
            int Top = CursorTop;
            int Left = CursorLeft;

            CursorTop = Id;
            CursorLeft = 0;
            for (int i = 0; i < 60; i++)
            {
                Write(" ");
            }
            CursorLeft = 0;

            WriteLine($"{Id} {Started.ToLongTimeString()} {decimal.Round(decimal.Divide(SpendTimeInSeconds,TotalTimeInSeconds), 2 , MidpointRounding.AwayFromZero) * 100} %");
            SetCursorPosition(Left, Top);
        }

        public void PrintEnded()
        {
            int Top = CursorTop;
            int Left = CursorLeft;

            CursorTop = Id;
            WriteLine($"{Id} {Started.ToLongTimeString()} - {Ended.ToLongTimeString()} = duration {(Ended - Started).Seconds} secconds");
            SetCursorPosition(Left, Top);
        }

    }
}
