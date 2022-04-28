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
                Rows[i] = new Row(widht, i);
                Cells.AddRange(Rows[i].Cells);
            }

            Random rnd = new Random();
            for (int j = 1; j <= bombsNumber; j++) 
            {
                int index = 0;
                do
                {
                    index = rnd.Next(0, Cells.Count - 1);
                }
                while (Cells[index].IsBomb);

                Cells[index].IsBomb = true;
            }
        }

        public void CellOpen(string id)
        {
            var cell = Cells.First(x => x.Id == id);
            cell.IsOpen = true;
            if (cell.IsBomb)
            {
                Explode = true;
            }
        }

        public void FlagPut(string id)
        {
            var cell = Cells.Where(x => x.Id == id).First();
            cell.WithFlag = true;
        }

        public int BombCells(string id)
        {
            var cell = Cells.Where(x => x.Id == id).First();

            var cellsAround = Cells.Where(c => c.Row >= cell.Row - 1 && c.Row <= cell.Row + 1);

            cellsAround = cellsAround.Where(c => c.Colunm >= cell.Colunm - 1 && c.Colunm <= cell.Colunm + 1);
            return cellsAround.Where(c => c.IsBomb).Count();
        }

        public List<Cell> GetBombs()
        {
            return Cells.Where(x => x.IsBomb).ToList();
        }

        public bool CheckCells()
        {
            var cells = GetBombs();
            var numberCellScheckboxes = cells.Where(x => x.WithFlag).Count();
            return cells.Count() == numberCellScheckboxes;
        }

        public int BombsNumber { get; set; }
        public int FlagNumbers { get; set; }
        public int Nubmers { get; set; }
        public Row[] Rows { get; set; }
        public List<Cell> Cells { get; set; }
        public bool Explode { get; set; }

        public int BombCells(object id)
        {
            throw new NotImplementedException();
        }
    }
}