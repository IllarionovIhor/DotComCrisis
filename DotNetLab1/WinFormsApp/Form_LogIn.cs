namespace WinFormsApp
{
    public partial class Form_LogIn : Form
    {
        public Form_LogIn()
        {
            InitializeComponent(); 

            Form_Menu.atm.LogInFail += (sender, e) => MessageBox.Show("Не вдалося увійти");
            Form_Menu.atm.LogInSuccess += (sender, e) => MessageBox.Show($"Вхід успішний, {e.name}!");
            Form_Menu.atm.GotBalance += (sender, e) => MessageBox.Show($"Баланс: {e.balance}.");
            Form_Menu.atm.Added += (sender, e) => MessageBox.Show($"Додання {e.amount}. Баланс після додачи {e.recipient.Balance}");
            Form_Menu.atm.AmountLessOrEqualsToZero += (sender, e) => MessageBox.Show($"Введені дані менші або дорівнюють нулю.");
            Form_Menu.atm.Withdrawn += (sender, e) => MessageBox.Show($"Зняття {e.amount}. Поточний баланс: {e.recipient.Balance}");
            Form_Menu.atm.AtmInsufficientBalance += (sender, e) => MessageBox.Show($"Недостатньо коштів в терміналі");
            Form_Menu.atm.AccountInsufficientBalance += (sender, e) => MessageBox.Show($"Недостатньо коштів на балансі");
            Form_Menu.atm.Transfered += (sender, e) => MessageBox.Show($"Відправлено {e.amount} до {e.recipient.CardNumber}, {e.recipient.Name}. Поточний баланс відправника: {e.sender.Balance}");
            Form_Menu.atm.UserDoesntExist += (sender, e) => MessageBox.Show($"Користувача не існує");
            Form_Menu.atm.TransferToSelf += (sender, e) => MessageBox.Show($"Відправлення коштів до самого себе");
            Form_Menu.atm.LogOut += (sender, e) => MessageBox.Show($"Вихід успішний");
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string card = textbox_card.Text;
            string pin = textbox_pin.Text;
            if (Form_Menu.atm.login(card, pin))
            {
                var frm = new Form_Menu();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();

                textbox_card.Text = "";
                textbox_pin.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var registerForm = new Form_register(Form_Menu.atm);
            registerForm.Show();
        }

    }
}