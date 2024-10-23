using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class Form_register : Form
    {
        public event EventHandler<RegistrationEventArgs> RegistrationSuccess;
        private AutomatedTellerMachine atm;
        public Form_register(AutomatedTellerMachine atm)
        {
            InitializeComponent();
            this.atm = atm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string cardNumber = textBox3.Text;
            string pin = textBox1.Text;
            atm.AddAccount(name, cardNumber, pin);
            MessageBox.Show("Обліковий запис успішно створено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            atm.Register(name, cardNumber, pin);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
