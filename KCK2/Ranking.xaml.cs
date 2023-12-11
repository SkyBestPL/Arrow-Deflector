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

namespace KCK2
{
    /// <summary>
    /// Logika interakcji dla klasy Ranking.xaml
    /// </summary>
    public partial class Ranking : Page
    {

        public Ranking()
        {
            InitializeComponent();

            string[] fileName = new string[3];
            fileName[0] = "easy_scores.txt";
            fileName[1] = "medium_scores.txt";
            fileName[2] = "hard_scores.txt";

            List<string> linesEasy = File.ReadAllLines(fileName[0]).ToList();
            List<string> sortedLinesEasy = linesEasy.OrderByDescending(line => int.Parse(line.Split('|')[0])).ToList();
            List<RankingEntry> entriesEasy = sortedLinesEasy.Select(line =>
            {
                var parts = line.Split('|');
                return new RankingEntry
                {
                    Score = int.Parse(parts[0]),
                    PlayerName = parts[1]
                };
            }).ToList();

            EasyRankingListBox.ItemsSource = entriesEasy;

            List<string> linesMedium = File.ReadAllLines(fileName[1]).ToList();
            List<string> sortedLinesMedium = linesMedium.OrderByDescending(line => int.Parse(line.Split('|')[0])).ToList();
            List<RankingEntry> entriesMedium = sortedLinesMedium.Select(line =>
            {
                var parts = line.Split('|');
                return new RankingEntry
                {
                    Score = int.Parse(parts[0]),
                    PlayerName = parts[1]
                };
            }).ToList();

            MediumRankingListBox.ItemsSource = entriesMedium;

            List<string> linesHard = File.ReadAllLines(fileName[2]).ToList();
            List<string> sortedLinesHard = linesHard.OrderByDescending(line => int.Parse(line.Split('|')[0])).ToList();
            List<RankingEntry> entriesHard = sortedLinesHard.Select(line =>
            {
                var parts = line.Split('|');
                return new RankingEntry
                {
                    Score = int.Parse(parts[0]),
                    PlayerName = parts[1]
                };
            }).ToList();

            HardRankingListBox.ItemsSource = entriesHard;
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }

    public class RankingEntry
    {
        public int Score { get; set; }
        public string PlayerName { get; set; }
    }
}
