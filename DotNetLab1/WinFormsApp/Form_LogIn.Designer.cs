namespace WinFormsApp
{
    partial class Form_LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_login = new Button();
            textbox_card = new TextBox();
            label_card = new Label();
            textbox_pin = new TextBox();
            label_pin = new Label();
            label_login = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // button_login
            // 
            button_login.Location = new Point(317, 173);
            button_login.Margin = new Padding(3, 2, 3, 2);
            button_login.Name = "button_login";
            button_login.Size = new Size(92, 22);
            button_login.TabIndex = 0;
            button_login.Text = "Увійти";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // textbox_card
            // 
            textbox_card.Location = new Point(317, 112);
            textbox_card.Margin = new Padding(3, 2, 3, 2);
            textbox_card.Name = "textbox_card";
            textbox_card.Size = new Size(132, 23);
            textbox_card.TabIndex = 1;
            // 
            // label_card
            // 
            label_card.AutoSize = true;
            label_card.Location = new Point(169, 112);
            label_card.Name = "label_card";
            label_card.Size = new Size(128, 15);
            label_card.TabIndex = 2;
            label_card.Text = "Введіть номер картки:";
            // 
            // textbox_pin
            // 
            textbox_pin.Location = new Point(317, 136);
            textbox_pin.Margin = new Padding(3, 2, 3, 2);
            textbox_pin.Name = "textbox_pin";
            textbox_pin.Size = new Size(132, 23);
            textbox_pin.TabIndex = 3;
            // 
            // label_pin
            // 
            label_pin.AutoSize = true;
            label_pin.Location = new Point(230, 139);
            label_pin.Name = "label_pin";
            label_pin.Size = new Size(73, 15);
            label_pin.TabIndex = 4;
            label_pin.Text = "Введіть ПІН:";
            // 
            // label_login
            // 
            label_login.AutoSize = true;
            label_login.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label_login.Location = new Point(260, 50);
            label_login.Name = "label_login";
            label_login.Size = new Size(148, 30);
            label_login.TabIndex = 5;
            label_login.Text = "Авторизація";
            // 
            // button1
            // 
            button1.Location = new Point(317, 199);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(92, 22);
            button1.TabIndex = 6;
            button1.Text = "Реєстрація";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form_LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 344);
            Controls.Add(button1);
            Controls.Add(label_login);
            Controls.Add(label_pin);
            Controls.Add(textbox_pin);
            Controls.Add(label_card);
            Controls.Add(textbox_card);
            Controls.Add(button_login);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(718, 383);
            MinimumSize = new Size(718, 383);
            Name = "Form_LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AutomatedTellerMachine - Log In";
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_login;
        private TextBox textbox_card;
        private Label label_card;
        private TextBox textbox_pin;
        private Label label_pin;
        private Label label_login;
        private Button button1;
    }
}