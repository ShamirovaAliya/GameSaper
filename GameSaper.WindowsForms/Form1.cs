namespace GameSaper.WindowsForms
{
    public partial class Form1 : Form
    {
        int height = 10;
        int width = 10;
        int distance = 35;
        int numberMine = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
           for (int x = 10; x < height * distance; x += distance)
            {
                for (int y = 10; y < width * distance; y += distance)
                {
                    Button button = new Button();
                    button.Click += CellBtn_Click;
                    button.Location = new Point(x, y);
                    button.Size = new Size(30, 30);
                    GamePanel.Controls.Add(button);
                }
            }
        }

        private void CellBtn_Click(object sender, EventArgs e)
        {
            var CellBtn_Click = new Dictionary<int, string>()
            {
                { 5, "Tom"},
                { 3, "Sam"},
                { 11, "Bob"}
            };
        }
    }
}