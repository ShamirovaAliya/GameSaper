using GameSaper.Domain;

namespace GameSaper.WindowsForms
{
    public partial class Form1 : Form
    {
        int distance = 35;
        Dictionary<Button, Cell> dictionaryCell = new Dictionary<Button, Cell>(); //Словарь
        Field field;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            StartGame(10, 10);
        }

        private void StartBtn_Click(object sender, EventArgs e) //Метод, в котором находится выбор размера поля
        {
            var widthPasingResult = int.TryParse(WidthTB.Text, out var width);
            var heightPasingResult = int.TryParse(HeightTB.Text, out var height);
            if (widthPasingResult && heightPasingResult)
            {
                if (width > 15 || height > 15)
                {
                    ErrorLbl.Text = "Максимальное значение 15!";
                }
                else
                {
                    GamePanel.Controls.Clear();
                    StartGame(width, height);
                    ErrorLbl.Text = String.Empty;
                }
            }
            else
            {
                ErrorLbl.Text = "Неправильно введены данные!";
            }
        }

        private void StartGame(int height, int width) //После создания словаря можно узнать к какой ячейке относится кнопка. Создание кнопок
        {
            field = new Field(height, width, 10);
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

        private void CellBtn_Click(object sender, MouseEventArgs e) //Метод, связь между кнопками и ячейками
        {
            var button = (Button)sender;
            var cell = dictionaryCell[button];
            if (e.Button == MouseButtons.Left) //Условие для того, чтобы при нажатии левой кнопки мыши выходили числа или бомбы
            {
                field.CellOpen(cell.Id);
                if (cell.IsBomb)
                {
                    PressingLeftButton(button);
                }
                else
                {
                    CellBombsVictory(button, cell.Id);
                    OpenEmptyCells(sender);
                }
            }
            else if (e.Button == MouseButtons.Right) //Условие для того, чтобы при нажатии правой кнопки мыши можно было ставить флажки
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
            button.Image = Properties.Resources.bomb;
            foreach (var bomb in field.GetBombs()) //Цикл деактивации всех бомб
            {
                dictionaryCell
                    .Where(keyValue => keyValue.Value == bomb)
                    .First()
                    .Key
                    .Image = Properties.Resources.bomb;
            }
        }

        private void CellBombsVictory(Button button, string id)
        {
            switch (field.BombCells(id))
            {
                case 1:
                    button.Image = Properties.Resources.one;
                    break;
                case 2:
                    button.Image = Properties.Resources.two;
                    break;
                case 3:
                    button.Image = Properties.Resources.free;
                    break;
                case 4:
                    button.Image = Properties.Resources.four;
                    break;
                default:
                    button.BackColor = Color.DarkGray;
                    break;
            }
            if (field.CheckCells())
            {
                MessageBox.Show("Поздравляю, вы выиграли!");
            }
        }

        private void PressingRightButton(Button button)
        {
            button.Image = Properties.Resources.flag;
        }

        private void OpenEmptyCells(object sender) //Метод, по открытию пустых ячеек
        {
            var button = (Button)sender;
            var cell = dictionaryCell[button];
            foreach (var openCell in field.OpenEmptyCells(cell.Id))
            {

            }
        }
    }
}