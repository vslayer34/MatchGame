using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
    }
}
