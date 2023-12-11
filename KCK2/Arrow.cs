using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KCK2
{
    class Arrow
    {
        public ImageBrush arrow { get; private set; }

        public int side;
        public int speed;
        public int endX;
        public int endY;
        public bool shooting;
        public Canvas gameScreen;
        public Rectangle arrowObject;
        public int nr;

        public int topBottom = 0;

        public Arrow(int z, int s, int e, int f, bool sh, Canvas canvas, int nr)
        {
            side = z;
            speed = s;
            endX = e;
            endY = f;
            shooting = sh;
            gameScreen = canvas;
            this.nr = nr;

            if (side == 1)
            {
                arrow = new ImageBrush();
                arrow.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrow_left.png"));
                Rectangle strzala = new Rectangle
                {
                    Tag = "arrowLeft"+nr,
                    Height = 25,
                    Width = 110,
                    Fill = arrow
                };
                strzala.Visibility = Visibility.Hidden;
                Canvas.SetTop(strzala, 380);
                Canvas.SetLeft(strzala, 20);
                arrowObject = strzala;
                canvas.Children.Add(strzala);
            }

            if (side == 3)
            {
                arrow = new ImageBrush();
                arrow.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrow_right.png"));
                Rectangle strzala = new Rectangle
                {
                    Tag = "arrowRight"+nr,
                    Height = 25,
                    Width = 110,
                    Fill = arrow
                };
                strzala.Visibility = Visibility.Hidden;
                Canvas.SetTop(strzala, 380);
                Canvas.SetLeft(strzala, 690);
                arrowObject = strzala;
                canvas.Children.Add(strzala);
            }

            if (side == 2)
            {
                arrow = new ImageBrush();
                arrow.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrow_top.png"));
                Rectangle strzala = new Rectangle
                {
                    Tag = "arrowTop"+nr,
                    Height = 110,
                    Width = 25,
                    Fill = arrow
                };
                strzala.Visibility = Visibility.Hidden;
                Canvas.SetTop(strzala, 20);
                Canvas.SetLeft(strzala, 400);
                arrowObject = strzala;
                canvas.Children.Add(strzala);
            }

            if (side == 4)
            {
                arrow = new ImageBrush();
                arrow.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Arrows/arrow_bottom.png"));
                Rectangle strzala = new Rectangle
                {
                    Tag = "arrowBottom"+nr,
                    Height = 110,
                    Width = 25,
                    Fill = arrow
                };
                strzala.Visibility = Visibility.Hidden;
                Canvas.SetTop(strzala, 670);
                Canvas.SetLeft(strzala, 400);
                arrowObject = strzala;
                canvas.Children.Add(strzala);
            }
        }

        public void UpdateLeft(int speed)
        {
            Canvas.SetLeft(arrowObject, Canvas.GetLeft(arrowObject) + speed);
        }

        public void UpdateRight(int speed)
        {
            Canvas.SetLeft(arrowObject, Canvas.GetLeft(arrowObject) - speed);
        }

        public void UpdateTop(int speed)
        {
            Canvas.SetTop(arrowObject, Canvas.GetTop(arrowObject) + speed);
        }

        public void UpdateBottom(int speed)
        {
            Canvas.SetTop(arrowObject, Canvas.GetTop(arrowObject) - speed);
        }

        public void Shoot()
        {
            arrowObject.Visibility = Visibility.Visible;
            shooting = true;
        }

        public void ResetLeft()
        {
            arrowObject.Visibility = Visibility.Hidden;
            Canvas.SetTop(arrowObject, 380);
            Canvas.SetLeft(arrowObject, 20);
            shooting = false;
        }

        public void ResetRight()
        {
            arrowObject.Visibility = Visibility.Hidden;
            Canvas.SetTop(arrowObject, 380);
            Canvas.SetLeft(arrowObject, 690);
            shooting = false;
        }

        public void ResetTop()
        {
            arrowObject.Visibility = Visibility.Hidden;
            Canvas.SetTop(arrowObject, 20);
            Canvas.SetLeft(arrowObject, 400);
            shooting = false;
        }

        public void ResetBottom()
        {
            arrowObject.Visibility = Visibility.Hidden;
            Canvas.SetTop(arrowObject, 670);
            Canvas.SetLeft(arrowObject, 400);
            shooting = false;
        }

        /*
        public void SetArrow(int x, int y, int z, int s, bool sh)
        {
            PositionX = x;
            PositionY = y;
            side = z;
            speed = s;
            shooting = sh;
        }

        public void UpdateLeft()
        { Console.SetCursorPosition(PositionX, PositionY); Program.Render(asciiArrowLeft); PositionX = PositionX + speed; }
        public void UpdateRight()
        { Console.SetCursorPosition(PositionX, PositionY); Program.Render(asciiArrowRight); PositionX = PositionX - speed; }
        public void UpdateTop(int shootingCounter)
        {
            if (shootingCounter % 3 == 0) { speed = 1; } else { speed = 0; }
            Console.SetCursorPosition(PositionX, PositionY); Program.Render(asciiArrowTop); PositionY = PositionY + speed;
        }
        public void UpdateBottom(int shootingCounter)
        {
            if (shootingCounter % 3 == 0) { speed = 1; } else { speed = 0; }
            Console.SetCursorPosition(PositionX, PositionY); Program.Render(asciiArrowBottom); PositionY = PositionY - speed;
        }

        public void CheckLeft(Player player)
        {
            if (PositionX >= endX && shooting == true)
            {
                shooting = false;
                Console.SetCursorPosition(PositionX, PositionY);
                Program.Render(asciiArrowLeftBlank);
                CheckHit(player);
            }
        }
        public void CheckRight(Player player)
        {
            if (PositionX <= endX && shooting == true)
            {
                shooting = false;
                Console.SetCursorPosition(PositionX + 1, PositionY);
                Program.Render(asciiArrowLeftBlank);
                CheckHit(player);
            }
        }
        public void CheckTop(Player player)
        {
            if (PositionY >= endY && shooting == true)
            {
                shooting = false;
                Console.SetCursorPosition(PositionX, PositionY);
                Program.Render(asciiArrowTopBlank);
                CheckHit(player);
            }
        }
        public void CheckBottom(Player player)
        {
            if (PositionY <= endY && shooting == true)
            {
                shooting = false;
                Console.SetCursorPosition(PositionX, PositionY + 1);
                Program.Render(asciiArrowTopBlank);
                CheckHit(player);
            }
        }

        public void CheckHit(Player player)
        {
            string animacjaOdbiciaLeft;
            string animacjaOdbiciaRight;
            string animacjaOdbiciaTop;
            string animacjaOdbiciaBottom;

            animacjaOdbiciaLeft = @"

 \
-
 /
 ";
            animacjaOdbiciaRight = @"

/
 -
\
 ";
            animacjaOdbiciaTop = @"
\ | /
";
            animacjaOdbiciaBottom = @"
/ | \
";


            if (player.Position == side)
            {
                Program.score++;
                if (Program.sleep != 1) { Program.sleep--; }
                if (Program.score == 50) { speed = 2; }
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (side == 1) { Console.SetCursorPosition(player.PositionX - 2, player.PositionY - 1); Program.Render(animacjaOdbiciaLeft); }
                else if (side == 2) { Console.SetCursorPosition(player.PositionX + 7, player.PositionY - 1); Program.Render(animacjaOdbiciaRight); }
                else if (side == 3) { Console.SetCursorPosition(player.PositionX + 1, player.PositionY - 1); ; Program.Render(animacjaOdbiciaTop); }
                else if (side == 4) { Console.SetCursorPosition(player.PositionX + 1, player.PositionY + 5); Program.Render(animacjaOdbiciaBottom); }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(80, 0);
                player.Health--;
                if (player.Health == 2) { Program.Render(player.asciiPlayerHeart2); }
                else if (player.Health == 1) { Program.Render(player.asciiPlayerHeart1); }
                else if (player.Health <= 0) { Program.Render(player.asciiPlayerHeartNone); Program.gameOver = true; }
                Console.ResetColor();
            }
        }*/
    }
}
