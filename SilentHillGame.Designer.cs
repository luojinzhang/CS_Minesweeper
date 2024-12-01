namespace Silent_Hill
{
    partial class SilentHillGame
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
            this.NewGame = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(766, 108);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(183, 76);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "Retry";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.Retry_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(766, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 76);
            this.button1.TabIndex = 1;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.New_Click);
            // 
            // Clock
            // 
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(664, 41);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(40, 13);
            this.time.TabIndex = 2;
            this.time.Text = "Clock: ";
            // 
            // SilentHillGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 560);
            this.Controls.Add(this.time);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SilentHillGame";
            this.Text = "SilentHillGame";
            this.Load += new System.EventHandler(this.SilentHillGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Label time;
    }
}