using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

#pragma warning disable CS8604
#pragma warning disable CS8602 
namespace LCOpickem
{

    public partial class Pickems : Window
    {
        private Image[] LeftsideTeams = new Image[3];
        private Image[] RightsideTeams = new Image[4];
        private Image[] LimagesGameCompleted = new Image[4];
        private Image[] RimagesGameCompleted = new Image[4];
        private Button[] LeftsideButtons = new Button[4];
        private Button[] RightsideButtons = new Button[4];
        private Rectangle[] LeftWinLossRectangle = new Rectangle[4];
        private Rectangle[] RightWinLossRectangle = new Rectangle[4];


        public Pickems()
        {
            InitializeComponent();
            AddBasicHandlers();
            UpdateSelection();
        }

        public void AddBasicHandlers()
        {
            LeftWinLossRectangle = new Rectangle[] { RLeft1, RLeft2, RLeft3, RLeft4 };
            RightWinLossRectangle = new Rectangle[] { RRight1, RRight2, RRight3, RRight4 };
            LeftsideTeams = new Image[] { Left1P, Left2P, Left3P, Left4P };
            RightsideTeams = new Image[] { Right1P, Right2P, Right3P, Right4P };
            LimagesGameCompleted = new Image[] { Left1EndPic, Left2EndPic, Left3EndPic, Left4EndPic };
            RimagesGameCompleted = new Image[] { Right1EndPic, Right2EndPic, Right3EndPic, Right4EndPic };
            LeftsideButtons = new Button[] { Left1, Left2, Left3, Left4 };
            RightsideButtons = new Button[] { Right1, Right2, Right3, Right4 };
        }



        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void LoadTeams(string[] Playing)
        {
            string source = Global.SourceString;
            for (int i = 0; i < Playing.Length; i++)
            {
                string[] game = Playing[i].Split('/');
                LeftsideTeams[i].Source = new BitmapImage(new Uri(source + game[0] + ".png", UriKind.Relative));
                RightsideTeams[i].Source = new BitmapImage(new Uri(source + game[1] + ".png", UriKind.Relative));
            }
        }

        #region Picks

        private bool Canvote()
        {
            //TODO: STARTED
            return true;
        }

        private static string? onepick;

        private void R1(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            onepick = "right";
            RLeft1.Visibility = Visibility.Hidden;
            RRight1.Visibility = Visibility.Visible;
            UpdatePicks();

        }
        private void L1(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            onepick = "left";
            RRight1.Visibility = Visibility.Hidden;
            RLeft1.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private static string? twopick;
        private void R2(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            twopick = "right";
            RLeft2.Visibility = Visibility.Hidden;
            RRight2.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private void L2(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            twopick = "left";
            RRight2.Visibility = Visibility.Hidden;
            RLeft2.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private static string? threepick;
        private void R3(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }

            threepick = "right";
            RLeft3.Visibility = Visibility.Hidden;
            RRight3.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private void L3(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            threepick = "left";
            RRight3.Visibility = Visibility.Hidden;
            RLeft3.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private static string? fourpick;
        private void R4(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            fourpick = "right";
            RLeft4.Visibility = Visibility.Hidden;
            RRight4.Visibility = Visibility.Visible;
            UpdatePicks();
        }
        private void L4(object sender, RoutedEventArgs e)
        {
            if (!Canvote() || TryGetResults())
            {
                return;
            }
            fourpick = "left";
            RRight4.Visibility = Visibility.Hidden;
            RLeft4.Visibility = Visibility.Visible;
            UpdatePicks();
        }

        private void Dayone(object sender, RoutedEventArgs e)
        {
            Global.Playday = 1;
            UpdateSelection();
        }
        private void Daytwo(object sender, RoutedEventArgs e)
        {
            Global.Playday = 2;
            UpdateSelection();
        }
        private void ClearPrev()
        {
            SolidColorBrush myBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0F2440"));

            for (int i = 0; i < RightsideTeams.Length; i++)
            {
                try
                {

                    LimagesGameCompleted[i].Visibility = Visibility.Hidden;
                    RimagesGameCompleted[i].Visibility = Visibility.Hidden;
                }
                catch
                {

                }
                LeftsideButtons[i].Visibility = Visibility.Visible;
                RightsideButtons[i].Visibility = Visibility.Visible;
                LeftWinLossRectangle[i].Fill = myBrush;
                RightWinLossRectangle[i].Fill = myBrush;
            }
        }


        private void UpdateSelection()
        {
            ClearPrev();

            if (TryGetResults()) //THIS IS ENDED
            {
                return;
            }

            if (!Canvote())
            {
                //TODO: Add too late display to user
            }
            LoadTeams(Database.GetTeamsPlaying(Global.Week, Global.Playday));
            string[] selections = Database.LoadedPreselection();
            for (int i = 0; i < selections.Length; i++)
            {
                if (selections[i] == "left")
                {
                    LeftWinLossRectangle[i].Visibility = Visibility.Visible;
                    RightWinLossRectangle[i].Visibility = Visibility.Hidden;
                }
                else if (selections[i] == "right")
                {
                    LeftWinLossRectangle[i].Visibility = Visibility.Hidden;
                    RightWinLossRectangle[i].Visibility = Visibility.Visible;
                }
                else if (selections[i] == "")
                {
                    LeftWinLossRectangle[i].Visibility = Visibility.Hidden;
                    RightWinLossRectangle[i].Visibility = Visibility.Hidden;
                }
            }
            Preselection();
        }

        private void UpdatePicks()
        {
            Database.LockUserPicks(Global.Week, Global.Playday, onepick, twopick, threepick, fourpick);
        }

        private void Preselection()
        {
            string[] prev = Database.LoadedPreselection();
            onepick = prev[0];
            twopick = prev[1];
            threepick = prev[2];
            fourpick = prev[3];
        }
        #endregion Picks


        #region Results 

        public bool TryGetResults()
        {
            if (Database.IsMatchOver(Global.Week, Global.Playday))
            {
                string[] winners = Database.GetMatchWinners(Global.Week, Global.Playday);
                string[] predictions = Database.LoadedPreselection();
                string[]? playing = Database.GetTeamsPlaying(Global.Week, Global.Playday);
                string source = Global.SourceString;
                for (int l = 0; l < LimagesGameCompleted.Length; l++)
                {
                    string[] game = playing[l].Split('/');
                    LimagesGameCompleted[l].Source = new BitmapImage(new Uri(source + game[0] + ".png", UriKind.Relative));
                    LimagesGameCompleted[l].Visibility = Visibility.Visible;
                    RimagesGameCompleted[l].Source = new BitmapImage(new Uri(source + game[1] + ".png", UriKind.Relative));
                    RimagesGameCompleted[l].Visibility = Visibility.Visible;
                }


                for (int i = 0; i < winners.Length; i++)
                {
                    LeftsideButtons[i].Visibility = Visibility.Hidden;
                    RightsideButtons[i].Visibility = Visibility.Hidden;


                    if (predictions[i] == "left")
                    {
                        LeftWinLossRectangle[i].Visibility = Visibility.Visible;
                        RightWinLossRectangle[i].Visibility = Visibility.Hidden;
                        if (winners[i] == predictions[i])
                        {

                            LeftWinLossRectangle[i].Fill = Brushes.Green;
                        }
                        else
                        {
                            LeftWinLossRectangle[i].Fill = Brushes.Red;
                        }
                    }

                    if (predictions[i] == "right")
                    {
                        LeftWinLossRectangle[i].Visibility = Visibility.Hidden;
                        RightWinLossRectangle[i].Visibility = Visibility.Visible;

                        if (winners[i] == predictions[i])
                        {
                            RightWinLossRectangle[i].Fill = Brushes.Green;
                        }
                        else
                        {
                            RightWinLossRectangle[i].Fill = Brushes.Red;
                        }
                    }
                }
                return true;
            }
            return false;

        }

        #endregion Results
    }

}
