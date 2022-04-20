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
            Cells = new List<Cell>();
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row(widht);
                Cells.AddRange(Rows[i].Cells);
            }

            Random rnd = new Random();
            for (int i = 1; i <= bombsNumber; i++)
            {
                int index = 0;
                do
                {
                    index = rnd.Next(0, Cells.Count - 1);
                }
                while (Cells[index].IsBomb);

                Cells[i].IsBomb = true;
            }
        }

        public void CellOpen(string id)
        {
            var Cell = Cells.Where(x => x.Id == id).First();
            Cell.IsOpen = true;
            if (Cell.IsBomb)
            {
                Explode = true;
            }
        }

        public int BombsNumber { get; set; }
        public int FlagNumbers { get; set; }
        public int Nubmers { get; set; }
        public Row[] Rows { get; set; }
        public List<Cell> Cells { get; set; }
        public bool Explode { get; set; }
    }
}