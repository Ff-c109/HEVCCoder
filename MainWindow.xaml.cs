using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HEVCCoder2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        string workPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HEVC編碼的視頻(*.mp4) | *.mp4";
            if (ofd.ShowDialog() != true)
            {
                MessageBox.Show("嗯？視頻呢？？");
                return;
            }
            inputFilePath.Text = ofd.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.Compare (inputFilePath.Text, "Path") == 0)
            {
                MessageBox.Show("你似乎并沒有選擇輸入視頻呢");
                return;
            }
            if (string.Compare(outputFilePath.Text, "Path") == 0)
            {
                MessageBox.Show("你似乎并沒有選擇輸出視頻呢");
                return;
            }
            string fileOutput;
            fileOutput = "task" + num + ";" + inputFilePath.Text + "&" + outputFilePath.Text + "\n";
            string inputBuffer;
            string outputBuffer;
            if (num == 0)
            {
                File.WriteAllText(workPath + "tasks.dat", fileOutput);
                num++;
                return;
            }
            inputBuffer = File.ReadAllText(workPath + "tasks.dat");
            outputBuffer = inputBuffer + fileOutput;
            File.WriteAllText(workPath + "tasks.dat", outputBuffer);
            num++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string workPath = System.AppDomain.CurrentDomain.BaseDirectory;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HEVC編碼的視頻(*.mp4) | *.mp4";
            if (sfd.ShowDialog() != true)
            {
                MessageBox.Show("嗯？視頻呢？？");
                return;
            }
            outputFilePath.Text = sfd.FileName;
        }

        private void inputFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 wd1 = new Window1();
            wd1.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
