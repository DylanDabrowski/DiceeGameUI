using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dicee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public bool P1Turn = true;
        int ScoreP1 = 0;
        int ScoreP2 = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            Dice1.Text = $"{game.Roll()[0]}";
            Dice2.Text = $"{game.Roll()[1]}";

            if (P1Turn)
            {
                ScoreP1 += game.CaculateScore();
                ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";

                RollButton.Content = "Roll (Player 2)";
                P1Turn = false;
            }
            else
            {
                ScoreP2 += game.CaculateScore();
                ScoreP2Text.Text = $"Score (Player 1): {ScoreP2}";

                RollButton.Content = "Roll (Player 1)";
                P1Turn = true;
            }
        }
    }
}
