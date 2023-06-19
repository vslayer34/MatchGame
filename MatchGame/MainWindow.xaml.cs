using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;


        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;

            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10.0f).ToString("0.0s");

            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text += " - Play Again?";
            }
        }

        private void TimeTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                timeTextBlock.Text = "You WON!!!";
                Thread.Sleep(2000);
                SetUpGame();
            }
        }

        void SetUpGame()
        {
            List<string> animalEmojis = new List<string>(16)
            {
                "🐬", "🐬",
                "🐧", "🐧",
                "🐶", "🐶",
                "🦇", "🦇",
                
                "🦉", "🦉",
                "🦆", "🦆",
                "🕊️", "🕊️",
                "🐈‍", "🐈‍"
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int randomIndex = random.Next(animalEmojis.Count);
                string animal = animalEmojis[randomIndex];
                textBlock.Text = animal;
                animalEmojis.RemoveAt(randomIndex);
            }
        }

        TextBlock lastTextBlockClicked;
        bool isFindingMatch;

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (isFindingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                isFindingMatch = true;
            }
            else if (lastTextBlockClicked.Text == textBlock.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                isFindingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                isFindingMatch = false;
            }
        }
    }
}
