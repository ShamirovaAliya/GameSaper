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
            for (int x = 10; x < height * distance; x += distance)
            {
                for (int y = 10; y < width * distance; y += distance)
                {
                    Button button = new Button();
                    button.Location = new Point(x, y);
                    button.Size = new Size(30, 30);
                    Controls.Add(button);
                }
            }
        }
    }
}