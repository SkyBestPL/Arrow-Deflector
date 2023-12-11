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
using System.Windows.Threading;

namespace KCK2
{
    /// <summary>
    /// Logika interakcji dla klasy Pomoc.xaml
    /// </summary>

    public partial class Pomoc : Page
    {
        DispatcherTimer pomocTimer = new DispatcherTimer();

        public Pomoc()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }

    /*public partial class Pomoc : Page
    {
        DispatcherTimer pomocTimer = new DispatcherTimer();
        int licznik = 0;
        int i = 2;
        public Pomoc()
        {
            InitializeComponent();

            pomocTimer.Interval = TimeSpan.FromMilliseconds(20);
            pomocTimer.Tick += PomocLoop;
            pomocTimer.Start();

            klatka1.Visibility = Visibility.Visible;
            klatka2.Visibility = Visibility.Hidden;
            klatka3.Visibility = Visibility.Hidden;
            klatka4.Visibility = Visibility.Hidden;
            klatka5.Visibility = Visibility.Hidden;
            klatka6.Visibility = Visibility.Hidden;
        }
        private void PomocLoop(object sender, EventArgs e)
        {
            licznik++;

            if (licznik % 8 == 0)
            {
                switch (i)
                {
                    case 1:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc1.png"));
                        break;
                    case 2:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc2.png"));
                        break;
                    case 3:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc3.png"));
                        break;
                    case 4:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc4.png"));
                        break;
                    case 5:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc5.png"));
                        break;
                    case 6:
                        klatka1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Pomoc/pomoc6.png"));
                        break;
                    default:
                        i = 0;
                        break;
                }

                i++;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

    }*/

    /*public partial class Pomoc : Page
    {
        List<BitmapImage> klatkiAnimacji = new List<BitmapImage>();
        int licznik = 0;
        BitmapImage klatka;
        ImageBrush klatkaBrush;
        int i = 0;

        DispatcherTimer pomocTimer = new DispatcherTimer();

        public Pomoc()
        {
            InitializeComponent();

            // Inicjalizacja klatkaBrush
            klatkaBrush = new ImageBrush();

            for (int i = 1; i <= 6; i++)
            {
                klatka = new BitmapImage(new Uri($"pack://application:,,,/Images/Pomoc/pomoc{i}.png"));
                klatkiAnimacji.Add(klatka);
            }

            pomocTimer.Interval = TimeSpan.FromMilliseconds(20);
            pomocTimer.Tick += PomocLoop;
            pomocTimer.Start();
        }

        private void PomocLoop(object sender, EventArgs e)
        {
            licznik++;
            if (licznik % 5 == 0)
            {
                klatkaBrush.ImageSource = klatkiAnimacji[i];
                Animacja.Fill = klatkaBrush;
                i++;
                if (i > 5) i = 0;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }*/
}
