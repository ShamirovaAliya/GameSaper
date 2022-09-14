namespace GameSaper.Domain
{
    public class Cell //Ячейка
    {
        public string Id { get; set; }
        public bool IsBomb { get; set; }
        public bool WithFlag { get; set; }
        public bool IsOpen { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool BombNearby { get; set; }
        public bool IsSelected { get; set; }
    }
}