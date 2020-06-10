namespace Riptide
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TurnIdent = new System.Windows.Forms.Label();
            this.ShipBox = new System.Windows.Forms.ComboBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ReadyBtn = new System.Windows.Forms.Button();
            this.YourFleet = new System.Windows.Forms.PictureBox();
            this.EnemyFleet = new System.Windows.Forms.PictureBox();
            this.YourFleetLabel = new System.Windows.Forms.Label();
            this.EnemyFleetLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YourFleet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyFleet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.TurnIdent);
            this.panel1.Controls.Add(this.ShipBox);
            this.panel1.Controls.Add(this.ExitBtn);
            this.panel1.Controls.Add(this.ReadyBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1233, 74);
            this.panel1.TabIndex = 0;
            // 
            // TurnIdent
            // 
            this.TurnIdent.AutoSize = true;
            this.TurnIdent.BackColor = System.Drawing.Color.Transparent;
            this.TurnIdent.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TurnIdent.ForeColor = System.Drawing.Color.Black;
            this.TurnIdent.Location = new System.Drawing.Point(455, 19);
            this.TurnIdent.Name = "TurnIdent";
            this.TurnIdent.Size = new System.Drawing.Size(204, 29);
            this.TurnIdent.TabIndex = 7;
            this.TurnIdent.Text = "Place your ships";
            // 
            // ShipBox
            // 
            this.ShipBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShipBox.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShipBox.FormattingEnabled = true;
            this.ShipBox.Items.AddRange(new object[] {
            "boat",
            "corvette",
            "frigate",
            "cruiser"});
            this.ShipBox.Location = new System.Drawing.Point(171, 23);
            this.ShipBox.Name = "ShipBox";
            this.ShipBox.Size = new System.Drawing.Size(208, 27);
            this.ShipBox.TabIndex = 0;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Firebrick;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.Font = new System.Drawing.Font("Myanmar Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitBtn.Location = new System.Drawing.Point(984, 3);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(184, 68);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Surrender";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ReadyBtn
            // 
            this.ReadyBtn.BackColor = System.Drawing.Color.Green;
            this.ReadyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReadyBtn.Font = new System.Drawing.Font("Myanmar Text", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReadyBtn.ForeColor = System.Drawing.Color.Black;
            this.ReadyBtn.Location = new System.Drawing.Point(783, 3);
            this.ReadyBtn.Name = "ReadyBtn";
            this.ReadyBtn.Size = new System.Drawing.Size(184, 68);
            this.ReadyBtn.TabIndex = 6;
            this.ReadyBtn.Text = "Ready";
            this.ReadyBtn.UseVisualStyleBackColor = false;
            this.ReadyBtn.Click += new System.EventHandler(this.ReadyBtn_Click);
            // 
            // YourFleet
            // 
            this.YourFleet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YourFleet.BackgroundImage")));
            this.YourFleet.Location = new System.Drawing.Point(50, 129);
            this.YourFleet.Name = "YourFleet";
            this.YourFleet.Size = new System.Drawing.Size(493, 455);
            this.YourFleet.TabIndex = 1;
            this.YourFleet.TabStop = false;
            this.YourFleet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.YourFleet_MouseClick);
            this.YourFleet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.YourFleet_MouseDoubleClick);
            // 
            // EnemyFleet
            // 
            this.EnemyFleet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnemyFleet.BackgroundImage")));
            this.EnemyFleet.Location = new System.Drawing.Point(685, 129);
            this.EnemyFleet.Name = "EnemyFleet";
            this.EnemyFleet.Size = new System.Drawing.Size(493, 455);
            this.EnemyFleet.TabIndex = 2;
            this.EnemyFleet.TabStop = false;
            this.EnemyFleet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnemyFleet_MouseClick);
            // 
            // YourFleetLabel
            // 
            this.YourFleetLabel.AutoSize = true;
            this.YourFleetLabel.BackColor = System.Drawing.Color.Transparent;
            this.YourFleetLabel.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YourFleetLabel.ForeColor = System.Drawing.Color.White;
            this.YourFleetLabel.Location = new System.Drawing.Point(217, 82);
            this.YourFleetLabel.Name = "YourFleetLabel";
            this.YourFleetLabel.Size = new System.Drawing.Size(121, 29);
            this.YourFleetLabel.TabIndex = 3;
            this.YourFleetLabel.Text = "Your fleet";
            // 
            // EnemyFleetLabel
            // 
            this.EnemyFleetLabel.AutoSize = true;
            this.EnemyFleetLabel.BackColor = System.Drawing.Color.Transparent;
            this.EnemyFleetLabel.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnemyFleetLabel.ForeColor = System.Drawing.Color.White;
            this.EnemyFleetLabel.Location = new System.Drawing.Point(863, 82);
            this.EnemyFleetLabel.Name = "EnemyFleetLabel";
            this.EnemyFleetLabel.Size = new System.Drawing.Size(147, 29);
            this.EnemyFleetLabel.TabIndex = 4;
            this.EnemyFleetLabel.Text = "Enemy fleet";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(566, 201);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(566, 250);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1233, 628);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EnemyFleetLabel);
            this.Controls.Add(this.YourFleetLabel);
            this.Controls.Add(this.EnemyFleet);
            this.Controls.Add(this.YourFleet);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1255, 679);
            this.MinimumSize = new System.Drawing.Size(1255, 679);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Riptide";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YourFleet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyFleet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox YourFleet;
        private System.Windows.Forms.PictureBox EnemyFleet;
        private System.Windows.Forms.Label YourFleetLabel;
        private System.Windows.Forms.Label EnemyFleetLabel;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.ComboBox ShipBox;
        private System.Windows.Forms.Button ReadyBtn;
        private System.Windows.Forms.Label TurnIdent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}