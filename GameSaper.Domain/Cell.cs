using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaper.Domain
{
    public class Cell //Ячейки
    {
        public bool IsBomb { get; set; }
        public bool WithFlag { get; set; }
        public int VerticalPosition { get; set; }
        public int HorizontalPosition { get; set; }
        public bool IsOpen { get; set; }
        public bool IsHidden { get; set; }
    }
}