using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace music2
{
    public partial class Form1 : Form
    {
        string[] files;
        List<string> LocalmusicList = new List<string>();
        WaveOutEvent waveOut = new WaveOutEvent();
        public Form1()
        {
            InitializeComponent();
        }
        private void musicplay(string filename)
        {
            string extension = Path.GetExtension(filename);
            if (extension == ".ogg")
            {
                Console.WriteLine("this is ogg file");
            }
            else
            {
                Console.WriteLine("this is not ogg file");
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LocalmusicList.Count > 0||LocalmusicList==null)
            {
                axWindowsMediaPlayer1.URL = LocalmusicList[listBox1.SelectedIndex];
                if (!File.Exists(axWindowsMediaPlayer1.URL))
                {
                    throw new FileNotFoundException("The audio file does not exist.", axWindowsMediaPlayer1.URL);
                }
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(LocalmusicList[listBox1.SelectedIndex]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            label2.Text = "音量：" + trackBar1.Value + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "选择音频|*mp3;*.wav;*.flac";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                waveOut.Stop();
                waveOut.Volume = 0;
                listBox1.Items.Clear();
                if (files != null)
                {
                    Array.Clear(files, 0, files.Length);
                }
                files = openFileDialog1.FileNames;
                LocalmusicList.Clear();
                string[] array = files;
                foreach (string x in array)
                {
                    LocalmusicList.Add(x);
                    listBox1.Items.Add(Path.GetFileName(x));
                }
                //listBox1.Text = openFileDialog1.FileName;   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {

            }
            else
            {
                int nextIndex = listBox1.SelectedIndex + 1;
                if (LocalmusicList.Count > 0)

                    if (nextIndex >= LocalmusicList.Count)
                    {
                        nextIndex = 0;
                    }
                axWindowsMediaPlayer1.URL = LocalmusicList[nextIndex];
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(LocalmusicList[nextIndex]);
                listBox1.SelectedIndex = nextIndex;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState==PlaybackState.Stopped)
                axWindowsMediaPlayer1.Ctlcontrols.play();
            else axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        //
        private void button6_Click(object sender, EventArgs e)
        {
            string oggFilePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "播放音频|*.ogg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.close();
                LocalmusicList.Clear() ;
                oggFilePath = openFileDialog.FileName;
                listBox1.Items.Clear();
                listBox1.Items.Add(Path.GetFileName(oggFilePath));
                label1.Text = Path.GetFileNameWithoutExtension(Path.GetFileName(oggFilePath));
                VorbisWaveReader vorbisReader = new VorbisWaveReader(oggFilePath);
                if(waveOut!=null)
                    waveOut.Dispose();
                waveOut.Init(vorbisReader);
                waveOut.Play();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Pause();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState != PlaybackState.Playing && LocalmusicList.Count==0)
            {
                waveOut.Play();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string path;
            openFileDialog1 = new OpenFileDialog();
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                path = openFileDialog1.FileName;
                BackgroundImage = Image.FromFile(path);
            }
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            waveOut.Volume = trackBar2.Value;
            if (trackBar2.Value == 0)
                label3.Text = "已关闭声音";
            else label3.Text = "已开启声音";
        }
    }
}
