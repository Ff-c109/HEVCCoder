using Microsoft.Win32;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace HEVCCoder2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string workPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public Window1()
        {
            InitializeComponent();
        }
        private void list_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(workPath + "tasks.dat"))
            {
                string[] inputBuffer = File.ReadAllLines(workPath + "tasks.dat");
                for (int i = 0; i < inputBuffer.Length; i++)
                {
                    list.Text += (inputBuffer[i] + "\n");
                }
            }
            else
            {
                MessageBox.Show("然而你并没有添加任何任务到列表。。。。");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(workPath + "tasks.dat"))
            {
                MessageBox.Show("没有任何要处理的任务呢");
                return;
            }
            string[] inputBuffer = File.ReadAllLines(workPath + "tasks.dat");
            string[] taskNameandTask = {" ", " " };
            string[] inTaskandoutTask = { " ", " " };
            for (int i = 0; i < inputBuffer.Length; i++)
            {
                taskNameandTask = inputBuffer[i].Split(';');
                inTaskandoutTask = taskNameandTask[1].Split('&');

                //Process proc = Process.Start(workPath + "ffmpeg.exe", "-i " + inTaskandoutTask[0] + " -vcodec h264 " + inTaskandoutTask[1]);
                if (File.Exists(inTaskandoutTask[1]))
                    File.Delete(inTaskandoutTask[1]);
                Process proc = Process.Start("ffmpeg\\ffmpeg.exe", "-i " + inTaskandoutTask[0] + " -vcodec h264 " + inTaskandoutTask[1]);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
            MessageBox.Show("全部渲染綫程已退出");
            File.Delete(workPath + "tasks.dat");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ffmpeg.exe | ffmpeg.exe";
            if(ofd.ShowDialog() != true)
            {
                MessageBox.Show("你似乎沒有選擇文件");
                return;
            }
            File.Copy(ofd.FileName, workPath + "ffmpeg.exe", false);
            ofd.Filter = "ffmpeg.sln | ffmpeg.sln";
            if (ofd.ShowDialog() != true)
            {
                MessageBox.Show("你似乎沒有選擇文件");
                return;
            }
            File.Copy(ofd.FileName, workPath + "ffmpeg.sln", false);
        }
    }
}
