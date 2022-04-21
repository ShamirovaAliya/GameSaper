using GameSaper.Domain;

namespace GameSaper.WindowsForms
{
    public partial class Form1 : Form
    {
        int height = 10;
        int width = 10;
        int distance = 35;
        int numberMine = 10;
        Dictionary<Button, Cell> dictionaryCell = new Dictionary<Button, Cell>();
        Field field = new Field(10, 10, 10);

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
                int index = (x - 10) / distance;
                var row = field.Rows[index];
                for (int y = 10; y < width * distance; y += distance)
                {
                    int cellIndex = (y - 10) / distance;
                    var cell = row.Cells[cellIndex];

                    Button button = new Button();
                    button.MouseDown += CellBtn_Click;
                    button.Location = new Point(x, y);
                    button.Size = new Size(30, 30);

                    dictionaryCell.Add(button, cell);
                    GamePanel.Controls.Add(button);
                }
            }
        }

        private void CellBtn_Click(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            var cell = dictionaryCell[button];
            if (e.Button == MouseButtons.Left)
            {
                field.CellOpen(cell.Id);
                if (cell.IsBomb)
                {
                    MessageBox.Show("Вы проиграли!");
                    button.Text = "*";
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                field.FlagPut(cell.Id);
                if (cell.WithFlag)
                {
                    button.Text = "F";
                }
            }
        }
    }
}