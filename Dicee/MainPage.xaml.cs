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
        public int ScoreP1 = 0;
        public int ScoreP2 = 0;
        public int P1jackpot = 0;
        public int P2jackpot = 0;
        public int turnNum = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            Dice1.Text = $"{game.Roll()[0]}";
            Dice2.Text = $"{game.Roll()[1]}";
            turnNum++;

            if (turnNum == 10)
            {
                if (ScoreP1 == ScoreP2) {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog($"Tie game! With a score of {ScoreP1}");
                    message.ShowAsync();
                    P1Turn = false;
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    P1jackpot = 0;
                    P2jackpot = 0;
                    RollButton.Content = "Roll (Player 1)";
                    Dice1.Text = "0";
                    Dice2.Text = "0";
                    ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";
                    ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";
                    turnNum = 0;
                }
                else if (ScoreP1 > ScoreP2)
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog($"Player 1 Wins! With a score of {ScoreP1}");
                    message.ShowAsync();
                    P1Turn = false;
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    P1jackpot = 0;
                    P2jackpot = 0;
                    RollButton.Content = "Roll (Player 1)";
                    Dice1.Text = "0";
                    Dice2.Text = "0";
                    ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";
                    ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";
                    turnNum = 0;
                }
                else
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog($"Player 2 Wins! With a score of {ScoreP2}");
                    message.ShowAsync();
                    P1Turn = false;
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    P1jackpot = 0;
                    P2jackpot = 0;
                    RollButton.Content = "Roll (Player 1)";
                    Dice1.Text = "0";
                    Dice2.Text = "0";
                    ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";
                    ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";
                    turnNum = 0;
                }
            }

            if (P1Turn)
            {
                ScoreP1 += game.CaculateScore(P1jackpot);
                ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";

                RollButton.Content = "Roll (Player 2)";
                P1Turn = false;

                if (game.CaculateScore(P1jackpot) == 100)
                    P1jackpot = 1;
                else if (game.CaculateScore(P1jackpot) == 200)
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog("Double Jackpot!");
                    message.ShowAsync();
                    P1jackpot = 2;
                }
                else if (game.CaculateScore(P1jackpot) == 500)
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog($"Triple Jackpot! Player 1 Wins! With a score of {ScoreP1}");
                    message.ShowAsync();
                    P1Turn = false;
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    P1jackpot = 0;
                    P2jackpot = 0;
                    RollButton.Content = "Roll (Player 1)";
                    Dice1.Text = "0";
                    Dice2.Text = "0";
                    ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";
                    ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";
                }
                else
                    P1jackpot = 0;
            }
            else
            {
                ScoreP2 += game.CaculateScore(P2jackpot);
                ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";

                RollButton.Content = "Roll (Player 1)";
                P1Turn = true;

                if (game.CaculateScore(P2jackpot) == 100)
                    P2jackpot = 1;
                else if (game.CaculateScore(P2jackpot) == 200)
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog("Double Jackpot!");
                    message.ShowAsync();
                    P2jackpot = 2;
                }
                else if (game.CaculateScore(P2jackpot) == 500)
                {
                    Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog($"Triple Jackpot! Player 1 Wins! With a score of {ScoreP1}");
                    message.ShowAsync();
                    P1Turn = false;
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    P1jackpot = 0;
                    P2jackpot = 0;
                    RollButton.Content = "Roll (Player 1)";
                    Dice1.Text = "0";
                    Dice2.Text = "0";
                    ScoreP1Text.Text = $"Score (Player 1): {ScoreP1}";
                    ScoreP2Text.Text = $"Score (Player 2): {ScoreP2}";
                }
                else
                    P2jackpot = 0;
            }
        }
    }
}
