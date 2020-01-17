// Matias Puputti 3.10.2019
using System;
using System.Collections.Generic;
using static System.Console;

namespace Tehtävä2
{
    class ConsoleControl
    {
        //Ohjeen määrittelemä ConsoleControl luokka.
        public List<string> Items { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleControl(int col, int row, int widht, int height)
        {
            Column = col;
            Row = row;
            Width = widht;
            Height = height;
            BackColor = Console.BackgroundColor;
            TextColor = Console.ForegroundColor;
            Items = null;
            BackColor = ConsoleColor.Gray;
        }
        //Ohjeessa annettu Clear metodi.
        public void Clear()
        {
            int org_column = CursorLeft,
                org_row = CursorTop;

            for (int i = 0; i < Height; i++)
            {
                SetCursorPosition(Column - 1, Row - 1 + i);
                for (int e = 0; e < Width; e++)
                {
                    Write(" ");
                }
            }
            SetCursorPosition(org_column, org_row);
        }
        //Ohjeessa annettu draw metodi, elsen uloskommentoinnilla.
        public void Draw()
        {
            int org_column = CursorLeft,org_row = CursorTop;
            ConsoleColor org_fore = ForegroundColor,
                                    org_back = BackgroundColor;
                                    ForegroundColor = TextColor;
                                    BackgroundColor = BackColor;

            for (int i = 0; i < Height; i++)
            {
                SetCursorPosition(Column - 1, Row - 1 + i);
                if (Items != null && i < Items.Count)
                {
                    Write(Items[i].PadRight(Width, ' '));
                }
                //Kommentoin elsen pois koska se aiheutti TYÖN TEKIJÄT laatikon taustan venymisen ruudun alareunaan asti, 
                //enkä huomannut sen vaikuttavan ohjelmaan muilla tavoin.
                /*
               else
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Write(" ");
                    }
                }
                */
            }
            SetCursorPosition(org_column, org_row);
            ForegroundColor = org_fore;
            BackgroundColor = org_back;
        }
    }
}
