namespace GameSaper.Domain
{
    public class Field //Поле
    {
        public Field(int hight, int widht, int bombsNumber) //Инициализиция ячеек и рядов, это нужно чтобы потом можно было присвоить значения переменным
        {
            Rows = new Row[hight];
            Cells = new List<Cell>();
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new Row(widht, i);
                Cells.AddRange(Rows[i].Cells);
            }

            Random rnd = new(); //Распределение бомб в рандомном порядке и работа со свойством nearbyBomb
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

        public void CellOpen(string id) //Метод, открытия ячеек
        {
            var cell = Cells.First(x => x.Id == id);
            cell.IsOpen = true;
            if (cell.IsBomb)
            {
                Explode = true;
            }
        }

        public void FlagPut(string id) //Метод, поставить флажок
        {
            var cell = Cells.Where(x => x.Id == id).First();
            cell.WithFlag = true;
        }

        public int BombCells(string id) //Метод, который показывает сколько ячеек с бомбами вокруг
        {
            var cell = Cells.Where(x => x.Id == id).First();
            var cellsAround = Cells.Where(c => c.Row >= cell.Row - 1 && c.Row <= cell.Row + 1)
                .Where(c => c.Column >= cell.Column - 1 && c.Column <= cell.Column + 1);

            return cellsAround.Where(c => c.IsBomb).Count();
        }

        private List<Cell> GetCellsAroundWithoutBombs(Cell cell) //Метод, который возвращает ячейки вокруг указанной в параметрах
        {
            var cellsAround = Cells
                .Where(c => c.Row >= cell.Row - 1
                && c.Row <= cell.Row + 1
                && c.Column >= cell.Column - 1
                && c.Column <= cell.Column + 1
                && c.IsBomb == false
                && c.IsOpen == false);

            if (cellsAround.Any()) //Если ничего не будет найдено, то надо передать список. А если найдет, то преобразует в перечислитель и в список 
            {
                return cellsAround.ToList();
            }

            return new();
        }

        public List<Cell> GetBombs() => Cells.Where(x => x.IsBomb).ToList(); //Метод, который возвращает ячейку с бомбами и преобразует его в список

        public bool CheckCells() //Метод, для проверки условий победы
        {
            var cells = GetBombs();
            var numberCellScheckboxes = cells.Where(x => x.WithFlag).Count();
            return cells.Count == numberCellScheckboxes;
        }

        public IEnumerable<Cell> OpenEmptyCells(Cell cell) //Рекурсивный метод, для нахождения и открытия пустых ячеек
        {
            List<Cell> result = new(); //Собирает ячейки, которые нужно будет открыть с помощью списка
            if (cell.BombNearby) //Взятие с параметров cell и смотрит есть ли вокруг бомбы
            {
                return result;
            }

            var cellsAround = GetCellsAroundWithoutBombs(cell); //Принятие ячейки вокруг, в которых нет бомб и которые закрыты
            result.AddRange(cellsAround); //Добавление ячейки в result с помощью AddRange

            foreach (var currentCell in cellsAround) //Если попадется число, то будет вызван рекурсивный метод OpenEmptyCells и будет возвращен в пустой список
            {
                currentCell.IsOpen = true; //Смена значения IsOpen на true
                result.AddRange(OpenEmptyCells(currentCell)); //Добавление элементов в конец списка
            }

            return result;
        }

        public Row[] Rows { get; set; }
        public List<Cell> Cells { get; set; }
        public bool Explode { get; set; }
    }
}