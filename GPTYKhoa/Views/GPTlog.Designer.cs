namespace GPTYKhoa.Views
{
    partial class GPTlog
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
            loginButton = new Button();
            goToRegisterButton = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(148, 149);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(156, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(148, 178);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(156, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(148, 207);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 2;
            loginButton.Text = "Đăng nhập";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click_1;
            // 
            // goToRegisterButton
            // 
            goToRegisterButton.Location = new Point(229, 207);
            goToRegisterButton.Name = "goToRegisterButton";
            goToRegisterButton.Size = new Size(75, 23);
            goToRegisterButton.TabIndex = 3;
            goToRegisterButton.Text = "Đăng ký";
            goToRegisterButton.UseVisualStyleBackColor = true;
            goToRegisterButton.Click += goToRegisterButton_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 181);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 8;
            label2.Text = "Mật khẩu :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 152);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 7;
            label1.Text = "Tài khoản :";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(384, 70);
            label3.TabIndex = 9;
            label3.Text = "Đăng nhập";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GPTlog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(goToRegisterButton);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "GPTlog";
            Text = "GPTlog";
            Load += GPTlog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button goToRegisterButton;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}