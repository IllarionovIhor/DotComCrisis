namespace WinFormsApp
{
    partial class Form_input
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
            this.textbox_input = new System.Windows.Forms.TextBox();
            this.label_text = new System.Windows.Forms.Label();
            this.button_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox_input
            // 
            this.textbox_input.Location = new System.Drawing.Point(47, 81);
            this.textbox_input.Name = "textbox_input";
            this.textbox_input.Size = new System.Drawing.Size(185, 27);
            this.textbox_input.TabIndex = 0;
            // 
            // label_text
            // 
            this.label_text.AutoSize = true;
            this.label_text.Location = new System.Drawing.Point(47, 32);
            this.label_text.Name = "label_text";
            this.label_text.Size = new System.Drawing.Size(73, 20);
            this.label_text.TabIndex = 1;
            this.label_text.Text = "label_text";
            // 
            // button_accept
            // 
            this.button_accept.Location = new System.Drawing.Point(79, 129);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(121, 29);
            this.button_accept.TabIndex = 2;
            this.button_accept.Text = "Підтвердити";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // Form_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 188);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.label_text);
            this.Controls.Add(this.textbox_input);
            this.MinimumSize = new System.Drawing.Size(299, 235);
            this.Name = "Form_input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Введення";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_input_FormClosed);
            this.Load += new System.EventHandler(this.Form_input_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textbox_input;
        private Label label_text;
        private Button button_accept;
    }
}