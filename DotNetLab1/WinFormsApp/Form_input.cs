namespace WinFormsApp
{
    public partial class Form_input : Form
    {
        public delegate void OnClose();
        OnClose Closed;
        public static string data = "";

        public Form_input(string text, OnClose closed)
        {
            InitializeComponent();

            label_text.Text = text;
            Closed = closed;
        }

        private void Form_input_Load(object sender, EventArgs e)
        {

        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            data = textbox_input.Text;
            this.Close();
        }

        private void Form_input_FormClosed(object sender, FormClosedEventArgs e)
        {
            Closed();
        }
    }
}
