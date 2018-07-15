namespace Snake
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_score = new System.Windows.Forms.Label();
            this.btn_Slow = new System.Windows.Forms.Button();
            this.btn_average = new System.Windows.Forms.Button();
            this.btn_fast = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_show = new System.Windows.Forms.Label();
            this.btn_showscorefast = new System.Windows.Forms.Button();
            this.btn_showscoreaverage = new System.Windows.Forms.Button();
            this.btn_showscoreslow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(24, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 402);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Location = new System.Drawing.Point(201, 443);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(47, 13);
            this.lbl_score.TabIndex = 2;
            this.lbl_score.Text = "Score: 1";
            // 
            // btn_Slow
            // 
            this.btn_Slow.Location = new System.Drawing.Point(82, 505);
            this.btn_Slow.Name = "btn_Slow";
            this.btn_Slow.Size = new System.Drawing.Size(90, 39);
            this.btn_Slow.TabIndex = 3;
            this.btn_Slow.Text = "Slow";
            this.btn_Slow.UseVisualStyleBackColor = true;
            this.btn_Slow.Click += new System.EventHandler(this.btn_Slow_Click);
            // 
            // btn_average
            // 
            this.btn_average.Location = new System.Drawing.Point(178, 505);
            this.btn_average.Name = "btn_average";
            this.btn_average.Size = new System.Drawing.Size(90, 39);
            this.btn_average.TabIndex = 4;
            this.btn_average.Text = "average";
            this.btn_average.UseVisualStyleBackColor = true;
            this.btn_average.Click += new System.EventHandler(this.btn_average_Click);
            // 
            // btn_fast
            // 
            this.btn_fast.Location = new System.Drawing.Point(274, 505);
            this.btn_fast.Name = "btn_fast";
            this.btn_fast.Size = new System.Drawing.Size(90, 39);
            this.btn_fast.TabIndex = 5;
            this.btn_fast.Text = "Fast";
            this.btn_fast.UseVisualStyleBackColor = true;
            this.btn_fast.Click += new System.EventHandler(this.btn_fast_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "select speed to start new game";
            // 
            // lab_show
            // 
            this.lab_show.AutoSize = true;
            this.lab_show.Location = new System.Drawing.Point(173, 564);
            this.lab_show.Name = "lab_show";
            this.lab_show.Size = new System.Drawing.Size(99, 13);
            this.lab_show.TabIndex = 7;
            this.lab_show.Text = "show top scores for";
            // 
            // btn_showscorefast
            // 
            this.btn_showscorefast.Location = new System.Drawing.Point(274, 591);
            this.btn_showscorefast.Name = "btn_showscorefast";
            this.btn_showscorefast.Size = new System.Drawing.Size(90, 39);
            this.btn_showscorefast.TabIndex = 10;
            this.btn_showscorefast.Text = "Fast";
            this.btn_showscorefast.UseVisualStyleBackColor = true;
            this.btn_showscorefast.Click += new System.EventHandler(this.btn_showscorefast_Click);
            // 
            // btn_showscoreaverage
            // 
            this.btn_showscoreaverage.Location = new System.Drawing.Point(178, 591);
            this.btn_showscoreaverage.Name = "btn_showscoreaverage";
            this.btn_showscoreaverage.Size = new System.Drawing.Size(90, 39);
            this.btn_showscoreaverage.TabIndex = 9;
            this.btn_showscoreaverage.Text = "average";
            this.btn_showscoreaverage.UseVisualStyleBackColor = true;
            this.btn_showscoreaverage.Click += new System.EventHandler(this.btn_showscoreaverage_Click);
            // 
            // btn_showscoreslow
            // 
            this.btn_showscoreslow.Location = new System.Drawing.Point(82, 591);
            this.btn_showscoreslow.Name = "btn_showscoreslow";
            this.btn_showscoreslow.Size = new System.Drawing.Size(90, 39);
            this.btn_showscoreslow.TabIndex = 8;
            this.btn_showscoreslow.Text = "Slow";
            this.btn_showscoreslow.UseVisualStyleBackColor = true;
            this.btn_showscoreslow.Click += new System.EventHandler(this.btn_showscoreslow_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(454, 649);
            this.Controls.Add(this.btn_showscorefast);
            this.Controls.Add(this.btn_showscoreaverage);
            this.Controls.Add(this.btn_showscoreslow);
            this.Controls.Add(this.lab_show);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_fast);
            this.Controls.Add(this.btn_average);
            this.Controls.Add(this.btn_Slow);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Button btn_Slow;
        private System.Windows.Forms.Button btn_average;
        private System.Windows.Forms.Button btn_fast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_show;
        private System.Windows.Forms.Button btn_showscorefast;
        private System.Windows.Forms.Button btn_showscoreaverage;
        private System.Windows.Forms.Button btn_showscoreslow;
    }
}

