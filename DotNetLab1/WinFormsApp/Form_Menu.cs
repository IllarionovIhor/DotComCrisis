using ClassLibrary;

namespace WinFormsApp
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        // can't really access working directory of the solution, so I am digging out of the exe's path to outside
        static string relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString() + @"\users.bin";
        static string storagePath = @"C:\Users\user\Desktop\UNI\SUBJECTS ARCHIVE\C2-S1\.net\DotNet1\DotNetLab1\users.bin";
        public static AutomatedTellerMachine atm = new AutomatedTellerMachine("70", 1000, relativePath);

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            label_info.Text = $"{atm.Acc.Name}, Картка: {atm.Acc.CardNumber}";
        }

        private void Form_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            atm.logout();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_balance_Click(object sender, EventArgs e)
        {
            atm.getAccBalance();
        }

        private void button_put_Click(object sender, EventArgs e)
        {
            Form_input form = new Form_input("Введіть суму",() =>
            {
                int amount = 0;
                try
                {
                    amount = int.Parse(Form_input.data);
                    atm.put(amount);
                }
                catch
                {
                    MessageBox.Show("Помилка введення");
                }
            });
            form.ShowDialog();
        }

        private void button_withdraw_Click(object sender, EventArgs e)
        {
            Form_input form = new Form_input($"Ваш баланс: {atm.Acc.Balance}\nВведіть суму", () =>
            {
                int amount = 0;
                try
                {
                    amount = int.Parse(Form_input.data);
                    atm.withdraw(amount);
                }
                catch
                {
                    MessageBox.Show("Помилка введення");
                }
            });
            form.ShowDialog();
        }

        private void button_transfer_Click(object sender, EventArgs e)
        {
            int amount = 0;
            Form_input form1 = new Form_input($"Ваш баланс: {atm.Acc.Balance}\nВведіть суму", () =>
            {
                
                try
                {
                    amount = int.Parse(Form_input.data);
                }
                catch
                {
                    MessageBox.Show("Помилка введення");
                }
            });
            form1.ShowDialog();

            Form_input form2 = new Form_input($"Введіть картку отримувача", () =>
            {
                atm.transfer(amount,Form_input.data);
            });
            form2.ShowDialog();
        }
    }
}
