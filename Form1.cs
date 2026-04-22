using System.Xml.Linq;

namespace VVII_laba3
{
    public partial class Form1 : Form
    {
        public List<Button> buttons = new(2);
        internal ExpertSystem expertSystem = new ExpertSystem();

        public Form1()
        {
            expertSystem.ReadJsonFile("C:\\Users\\user\\.vscode\\C#\\VVII_laba3\\Tree.json");
            InitializeComponent();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CreateButton(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Node node = expertSystem.FindNode(clickedButton.Tag.ToString());
            flowLayoutPanel1.Controls.Clear();
            if (node.IsFinal)
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
                foreach (var (key, item) in node.Answer)
                {
                    Button button = new();
                    button.Text = key;
                    button.Tag = item;
                    button.Click += CreateButton;
                    button.Size = new(300, 40);
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Padding = new Padding(200, 0, 250, 0);
            button1.Hide();
            Node node = expertSystem.FindNode("root");
            label1.Text = node.Question;
            foreach (var (key, item) in node.Answer)
            {
                Button button = new();
                button.Text = key;
                button.Tag = item;
                button.Click += CreateButton;
                button.Size = new(300, 40);
                flowLayoutPanel1.Controls.Add(button);
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
