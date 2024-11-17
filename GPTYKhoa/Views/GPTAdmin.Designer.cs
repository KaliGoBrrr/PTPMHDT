namespace GPTYKhoa.Views
{
    partial class GPTAdmin
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
            userDataGridView = new DataGridView();
            username = new TextBox();
            email = new TextBox();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            roleComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            logoutButton = new Button();
            ((System.ComponentModel.ISupportInitialize)userDataGridView).BeginInit();
            SuspendLayout();
            // 
            // userDataGridView
            // 
            userDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDataGridView.Location = new Point(12, 173);
            userDataGridView.Name = "userDataGridView";
            userDataGridView.Size = new Size(473, 240);
            userDataGridView.TabIndex = 0;
            userDataGridView.CellContentClick += userDataGridView_CellContentClick;
            // 
            // username
            // 
            username.Location = new Point(167, 44);
            username.Name = "username";
            username.Size = new Size(237, 23);
            username.TabIndex = 1;
            username.TextChanged += username_TextChanged;
            // 
            // email
            // 
            email.Location = new Point(167, 73);
            email.Name = "email";
            email.Size = new Size(237, 23);
            email.TabIndex = 3;
            email.TextChanged += email_TextChanged;
            // 
            // addButton
            // 
            addButton.Location = new Point(167, 419);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 4;
            addButton.Text = "Tạo";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(248, 419);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 5;
            updateButton.Text = "Cập nhật";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(329, 419);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Xóa";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(167, 102);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(237, 23);
            roleComboBox.TabIndex = 7;
            roleComboBox.SelectedIndexChanged += roleComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 47);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 8;
            label1.Text = "Tài khoản :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 76);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 9;
            label2.Text = "Gmail       :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 105);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 10;
            label3.Text = "Role          :";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(411, 419);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 11;
            logoutButton.Text = "Đăng xuất";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // GPTAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 450);
            Controls.Add(logoutButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(roleComboBox);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(email);
            Controls.Add(username);
            Controls.Add(userDataGridView);
            Name = "GPTAdmin";
            Text = "GPTAdmin";
            Load += GPTAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)userDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView userDataGridView;
        private TextBox username;
        private TextBox email;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private ComboBox roleComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button logoutButton;
    }
}