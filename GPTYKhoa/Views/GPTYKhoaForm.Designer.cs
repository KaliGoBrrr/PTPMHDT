namespace GPTYKhoa.Views
{
    partial class GPTYKhoaForm
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
            userInputTextBox = new TextBox();
            analyzeButton = new Button();
            responseRichTextBox = new RichTextBox();
            historyListBox = new ListBox();
            newChatButton = new Button();
            saveChatButton = new Button();
            button2 = new Button();
            deleteChatButton = new Button();
            downloadChatButton = new Button();
            logoutButton = new Button();
            SuspendLayout();
            // 
            // userInputTextBox
            // 
            userInputTextBox.Location = new Point(203, 398);
            userInputTextBox.Multiline = true;
            userInputTextBox.Name = "userInputTextBox";
            userInputTextBox.ScrollBars = ScrollBars.Both;
            userInputTextBox.Size = new Size(423, 51);
            userInputTextBox.TabIndex = 0;
            userInputTextBox.TextChanged += userInputTextBox_TextChanged;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(632, 398);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(75, 23);
            analyzeButton.TabIndex = 1;
            analyzeButton.Text = "Gửi";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += analyzeButton_Click_1;
            // 
            // responseRichTextBox
            // 
            responseRichTextBox.Location = new Point(203, 12);
            responseRichTextBox.Name = "responseRichTextBox";
            responseRichTextBox.Size = new Size(585, 380);
            responseRichTextBox.TabIndex = 3;
            responseRichTextBox.Text = "";
            responseRichTextBox.TextChanged += responseRichTextBox_TextChanged;
            // 
            // historyListBox
            // 
            historyListBox.FormattingEnabled = true;
            historyListBox.ItemHeight = 15;
            historyListBox.Location = new Point(12, 12);
            historyListBox.Name = "historyListBox";
            historyListBox.Size = new Size(185, 409);
            historyListBox.TabIndex = 4;
            historyListBox.SelectedIndexChanged += historyListBox_SelectedIndexChanged_1;
            // 
            // newChatButton
            // 
            newChatButton.Location = new Point(122, 427);
            newChatButton.Name = "newChatButton";
            newChatButton.Size = new Size(75, 23);
            newChatButton.TabIndex = 5;
            newChatButton.Text = "Chat mới";
            newChatButton.UseVisualStyleBackColor = true;
            newChatButton.Click += newChatButton_Click;
            // 
            // saveChatButton
            // 
            saveChatButton.Location = new Point(713, 398);
            saveChatButton.Name = "saveChatButton";
            saveChatButton.Size = new Size(75, 23);
            saveChatButton.TabIndex = 6;
            saveChatButton.Text = "Lưu chat";
            saveChatButton.UseVisualStyleBackColor = true;
            saveChatButton.Click += saveChatButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(293, 376);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 7;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // deleteChatButton
            // 
            deleteChatButton.Location = new Point(12, 427);
            deleteChatButton.Name = "deleteChatButton";
            deleteChatButton.Size = new Size(75, 23);
            deleteChatButton.TabIndex = 8;
            deleteChatButton.Text = "Xóa chat";
            deleteChatButton.UseVisualStyleBackColor = true;
            deleteChatButton.Click += deleteChatButton_Click;
            // 
            // downloadChatButton
            // 
            downloadChatButton.Location = new Point(632, 426);
            downloadChatButton.Name = "downloadChatButton";
            downloadChatButton.Size = new Size(75, 23);
            downloadChatButton.TabIndex = 9;
            downloadChatButton.Text = "Tải xuống";
            downloadChatButton.UseVisualStyleBackColor = true;
            downloadChatButton.Click += downloadChatButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(713, 426);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 10;
            logoutButton.Text = "Đăng xuất";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // GPTYKhoaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(logoutButton);
            Controls.Add(downloadChatButton);
            Controls.Add(deleteChatButton);
            Controls.Add(button2);
            Controls.Add(saveChatButton);
            Controls.Add(newChatButton);
            Controls.Add(historyListBox);
            Controls.Add(responseRichTextBox);
            Controls.Add(analyzeButton);
            Controls.Add(userInputTextBox);
            Name = "GPTYKhoaForm";
            Text = "GPTYKhoaForm";
            Load += GPTYKhoaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userInputTextBox;
        private Button analyzeButton;
        private RichTextBox responseRichTextBox;
        private ListBox historyListBox;
        private Button newChatButton;
        private Button saveChatButton;
        private Button button2;
        private Button deleteChatButton;
        private Button downloadChatButton;
        private Button logoutButton;
    }
}