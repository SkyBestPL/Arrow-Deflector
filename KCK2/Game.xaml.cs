using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KCK2
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Page
    { 
        DispatcherTimer gameTimer = new DispatcherTimer();
        
        Random random = new Random();
        Player player = new Player();

        int shootingCounter = 100;
        int gameCounter = 0;
        int score = 0;
        int health = 3;
        int difficulty;
        int limit = 20;
        int lastBow = 0;
        int bow = 0;
        int speed = 8;
        bool GAMEOVER = false;
        int deflectCounter = 0;
        private Transform originalDeflect;
        bool pause = false;

        private List<Arrow> strzaly = new List<Arrow>();

        Rect playerHitbox;

        public Game(int dif)
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            GameScreen.Focus();

            difficulty = dif;

            Health.Fill = player.health3;

            Pauza.Visibility = Visibility.Hidden;

            limitText.Visibility = Visibility.Hidden;
            speedText.Visibility = Visibility.Hidden;
            timeText.Visibility = Visibility.Hidden;

            GameOver.Visibility = Visibility.Hidden;
            Tak.Visibility = Visibility.Hidden;
            Nie.Visibility = Visibility.Hidden;
            question.Visibility = Visibility.Hidden;

            typeName.Visibility = Visibility.Hidden;
            ImieTextBox.Visibility = Visibility.Hidden;
            Zatwierdz.Visibility = Visibility.Hidden;

            saveResult.Visibility = Visibility.Hidden;

            if(difficulty == 1)
            {
                bowTop.Visibility = Visibility.Hidden;
                bowBottom.Visibility = Visibility.Hidden;
            }
            else if(difficulty == 2) { bowBottom.Visibility = Visibility.Hidden; }

            PlayAgain.Visibility = Visibility.Hidden;
            BackToMenu.Visibility = Visibility.Hidden;

            ImageBrush Tutorial = new ImageBrush();
            Tutorial.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/tutorial.png"));
            tutorial.Fill = Tutorial;

            ImageBrush Deflect = new ImageBrush();
            Deflect.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/deflect.png"));
            deflect.Fill = Deflect;
            deflect.Visibility = Visibility.Hidden;
            originalDeflect = deflect.RenderTransform.Clone();

            SetPosition(player.positionLeft);

            strzaly.Add(new Arrow(1, 3, 44, 23, false, GameScreen, 1));
            strzaly.Add(new Arrow(1, 3, 44, 23, false, GameScreen, 2));
            strzaly.Add(new Arrow(3, 3, 62, 23, false, GameScreen, 1));
            strzaly.Add(new Arrow(3, 3, 62, 23, false, GameScreen, 2));
            strzaly.Add(new Arrow(2, 3, 59, 16, false, GameScreen, 1));
            strzaly.Add(new Arrow(2, 3, 59, 16, false, GameScreen, 2));
            strzaly.Add(new Arrow(4, 3, 59, 26, false, GameScreen, 1));
            strzaly.Add(new Arrow(4, 3, 59, 26, false, GameScreen, 2));

            if (difficulty > 1)
            {

            }
            if (difficulty > 2)
            {

            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitbox = new Rect(Canvas.GetLeft(Gracz), Canvas.GetTop(Gracz), Gracz.Width, Gracz.Height);

            shootingCounter -= 1;
            gameCounter++;

            UpdateGameSpeed();

            scoreText.Content = "Odbite strzały: " + score;
            speedText.Content = "Speed: " + speed;
            limitText.Content = "Limit: " + limit;
            timeText.Content = "Time: " + gameCounter;

            if(gameCounter == 100)
            {
                tutorial.Visibility = Visibility.Hidden;
            }

            if(deflectCounter > 0)
            {
                deflectCounter++;
            }
            if (deflectCounter == 6)
            {
                deflectCounter = 0;
                deflect.Visibility = Visibility.Hidden;
                deflect.RenderTransform = originalDeflect;
            }

            if (shootingCounter < 0 && GAMEOVER==false)
            {
                StrzelajStrzaly();
                shootingCounter = limit;
            }
            else if (GAMEOVER == false)
            {
                CheckHit();

                foreach (var strzala in strzaly)
                {
                    if (strzala.shooting == true && strzala.side == 1) { strzala.UpdateLeft(speed); }
                    if (strzala.shooting == true && strzala.side == 3) { strzala.UpdateRight(speed); }
                    if (strzala.shooting == true && strzala.side == 2) { strzala.UpdateTop(speed); }
                    if (strzala.shooting == true && strzala.side == 4) { strzala.UpdateBottom(speed); }
                }
            }
            else
            {

            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (GAMEOVER==false && pause != true)
            {
                if (e.Key == Key.Left || e.Key == Key.A)
                {
                    player.position = 1;
                    SetPosition(player.positionLeft);
                }
                if (e.Key == Key.Right || e.Key == Key.D)
                {
                    player.position = 3;
                    SetPosition(player.positionRight);
                }
                if (e.Key == Key.Up || e.Key == Key.W)
                {
                    player.position = 2;
                    SetPosition(player.positionTop);
                }
                if (e.Key == Key.Down || e.Key == Key.S)
                {
                    player.position = 4;
                    SetPosition(player.positionBottom);
                }
            }
            if (e.Key == Key.Escape && GAMEOVER != true)
            {
                if (pause == false)
                {
                    pause = true;
                    gameTimer.Stop();
                    Pauza.Visibility = Visibility.Visible;
                }
                else if (pause == true)
                {
                    pause = false;
                    gameTimer.Start();
                    Pauza.Visibility = Visibility.Hidden;
                }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Tak_Click(object sender, RoutedEventArgs e)
        {
            Tak.Visibility = Visibility.Hidden;
            Nie.Visibility = Visibility.Hidden;
            question.Visibility = Visibility.Hidden;

            typeName.Visibility = Visibility.Visible;
            ImieTextBox.Visibility = Visibility.Visible;
            Zatwierdz.Visibility = Visibility.Visible;
        }

        private void Nie_Click(object sender, RoutedEventArgs e)
        {
            Tak.Visibility = Visibility.Hidden;
            Nie.Visibility = Visibility.Hidden;
            question.Visibility = Visibility.Hidden;

            PlayAgain.Visibility = Visibility.Visible;
            BackToMenu.Visibility = Visibility.Visible;
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            typeName.Visibility = Visibility.Hidden;
            ImieTextBox.Visibility = Visibility.Hidden;
            Zatwierdz.Visibility = Visibility.Hidden;

            string username = ImieTextBox.Text;
            string fileName = "";

            if (difficulty == 1) { fileName = "easy_scores.txt"; }
            else if (difficulty == 2) { fileName = "medium_scores.txt"; }
            else if (difficulty == 3) { fileName = "hard_scores.txt"; }

            if (username == "")
            {
                username = "Nieznany Gracz";
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine(score + "|" + username);
                }

                SortScores(fileName);


            }
            catch (Exception y)
            {
                saveResult.Content = y.Message;
            }

            saveResult.Visibility = Visibility.Visible;
            BackToMenu.Visibility = Visibility.Visible;
            PlayAgain.Visibility = Visibility.Visible;
        }

        private static void SortScores(string fileName)
        {
            try
            {
                List<string> lines = File.ReadAllLines(fileName).ToList();
                List<string> sortedLines = lines.OrderByDescending(line => int.Parse(line.Split('|')[0])).ToList();

                File.WriteAllLines(fileName, sortedLines);
            }
            catch (Exception e)
            {
                Console.WriteLine("Zapis nieudany." + e);
            }
        }

        private void UpdateGameSpeed()
        {
            if (limit > 8 && gameCounter % 300 == 0) limit--;
            if (gameCounter % 600 == 0) speed++;
        }

        private void StrzelajStrzaly()
        {
            if (lastBow == 2) { lastBow = 3; }
            else if (lastBow == 3) { lastBow = 2; }

            if (lastBow != 0)
            {
                bow = random.Next(1, difficulty + 2);
                if (bow == lastBow)
                {
                    bow = random.Next(1, difficulty + 2);
                    if (bow == lastBow) { bow = random.Next(1, difficulty + 2); }
                }
            }
            else
            { bow = random.Next(1, difficulty + 2); }

            if(bow == 2) { bow = 3; }
            else if(bow == 3) {  bow = 2; }

            lastBow = bow;

            foreach (var strzala in strzaly.Where(a => a.side == bow))
            {
                if (!strzala.shooting)
                {
                    strzala.Shoot();
                    break;
                }
            }
        }

        private void SetPosition(ImageBrush imageBrush)
        {
            Gracz.Fill = imageBrush;
        }

        private void RenderDeflect(int x)
        {
            if (x==1) //Left
            {
                Canvas.SetTop(deflect, 427);
                Canvas.SetLeft(deflect, 305);
                deflect.RenderTransform = new RotateTransform(270);
                deflect.Visibility = Visibility.Visible;
                deflectCounter = 1;
            }
            else if (x == 3) //Right
            {
                Canvas.SetTop(deflect, 367);
                Canvas.SetLeft(deflect, 525);
                deflect.RenderTransform = new RotateTransform(90);
                deflect.Visibility = Visibility.Visible;
                deflectCounter = 1;
            }
            else if (x == 2) //Top
            {
                Canvas.SetTop(deflect, 297);
                Canvas.SetLeft(deflect, 385);
                deflect.RenderTransform = new RotateTransform(0);
                deflect.Visibility = Visibility.Visible;
                deflectCounter = 1;
            }
            else if (x == 4) //Bottom
            {
                Canvas.SetTop(deflect, 517);
                Canvas.SetLeft(deflect, 445);
                deflect.RenderTransform = new RotateTransform(180);
                deflect.Visibility = Visibility.Visible;
                deflectCounter = 1;
            }
        }

        private void UpdateHealth()
        {
            health--;
            if (health == 2)
            { Health.Fill = player.health2; }
            else if (health == 1)
            { Health.Fill = player.health1; }
            else if (health == 0)
            { Health.Visibility = Visibility.Hidden; KoniecGry(); }
        }

        private void KoniecGry()
        {
            GAMEOVER = true;
            Gracz.Width = 150;
            Gracz.Fill = player.positionDead;
            Canvas.SetTop(Gracz, 380);
            Canvas.SetLeft(Gracz, 342);

            foreach(var strzala in strzaly)
            {
                strzala.arrowObject.Visibility = Visibility.Hidden;
            }

            ImageBrush gameover = new ImageBrush();
            gameover.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/GAMEOVER.png"));

            GameOver.Fill = gameover;
            GameOver.Visibility = Visibility.Visible;
            Tak.Visibility = Visibility.Visible;
            Nie.Visibility = Visibility.Visible;
            Canvas.SetTop(scoreText, 330);
            Canvas.SetLeft(scoreText, 300);
            scoreText.FontSize = 24;
            question.Visibility = Visibility.Visible;

            gameTimer.Stop();


        }

        private void CheckHit()
        {
            foreach (var strzala in strzaly)
            {
                var arrowRect = new Rect(Canvas.GetLeft(strzala.arrowObject), Canvas.GetTop(strzala.arrowObject), strzala.arrowObject.Width, strzala.arrowObject.Height);

                if (playerHitbox.IntersectsWith(arrowRect))
                {
                    if (player.position == strzala.side)
                    {
                        score++;
                        RenderDeflect(strzala.side);
                    }
                    else
                    {
                        UpdateHealth();
                    }

                    if (strzala.side == 1)
                    {
                        strzala.ResetLeft();
                    }
                    else if (strzala.side == 3)
                    {
                        strzala.ResetRight();
                    }
                    else if (strzala.side == 2)
                    {
                        strzala.ResetTop();
                    }
                    else { strzala.ResetBottom(); }
                }
            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game(difficulty));
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}
