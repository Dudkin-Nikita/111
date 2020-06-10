namespace Riptide
{
    partial class SyncInForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncInForm));
            this.GameName = new System.Windows.Forms.Label();
            this.FindBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.BackColor = System.Drawing.Color.Transparent;
            this.GameName.Cursor = System.Windows.Forms.Cursors.Default;
            this.GameName.Font = new System.Drawing.Font("News701 BT", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameName.ForeColor = System.Drawing.Color.White;
            this.GameName.Location = new System.Drawing.Point(-1, 106);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(384, 68);
            this.GameName.TabIndex = 0;
            this.GameName.Text = "Crush your opponent as a\r\ncaptain of your fleet";
            this.GameName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FindBtn
            // 
            this.FindBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FindBtn.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindBtn.ForeColor = System.Drawing.Color.Navy;
            this.FindBtn.Location = new System.Drawing.Point(51, 177);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(319, 116);
            this.FindBtn.TabIndex = 1;
            this.FindBtn.Text = "Find an opponent";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitBtn.Font = new System.Drawing.Font("Myanmar Text", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuitBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.QuitBtn.Location = new System.Drawing.Point(34, 312);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(319, 93);
            this.QuitBtn.TabIndex = 2;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutBtn.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutBtn.Location = new System.Drawing.Point(51, 12);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(319, 63);
            this.AboutBtn.TabIndex = 3;
            this.AboutBtn.Text = "About";
            this.AboutBtn.UseVisualStyleBackColor = true;
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // SyncInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(413, 500);
            this.Controls.Add(this.AboutBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.FindBtn);
            this.Controls.Add(this.GameName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 551);
            this.MinimumSize = new System.Drawing.Size(435, 551);
            this.Name = "SyncInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riptide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameName;
        private System.Windows.Forms.Button FindBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button AboutBtn;
    }
}

