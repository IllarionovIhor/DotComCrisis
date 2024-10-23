namespace WinFormsApp
{
    partial class Form_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_put = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.button_withdraw = new System.Windows.Forms.Button();
            this.button_transfer = new System.Windows.Forms.Button();
            this.button_balance = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_put
            // 
            this.button_put.Location = new System.Drawing.Point(147, 270);
            this.button_put.Name = "button_put";
            this.button_put.Size = new System.Drawing.Size(102, 66);
            this.button_put.TabIndex = 0;
            this.button_put.Text = "Поповнити баланс";
            this.button_put.UseVisualStyleBackColor = true;
            this.button_put.Click += new System.EventHandler(this.button_put_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_info.Location = new System.Drawing.Point(147, 133);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(94, 25);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label_info";
            // 
            // button_withdraw
            // 
            this.button_withdraw.Location = new System.Drawing.Point(267, 198);
            this.button_withdraw.Name = "button_withdraw";
            this.button_withdraw.Size = new System.Drawing.Size(102, 66);
            this.button_withdraw.TabIndex = 2;
            this.button_withdraw.Text = "Зняти кошти";
            this.button_withdraw.UseVisualStyleBackColor = true;
            this.button_withdraw.Click += new System.EventHandler(this.button_withdraw_Click);
            // 
            // button_transfer
            // 
            this.button_transfer.Location = new System.Drawing.Point(267, 270);
            this.button_transfer.Name = "button_transfer";
            this.button_transfer.Size = new System.Drawing.Size(102, 66);
            this.button_transfer.TabIndex = 3;
            this.button_transfer.Text = "Переказ на картку";
            this.button_transfer.UseVisualStyleBackColor = true;
            this.button_transfer.Click += new System.EventHandler(this.button_transfer_Click);
            // 
            // button_balance
            // 
            this.button_balance.Location = new System.Drawing.Point(147, 198);
            this.button_balance.Name = "button_balance";
            this.button_balance.Size = new System.Drawing.Size(102, 66);
            this.button_balance.TabIndex = 4;
            this.button_balance.Text = "Перевірити баланс";
            this.button_balance.UseVisualStyleBackColor = true;
            this.button_balance.Click += new System.EventHandler(this.button_balance_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(208, 342);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(102, 32);
            this.button_logout.TabIndex = 5;
            this.button_logout.Text = "Вийти";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 459);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_balance);
            this.Controls.Add(this.button_transfer);
            this.Controls.Add(this.button_withdraw);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button_put);
            this.Name = "Form_Menu";
            this.Text = "AutomatedTellerMachine - Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Menu_FormClosed);
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_put;
        private Label label_info;
        private Button button_withdraw;
        private Button button_transfer;
        private Button button_balance;
        private Button button_logout;
    }
}