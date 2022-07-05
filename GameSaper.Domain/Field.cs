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

            Random rnd = new();
            for (int j = 1; j <= bombsNumber; j++)
            {
                int index;
                do
                {
                    index = rnd.Next(0, Cells.Count - 1);
                }
                while (Cells[index].IsBomb);

                Cells[index].IsBomb = true;

                var cellsAroundBomb = GetCellsAroundWithoutBombs(Cells[index]); //По методу GetCellsAround возвращает ячейки вокруг бомбы
                foreach (Cell cell in cellsAroundBomb)
                {
                    cell.BombNearby = true; //Эти ячейки будут сигнализировать о том, что вокруг находятся бомбы
                }
            }
        }

        public void CellOpen(string id) //Метод, по открытию ячейки
        {
            var cell = Cells.First(x => x.Id == id);
            cell.IsOpen = true;
            if (cell.IsBomb)
            {
                Explode = true;
            }
        }

        public void FlagPut(string id) //Метод, по вставлению флажка
        {
            var cell = Cells.Where(x => x.Id == id).First();
            cell.WithFlag = true;
        }

        public int BombCells(string id) //Метод, который показывает сколько ячеек с бомбами вокруг
        {
            var cell = Cells.Where(x => x.Id == id).First();
            var cellsAround = Cells.Where(c => c.Row >= cell.Row - 1 && c.Row <= cell.Row + 1);
            cellsAround = cellsAround.Where(c => c.Colunm >= cell.Colunm - 1 && c.Colunm <= cell.Colunm + 1);
            return cellsAround.Where(c => c.IsBomb).Count();
        }

        private List<Cell> GetCellsAroundWithoutBombs(Cell cell) //Метод, который возвращает ячейки вокруг указанной в параметрах
        {
            var cellsAround = Cells
                .Where(c => c.Row >= cell.Row - 1
                && c.Row <= cell.Row + 1
                && c.Colunm >= cell.Colunm - 1
                && c.Colunm <= cell.Colunm + 1
                && c.IsBomb == false
                && c.IsOpen == false);

            if (cellsAround.Any()) //Если ничего не будет найдено, то надо передать список. А если найдет, то преобразует в перечислитель и в список 
            {
                return cellsAround.ToList();
            }
            return new();
        }

        public List<Cell> GetBombs() //Метод, который возвращает ячейку с бомбами и преобразует его в список
        {
            return Cells.Where(x => x.IsBomb).ToList();
        }

        public bool CheckCells() //Метод, для проверки условий победы
        {
            var cells = GetBombs();
            var numberCellScheckboxes = cells.Where(x => x.WithFlag).Count();
            return cells.Count() == numberCellScheckboxes;
        }

        public IEnumerable<Cell> OpenEmptyCells(Cell cell) //Рекурсивный метод, для нахождения и открытия пустых ячеек
        {
            List<Cell> result = new();
            if (cell.BombNearby)
            {
                return result;
            }
            var cellsAround = GetCellsAroundWithoutBombs(cell);
            result.AddRange(cellsAround);

            foreach (var currentCell in cellsAround)
            {
                currentCell.IsOpen = true;
                result.AddRange(OpenEmptyCells(currentCell));
            }
            return result.Distinct();
        }

        public Row[] Rows { get; set; }
        public List<Cell> Cells { get; set; }
        public bool Explode { get; set; }
    }
}