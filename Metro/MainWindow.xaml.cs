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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Save_file() {

            // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.
            // You can modify the path if necessary.


            // Example #1: Write an array of strings to a file.
            // Create a string array that consists of three lines.
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);


            // Example #2: Write one string to a text file.
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

            // Example #3: Write only some strings in an array to a file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
            // encodes the output as text.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            // Example #4: Append new text to an existing file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
            {
                file.WriteLine("Fourth line");
            }
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {

        }

 

 
        // **********************************************************************************
    }
}
