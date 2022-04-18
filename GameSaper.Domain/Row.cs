using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaper.Domain
{
    public class Row //Ряд
    {
        public Row(int numberCell)
        {
            Cells = new Cell[numberCell];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new Cell()
                {
                    Id = Guid.NewGuid().ToString()
                };
            }
        }

        public Cell[] Cells { get; set; }
    }
}