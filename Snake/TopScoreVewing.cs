using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class TopScoreVewing : Form
    {
        string s_name;
        string[] s_TopScore;
        

        public TopScoreVewing()
        {
            InitializeComponent();
            Shown += Score_vewer_opened;
        }

        private void Score_vewer_opened(object sender, EventArgs e)
        {
            
            Form1 F1 = new Form1();
            //tells witch scores are showing depending on speed
            if(Form1.i_speed == 100) { this.tab_TopScoreTable.GetControlFromPosition(0, 0).Text = "Top Scores(slow)"; }
            if (Form1.i_speed == 75) { this.tab_TopScoreTable.GetControlFromPosition(0, 0).Text = "Top Scores(average)"; }
            if (Form1.i_speed == 50) { this.tab_TopScoreTable.GetControlFromPosition(0, 0).Text = "Top Scores(fast)"; }

            //if the player just wants to look at the scores, it disables the button and text box so they cant try to put in a diffrent name.
            if (Form1.bol_justshowscores) { btt_NameSet.Enabled = false; txt_NameRecorder.Enabled = false; }
            else { btt_NameSet.Enabled = true; txt_NameRecorder.Enabled = true; MessageBox.Show("congrats on getting a top score, please enter a 3 letter name to place with your score"); }

            //opens approperate file depending on the speed
            if (Form1.i_speed == 100) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(slow).txt"); }
            if (Form1.i_speed == 75) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(average).txt"); }
            if (Form1.i_speed == 50) { s_TopScore = System.IO.File.ReadAllLines("Top Scores(fast).Txt"); }


            for (int i_Scorecount = 3, i_Count = 0; i_Scorecount <= 30; i_Scorecount += 3, i_Count++)
            {
                this.tab_TopScoreTable.GetControlFromPosition(2, 2 + i_Count).Text = s_TopScore[i_Scorecount];

            }
            for (int i_Scorecount = 2, i_Count = 0; i_Scorecount <= 30; i_Scorecount += 3, i_Count++)
            {
                this.tab_TopScoreTable.GetControlFromPosition(1, 2 + i_Count).Text = s_TopScore[i_Scorecount];

            }
            
            
        }
        private void btt_NameSet_Click(object sender, EventArgs e)
        {
            //when saving a name must be 3 caracters long, more a point of how it was back when video games where starting out
            Form1 F1 = new Form1();
            s_name = txt_NameRecorder.Text;
            if (s_name.Length != 3)
            {
                MessageBox.Show("oh im sorry but the name you want to give needs to be excatly 3");
            }
            else
            {
                this.tab_TopScoreTable.GetControlFromPosition(1, 1 + Form1.i_scorePosition).Text = s_name;
                s_TopScore[(Form1.i_scorePosition * 3) - 1] = s_name;
                // saves score file appropriately
                if (Form1.i_speed == 100) { System.IO.File.WriteAllLines("Top Scores(slow).txt", s_TopScore); }
                if (Form1.i_speed == 75) { System.IO.File.WriteAllLines("Top Scores(average).txt", s_TopScore); }
                if (Form1.i_speed == 50) { System.IO.File.WriteAllLines("Top Scores(fast).txt", s_TopScore); }
                DialogResult dialogResult = MessageBox.Show("Would you like to play again?", "Play again?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    F1.Show();
                    this.Close();
                }
                else { Application.Exit(); }

            }
        }
    }
}
