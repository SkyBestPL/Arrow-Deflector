using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KCK2
{
    internal class Player
    {
        public ImageBrush positionLeft { get; private set; }
        public ImageBrush positionRight { get; private set; }
        public ImageBrush positionTop { get; private set; }
        public ImageBrush positionBottom { get; private set; }

        public ImageBrush positionDead { get; private set; }

        public ImageBrush health3 { get; private set; }
        public ImageBrush health2 { get; private set; }
        public ImageBrush health1 { get; private set; }

        public int position = 1;
        public int health = 3;

        public Player()
        {
            positionLeft = new ImageBrush();
            positionLeft.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/player_left.png"));

            positionRight = new ImageBrush();
            positionRight.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/player_right.png"));

            positionTop = new ImageBrush();
            positionTop.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/player_up.png"));

            positionBottom = new ImageBrush();
            positionBottom.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/player_down.png"));


            positionDead = new ImageBrush();
            positionDead.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/player_dead.png"));


            health3 = new ImageBrush();
            health3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Health/health-3.png"));
            
            health2 = new ImageBrush();
            health2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Health/health-2.png"));

            health1 = new ImageBrush();
            health1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Health/health-1.png"));
        }

        public int getPosition()
        {
            return position;
        }
    }
}

