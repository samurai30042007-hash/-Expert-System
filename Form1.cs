using System.Drawing.Drawing2D;

namespace VVII_laba3
{
    public partial class Form1 : Form
    {
        public List<Button> buttons = new(2);
        internal ExpertSystem expertSystem = new ExpertSystem();

        public Form1()
        {

            InitializeComponent();

        }
        private void RoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Light(btn.BackColor);
        }

        private void CreateButton_click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            Node node = null;
            try
            {
                node = expertSystem.FindNode(clickedButton.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить базу знаний:\n{ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            flowLayoutPanel1.Controls.Clear();
            if (node!.IsFinal)
            {
                flowLayoutPanel1.Hide();
                label1.Text = node.Title;
                label1.Location = new(276, 162);
                label1.Font = new Font("Segoe UI", 10F);
                label1.MaximumSize = new Size(300, 1100);
            }
            else
            {
                label1.Text = node.Question;
                CreateButton(node);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await expertSystem.ReadJsonFile("C:\\Users\\user\\.vscode\\C#\\VVII_laba3\\Tree.json");
                flowLayoutPanel1.Padding = new Padding(357,0, 357, 0);
                button1.Hide();
                Node node = expertSystem.FindNode("root");
                label1.Text = node.Question;
                CreateButton(node);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить базу знаний:\n{ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void CreateButton(Node node)
        {
            
            foreach (var (key, item) in node.Answer)
            {
                Button button = new();
                button.Text = key;
                button.Tag = item;
                button.Click += CreateButton_click;
                button.Size = new(200, 40);
                button.BackColor = Color.LightGreen;
                flowLayoutPanel1.Controls.Add(button);
                RoundButton(button, 15);
            }
        }



    }


}

