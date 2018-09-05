using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if ((playlist.Items.Count !=0)&&(playlist.SelectedIndex != -1))
            {
                string current = CS.Vars.Files[playlist.SelectedIndex];
                CS.BassLike.Play(current, CS.BassLike.Volume);
                label1.Text = TimeSpan.FromSeconds(CS.BassLike.GetPosOfStream(CS.BassLike.Stream)).ToString();
                label2.Text = TimeSpan.FromSeconds(CS.BassLike.GetTimeOfStream(CS.BassLike.Stream)).ToString();
                slTime.Maximum = CS.BassLike.GetTimeOfStream(CS.BassLike.Stream);
                slTime.Value = CS.BassLike.GetPosOfStream(CS.BassLike.Stream);
                timer1.Enabled = true;
            }
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            CS.BassLike.Stop();
            timer1.Enabled = false;
            slTime.Value = 0;
            label1.Text = "00:00:00";
        }

        private void slTime_Scroll(object sender, ScrollEventArgs e)
        {
            CS.BassLike.SetPosOfScroll(CS.BassLike.Stream, slTime.Value);
        }

        private void slVol_Scroll(object sender, ScrollEventArgs e)
        {
            CS.BassLike.SetVolumToStream(CS.BassLike.Stream, slVol.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            CS.Vars.Files.Add(openFileDialog2.FileName);
            playlist.Items.Add(CS.Vars.GetFileName(openFileDialog2.FileName));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = TimeSpan.FromSeconds(CS.BassLike.GetPosOfStream(CS.BassLike.Stream)).ToString();
            slTime.Value = CS.BassLike.GetPosOfStream(CS.BassLike.Stream);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            CS.BassLike.Pause();
        }
    }
}
