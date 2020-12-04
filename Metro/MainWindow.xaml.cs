using MahApps.Metro.Controls;
using Microsoft.Win32;
using Ownskit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metro
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        KeyboardListener KListener = new KeyboardListener();

        public MainWindow()
        {
            InitializeComponent();

            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);

            //mDataGrid
            var data = new Test { Test1 = "Test1", Test2 = "Test2" };

            mDataGrid.Items.Add(data);
        }

        public class Test
        {
            public string Test1 { get; set; }
            public string Test2 { get; set; }
        }

        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            KListener.Dispose();

            if (args.ToString().Equals("1"))// Get key
            {
                // do someting...
               
                    

            }

            // Restart
            KListener = new KeyboardListener();
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);

            Console.WriteLine(args.Key.ToString());
            // Prints the text of pressed button, takes in account big and small letters. E.g. "Shift+a" => "A"
            Console.WriteLine(args.ToString());
        }

       
        private void Btn_open_Click(object sender, RoutedEventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();

            try
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                //Read the contents of the file into a stream
                StreamReader reader = new StreamReader(filePath);

                // ReadToEnd
                //fileContent = reader.ReadToEnd();
                //Text_main.Text = fileContent;

                // ReadLine()
                int counter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    Text_main.Text = Text_main.Text+ line + '\n';
                    counter++;
                }  
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }

        }
    }
}
