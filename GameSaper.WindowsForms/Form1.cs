using GameSaper.Domain;

namespace GameSaper.WindowsForms
{
    public partial class Form1 : Form
    {
        int height = 10;
        int width = 10;
        int distance = 35;
        Dictionary<Button, Cell> dictionaryCell = new Dictionary<Button, Cell>();
        Field field;

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
            GamePanel.Controls.Clear();
            StartGame();
        }

        private void StartGame()
        {
            field = new Field(10, 10, 10);
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
                    PressingLeftButton(button);
                }
                else
                {
                    CellBombsVictory(button, cell.Id);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                field.FlagPut(cell.Id);
                if (cell.WithFlag)
                {
                    PressingRightButton(button);
                }
            }
        }

        private void PressingLeftButton(Button button)
        {
            MessageBox.Show("Вы проиграли!");
            button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img1.png");
            foreach (var bomb in field.GetBombs())
            {
                dictionaryCell
                    .Where(keyValue => keyValue.Value == bomb)
                    .First()
                    .Key
                    .Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img1.png");
            }
        }

        private void CellBombsVictory(Button button, string id)
        {
            switch (field.BombCells(id))
            {
                case 1:
                    button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img3.png");
                    break;
                case 2:
                    button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img4.png");
                    break;
                case 3:
                    button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img5.png");
                    break;
                case 4:
                    button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img6.png");
                    break;
                default:
                    button.BackColor = Color.Black;
                    break;
            }
            if (field.CheckCells())
            {
                MessageBox.Show("Поздравляю, вы выиграли!");
            }    
        }

        private void PressingRightButton(Button button)
        {
            button.Image = Image.FromFile(@"C:\project\Saper\GameSaper\Resources\img2.png");
        }
    }
}