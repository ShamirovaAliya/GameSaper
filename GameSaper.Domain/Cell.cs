using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaper.Domain
{
    public class Cell //Ячейка
    {
        public string Id { get; set; }
        public bool IsBomb { get; set; }
        public bool WithFlag { get; set; }
        public bool IsOpen { get; set; }
        public int Row { get; set; }
        public int Colunm { get; set; }
    }
}