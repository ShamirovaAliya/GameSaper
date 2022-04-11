using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaper.Domain
{
    public class Field //Поле
    {
        public Field(int hight, int widht, int bombsNumber)
        {
            Cells = new Cell[hight * widht];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new Cell();
            }

            Random rnd = new Random();
            for (int i = 1; i < bombsNumber; i++)
            {
                int index = 0;
                do
                {
                    index = rnd.Next(0, Cells.Length - 1);
                }
                while (Cells[index].IsBomb);

                Cells[i].IsBomb = true;
            }
        }
        public int BombsNumber { get; set; }
        public int FlagNumbers { get; set; }
        public int Nubmers { get; set; }
        Cell[] Cells { get; set; }
    }
}
