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

namespace FirstProject_W_F
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window


    {
        GameLogic game;

        public MainWindow()
        {
            InitializeComponent();
            game = new GameLogic();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            game.Start();
            for (int i = 0; i < 16; i++)
            {
                game.ShiftRandom();
               RefreshButtons();
            }
        }

        private void RefreshButtons()
        {
            for (int position = 0; position < 16; position++)
            {


                int number = game.GetNumber(position);
                button(position).Content = number.ToString();
                if (number > 0)
                    button(position).Visibility = Visibility.Visible;
                else if (number == 0)
                    button(position).Visibility = Visibility.Collapsed;

            }

        }
        private Button button(int position)
        {
            switch (position)
            {
                case 0: return Button0;
                case 1: return Button1;
                case 2: return Button2;
                case 3: return Button3;
                case 4: return Button4;
                case 5: return Button5;
                case 6: return Button6;
                case 7: return Button7;
                case 8: return Button8;

                case 9: return Button9;
                case 10: return Button10;
                case 11: return Button11;
                case 12: return Button12;
                case 13: return Button13;
                case 14: return Button14;

                case 15: return Button15;
                default: return Button0;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);
            game.Shift(position);
            RefreshButtons();
            if (game.CheckNumbers())
                MessageBox.Show("You win");
           // StartGame();
        }
    }
}
