using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using JsonConvert = Newtonsoft.Json.JsonConvert;
#pragma warning disable CS8602
#pragma warning disable CS8600

namespace LCOpickem
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Global.GetData();
            Global.client = new MongoClient(Global.ConnectionString);
            glassBallPanel.Visibility = Visibility.Hidden;
            LoginPanel.Visibility = Visibility.Hidden;
            RegisterPanel.Visibility = Visibility.Hidden;

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
        private void Login(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Visible;
            InfoPanel.Visibility = Visibility.Hidden;
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterPanel.Visibility = Visibility.Visible;
            InfoPanel.Visibility = Visibility.Hidden;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Hidden;
            RegisterPanel.Visibility = Visibility.Hidden;
            glassBallPanel.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Visible;
        }

        #region Login
        private bool DatabaseLogin()
        {
            try
            {
                BsonDocument? filter = new BsonDocument { { "Username", UsernameBox.Text } };
                IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
                IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("UserCredentials");
                List<BsonDocument>? documents = collection.Find(filter).ToList();
                dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));

                if (jsonFile["Password"] == Functions.ComputeSha256Hash(PasswordBox.Text))
                {
                    User T_user = new User(jsonFile["Username"].ToString(), jsonFile["Email"].ToString(), "", false, jsonFile["Date Registered"].ToString(), jsonFile["UserID"].ToString()); ;
                    Global.currentUser = T_user;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                try
                {
                    BsonDocument? filter = new BsonDocument { { "Email", UsernameBox.Text } };
                    IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
                    IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("UserCredentials");
                    List<BsonDocument>? documents = collection.Find(filter).ToList();
                    dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));

                    if (jsonFile["Password"] == Functions.ComputeSha256Hash(PasswordBox.Text))
                    {
                        User T_user = new User(jsonFile["Username"].ToString(), jsonFile["Email"].ToString(), "", false, jsonFile["Date Registered"].ToString(), jsonFile["UserID"].ToString()); ;
                        Global.currentUser = T_user;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && LoginPanel.Visibility == Visibility.Visible)
            {
                Login_Check(sender, e);
            }
            else if (e.Key == Key.Enter && RegisterPanel.Visibility == Visibility.Visible)
            {
                Register_Check(sender, e);
            }
        }
        private void Login_Check(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Field/s are empty");
            }
            else
            {
                if (DatabaseLogin())
                {
                    Pickems pickems = new Pickems
                    {
                        Left = Left,
                        Top = Top
                    };
                    Close();
                    pickems.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username/Password or User does not exist");
                }
            }
        }
        #endregion Login

        #region Register
        private void Register_Check(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RusernameBox.Text) || string.IsNullOrWhiteSpace(RemailBox.Text) || string.IsNullOrWhiteSpace(RpasswordBox.Text))
            {
                MessageBox.Show("Field/s are empty");
                return;
            }
            User t_user = new User(RusernameBox.Text, RemailBox.Text, RpasswordBox.Text, true);
            Global.currentUser = t_user;
            if (Database.SignupDatabase(t_user))
            {
                RusernameBox.Clear();
                RemailBox.Clear();
                RpasswordBox.Clear();
                RegisterPanel.Visibility = Visibility.Hidden;
                ShowTeamGlassBall();
            }
            else
            {
                MessageBox.Show("Username is already in use");
            }
        }
        private void ShowTeamGlassBall()
        {
            glassBallPanel.Visibility = Visibility.Visible;
        }


        #region TeamSelect
        private string teamSelected = "";
        private void PGGLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "PGG";
            LockInButton.Content = "Lock in PGG!";
        }
        private void DWLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "DW";
            LockInButton.Content = "Lock in DW!";
        }
        private void MMMLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "MMM";
            LockInButton.Content = "Lock in MMM!";
        }
        private void CHFLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "CHF";
            LockInButton.Content = "Lock in CHF!";
        }
        private void PCELock(object sender, RoutedEventArgs e)
        {
            teamSelected = "PCE";
            LockInButton.Content = "Lock in PCE!";
        }
        private void GRVLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "GRV";
            LockInButton.Content = "Lock in GRV!";
        }
        private void ORDLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "ORD";
            LockInButton.Content = "Lock in ORD!";
        }
        private void LGCLock(object sender, RoutedEventArgs e)
        {
            teamSelected = "LGC";
            LockInButton.Content = "Lock in LGC!";
        }

        private void LockIn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(teamSelected))
            {
                MessageBox.Show("Please Select a team");
                return;
            }

            if (Database.GlassBall(teamSelected))
            {
                Pickems pickems = new Pickems
                {
                    Left = Left,
                    Top = Top
                };
                Close();
                pickems.Show();
            }
            else
            {
                MessageBox.Show("An error has occoured! 404");
            }
        }
        #endregion TeamSelect

        #endregion Register

    }
}
