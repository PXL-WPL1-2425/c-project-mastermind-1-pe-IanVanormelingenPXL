using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> colors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private List<string> Geheime_code = new List<string>();
        //De timer start en gaat van 10 naar 0.
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            GenerateGeheime_code();
            FillComboBoxes();
            timer.Start();
        }
        private void GenerateGeheime_code()
        {
            Random random = new Random();
            Geheime_code.Clear();

            for (int i = 0; i < 4; i++)
            {
                Geheime_code.Add(colors[random.Next(colors.Count)]);
            }


            this.Title = "Mastermind - Code: " + string.Join(", ", Geheime_code);
        }

        private void FillComboBoxes()
        {
            var comboBoxes = new List<ComboBox> { Kleurcode1, Kleurcode2, Kleurcode3, Kleurcode4 };

            foreach (var comboBox in comboBoxes)
            {
                comboBox.ItemsSource = colors;
                comboBox.SelectedIndex = -1;
            }
        }

        private void ComboBox_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox != null)
            {
                int labels = new List<Kleuren> { Kleur1, Kleur2, Kleur3, Kleur4 };
                labels.Content = comboBox.SelectedItem.ToString();
                labels.Borderbrush = Brushes.Gray;
                labels.Background = colors.Count;
            }

        }

        private int GetComboboxIndex(ComboBox comboBox)
        {
            if (comboBox == Kleurcode1) return 0;
            if (comboBox == Kleurcode2) return 1;
            if (comboBox == Kleurcode3) return 2;
            if (comboBox == Kleurcode4) return 3;
            return -1;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            {
                var guess = new List<string>
        {
            Kleurcode1.SelectedItem?.Tostring(),
            Kleurcode2.SelectedItem?.Tostring(),
            Kleurcode3.SelectedItem?.Tostring(),
            Kleurcode4.SelectedItem?.Tostring()
        };
                if (guess.Contains(null))
                {
                    MessageBox.Show("Selecteer alle kleuren voor dat je de knop drukt", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (var label in labels)
                {
                    label.BorderBrush = Brushes.Gray;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == Geheime_code[i])
                    {
                        labels[i].BorderBrush = Brushes.DarkRed;
                        Geheime_code[i] = null;
                        guess[i] = null;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] != null && Geheime_code.Contains(guess[i]))
                    {
                        labels[i].BorderBrush = Brushes.Wheat;
                        Geheime_code[Geheime_code.IndexOf(guess[i]) + 1] = null;
                    }
                }

               

            }
            

        }

        private void Total_atempts(object sender, EventArgs e)
        {
            if (Button_Click)
            {
                Total_atempts + 1;
            }
                

        }
        /// Toggledebug
        /// De Debug gaat open als je Ctrl+F12 indrukt.
        /// De debug laat de code zien als je de button indrukt
        private void toggledebug(object sender, EventArgs e)
        {
            if (KeyBinding ctrl + F12)
            {
                Show.Debug;

            }

            if (Button_Click)
            {
                GetHashCode;
            }



        }
        //Als de timer op 0 gaat wordt er een punt naar total atempts gegaan en wordt de timer reset.
        private void Timer_Tick(object sender, EventArgs e)
        {
            CountdownTimer.Enabled = true;
            if (timer = 0)
            {
                Total_atempts(+ 1);
                Reset.Timer;
            }
        }



    }
}
