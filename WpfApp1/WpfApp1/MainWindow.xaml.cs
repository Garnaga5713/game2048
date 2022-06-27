using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] arr;
        TextBlock[,] textBlocks;
        Random rnd = new Random();

        private void game_reset()
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public MainWindow()
        {
            InitializeComponent();
            arr = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            textBlocks = new TextBlock[4, 4] { { b11, b21, b31, b41 }, { b12, b22, b32, b42 }, { b13, b23, b33, b43 }, { b14, b24, b34, b44 } };
            MessageBox.Show("Control: button up,down,right,left");
        }


        private void res_Click(object sender, RoutedEventArgs e)
        {
            game_reset();
        }

       
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (arr[i, j] != 0)
                            {

                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = arr[i, j];
                                    arr[i, j] = 0;
                                }
                               else 
                                {
                                      if (arr[i - 1, j] == arr[i, j])
                                      {
                                        arr[i - 1, j] = 2 * arr[i-1, j];
                                        arr[i, j] = 0;
                                      }
                                }
                            }
                        }
                    }
                }

                int spawn_ind = rnd.Next(0,4);
                bool flag = true;

                while (flag)
                {
                    if (arr[3, spawn_ind] != 0)
                    { spawn_ind = rnd.Next(0, 4); flag = false; }
                    else arr[3, spawn_ind] = 2;
                }
            }
            else if (e.Key == Key.Down)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (arr[i, j] != 0)
                            {

                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = arr[i, j];
                                    arr[i, j] = 0;
                                }
                                else if (arr[i + 1, j] != 0)
                                {
                                    if (arr[i + 1, j] == arr[i, j])
                                    {
                                        arr[i + 1, j] = 2 * arr[i, j];
                                        arr[i, j] = 0;
                                    }
                                }
                            }
                        }
                    }
                }

                
                int spawn_ind = rnd.Next(0, 4);
                bool flag = true;

                while (flag)
                {
                    if (arr[0, spawn_ind] != 0)
                    { spawn_ind = rnd.Next(0, 4); flag = false; }
                    else arr[0, spawn_ind] = 2;
                }

            }
            else if (e.Key == Key.Right) 
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (arr[i, j] != 0)
                            {

                                if (arr[i , j+1] == 0)
                                {
                                    arr[i , j+1] = arr[i, j];
                                    arr[i, j] = 0;
                                }
                                else if (arr[i , j+1] != 0)
                                {
                                    if (arr[i , j+1] == arr[i, j])
                                    {
                                        arr[i , j+1] = 2 * arr[i, j];
                                        arr[i, j] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                
                int spawn_ind = rnd.Next(0, 4);
                bool flag = true;

                while (flag)
                {
                    if (arr[spawn_ind, 0] != 0)
                    { spawn_ind = rnd.Next(0, 4); flag = false; }
                    else arr[spawn_ind, 0] = 2;
                }
            }
            else if (e.Key == Key.Left) 
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            if (arr[i, j] != 0)
                            {

                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = arr[i, j];
                                    arr[i, j] = 0;
                                }
                                else if (arr[i, j - 1] != 0)
                                {
                                    if (arr[i, j - 1] == arr[i, j])
                                    {
                                        arr[i, j - 1] = 2 * arr[i, j-1];
                                        arr[i, j] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                

                int spawn_ind = rnd.Next(0, 4);
                bool flag = true;

                while (flag)
                {
                    if (arr[spawn_ind, 3] != 0)
                    { spawn_ind = rnd.Next(0, 4); flag = false; }
                    else arr[spawn_ind, 3] = 2;
                }
            }
            change();
        }
        private void change()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i, j] == 0) { textBlocks[i, j].Text = ""; }
                    else 
                    {
                        textBlocks[i, j].Text = arr[i, j].ToString();
                    }
                    

                    if (arr[i, j] == 2) { textBlocks[i, j].Background = new SolidColorBrush(Colors.AliceBlue); }
                    else if (arr[i, j] == 4) { textBlocks[i, j].Background = new SolidColorBrush(Colors.AntiqueWhite); }
                    else if (arr[i, j] == 8) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Beige); }
                    else if (arr[i, j] == 16) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Bisque); }
                    else if (arr[i, j] == 32) { textBlocks[i, j].Background = new SolidColorBrush(Colors.BurlyWood); }
                    else if (arr[i, j] == 64) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Coral); }
                    else if (arr[i, j] == 128) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Chocolate); }
                    else if (arr[i, j] == 256) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Brown); }
                    else if (arr[i, j] == 512) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Crimson); }
                    else if (arr[i, j] == 1024) { textBlocks[i, j].Background = new SolidColorBrush(Colors.DarkGoldenrod); }
                    else if (arr[i, j] == 2048) { textBlocks[i, j].Background = new SolidColorBrush(Colors.DarkKhaki); }
                    else if (arr[i, j] == 0) { textBlocks[i, j].Background = new SolidColorBrush(Colors.Azure); }
                    

                    
                }
            }
        }
    }
}
