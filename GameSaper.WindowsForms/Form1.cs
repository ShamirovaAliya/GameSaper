using GameSaper.Domain;

namespace GameSaper.WindowsForms
{
    public partial class Form1 : Form
    {
        private readonly int distance = 35;
        private readonly Dictionary<Button, Cell> dictionaryCell = new(); //Словарь для быстрого доступа к значениям через ключи

        private Field field; //В field хранятся ячейки и методы для управления ячейками

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
                    ErrorLbl.Text = string.Empty;
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

                    Button button = new();
                    button.MouseDown += CellBtn_Click;
                    button.Location = new Point(x, y);
                    button.Size = new Size(30, 30);

                    dictionaryCell.Add(button, cell);
                    GamePanel.Controls.Add(button);
                }
            }
        }

        private void CellBtn_Click(object? sender, MouseEventArgs e) //Метод, связь между кнопками и ячейками
        {
            if (field.Explode) //Проверка, взорвалось ли поле
            {
                return;
            }
            var button = (Button?)sender ?? throw new Exception(nameof(sender)); //Если не получилось привести sender, то выбрасывается исключение
            var cell = dictionaryCell[button]; //Доступ к ячейкам, а именно ячейка берётся из словаря и хранится в переменной

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
                field.ToggleFlag(cell.Id);
                if (cell.WithFlag)
                {
                    PressingRightButton(button);
                }
            }
        }

        private void PressingLeftButton(Button button) //Метод, нажатие левой кнопки мыши
        {
            MessageBox.Show("Вы проиграли!");
            button.Image = Properties.Resources.bomb;
            foreach (var bomb in field.GetBombs()) //Отображение всех скрытых бомб
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

        private void PressingRightButton(Button button) //Метод, нажатие правой кнопки мыши
        {
            button.Image = Properties.Resources.flag;
        }

        private void OpenEmptyCells(object sender) //Метод, по открытию пустых ячеек
        {
            var button = (Button)sender;
            var cell = dictionaryCell[button];
            var cells = field.OpenEmptyCells(cell);
            foreach (var openCell in cells)
            {
                AssignCells(openCell);
            }
        }

        private void AssignCells(Cell openCell) //Метод, отображение содержания ячейки
        {
            var button = dictionaryCell.Keys.FirstOrDefault(button => dictionaryCell[button] == openCell); //Поиск кнопки связанной с ячейкой
            if (button != null) //Чтобы не было исключений
                switch (field.BombCells(openCell.Id))
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
        }
    }
}