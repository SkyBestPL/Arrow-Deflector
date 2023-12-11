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
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        DispatcherTimer menuTimer = new DispatcherTimer();

        int przesuniecie = 0;

        public Menu()
        {
            InitializeComponent();
            Loaded += Menu_Loaded;

            ImageBrush tytul = new ImageBrush();
            tytul.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/title.png"));
            Title.Fill = tytul;

            ImageBrush arrowsTop = new ImageBrush();
            arrowsTop.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrows_menu_top.png"));
            ArrowsTop.Fill = arrowsTop;

            ImageBrush arrowsBottom = new ImageBrush();
            arrowsBottom.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrows_menu_bottom.png"));
            ArrowsBottom.Fill = arrowsBottom;

            Easy.Visibility = Visibility.Hidden;
            Normal.Visibility = Visibility.Hidden;
            Hard.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
            wybierzPoziom.Visibility = Visibility.Hidden;

            menuTimer.Interval = TimeSpan.FromMilliseconds(20);
            menuTimer.Tick += MenuLoop;
            menuTimer.Start();
        }

        private void MenuLoop(object sender, EventArgs e)
        {
            Canvas.SetLeft(ArrowsTop, Canvas.GetLeft(ArrowsTop) + 11);
            Canvas.SetLeft(ArrowsBottom, Canvas.GetLeft(ArrowsBottom) - 11);
            przesuniecie += 11;
            if(przesuniecie >= 165)
            {
                Canvas.SetLeft(ArrowsTop, Canvas.GetLeft(ArrowsTop) - 165);
                Canvas.SetLeft(ArrowsBottom, Canvas.GetLeft(ArrowsBottom) + 165);
                przesuniecie = 0;
            }
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            MenuScreen.Focus();
        }

        private void Graj_Click(object sender, RoutedEventArgs e)
        {
            ArrowsTop.Visibility = Visibility.Hidden;
            ArrowsBottom.Visibility = Visibility.Hidden;
            Graj.Visibility = Visibility.Hidden;
            Rankingi.Visibility = Visibility.Hidden;
            Pomoc.Visibility = Visibility.Hidden;
            Wyjdz.Visibility = Visibility.Hidden;

            Easy.Visibility = Visibility.Visible;
            Normal.Visibility = Visibility.Visible;
            Hard.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
            wybierzPoziom.Visibility = Visibility.Visible;
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game(1));
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game(2));
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game(3));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ArrowsTop.Visibility = Visibility.Visible;
            ArrowsBottom.Visibility = Visibility.Visible;
            Graj.Visibility = Visibility.Visible;
            Rankingi.Visibility = Visibility.Visible;
            Pomoc.Visibility = Visibility.Visible;
            Wyjdz.Visibility = Visibility.Visible;

            Easy.Visibility = Visibility.Hidden;
            Normal.Visibility = Visibility.Hidden;
            Hard.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
            wybierzPoziom.Visibility = Visibility.Hidden;
        }

        private void Rankingi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Ranking());
        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pomoc());
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnKeyDown_Menu(object sender, KeyEventArgs e)
        {
            
        }

        private void OnKeyUp_Menu(object sender, KeyEventArgs e)
        {

        }
    }
}
