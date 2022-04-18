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
            Rows = new Row[hight];
            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row(widht);
                cells.AddRange(Rows[i].Cells);

            }
            
            Random rnd = new Random();
            for (int i = 1; i <= bombsNumber; i++)
            {
                int index = 0;
                do
                {
                    index = rnd.Next(0, cells.Count - 1);
                }
                while (cells[index].IsBomb);

                cells[i].IsBomb = true;
            }
        }
        public int BombsNumber { get; set; }
        public int FlagNumbers { get; set; }
        public int Nubmers { get; set; }
        public Row[] Rows { get; set; }
    }
}
