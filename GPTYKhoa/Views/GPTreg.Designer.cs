namespace GPTYKhoa.Views
{
    partial class GPTreg
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
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            registerButton = new Button();
            backToLoginButton = new Button();
            label1 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(146, 136);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(156, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(146, 165);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(156, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(146, 194);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(156, 23);
            emailTextBox.TabIndex = 2;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(146, 223);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 3;
            registerButton.Text = "Đăng ký";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click_1;
            // 
            // backToLoginButton
            // 
            backToLoginButton.Location = new Point(227, 223);
            backToLoginButton.Name = "backToLoginButton";
            backToLoginButton.Size = new Size(75, 23);
            backToLoginButton.TabIndex = 4;
            backToLoginButton.Text = "Đăng nhập";
            backToLoginButton.UseVisualStyleBackColor = true;
            backToLoginButton.Click += backToLoginButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 139);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 5;
            label1.Text = "Tài khoản :";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 168);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 6;
            label2.Text = "Mật khẩu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 197);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 7;
            label3.Text = "Gmail       :";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(384, 71);
            label4.TabIndex = 8;
            label4.Text = "Đăng ký";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GPTreg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(backToLoginButton);
            Controls.Add(registerButton);
            Controls.Add(emailTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "GPTreg";
            Text = "GPTreg";
            Load += GPTreg_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private Button registerButton;
        private Button backToLoginButton;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}