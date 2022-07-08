namespace GameSaper.Domain
{
    public class Row //Ряд
    {
        //Метод, для определения ячеек
        public Row(int cellNumber, int row)
        {
            Cells = new Cell[cellNumber];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new Cell()
                {
                    Id = Guid.NewGuid().ToString(), //Уникальный идентификатор, чтобы можно было обозначить каждую ячейку
                    Column = i,
                    Row = row,
                };
            }
        }

        public Cell[] Cells { get; }
    }
}