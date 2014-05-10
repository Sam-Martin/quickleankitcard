using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;
//using SecureIt;

namespace QuickLeankitCard
{
    /// <summary>
    /// http://stackoverflow.com/questions/12657792/how-to-securely-save-username-password-local
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            // Prepopulate the password
            Password.Password = System.Runtime.InteropServices.Marshal.PtrToStringAuto(System.Runtime.InteropServices.Marshal.SecureStringToBSTR(Properties.Settings.Default.PasswordSecurestring.DecryptString()));
            Username.Text = Properties.Settings.Default.UserName;
            BoardID.Text = Properties.Settings.Default.BoardID;
            TeamName.Text = Properties.Settings.Default.TeamName;
            DefaultCardTypeID.Text = Properties.Settings.Default.DefaultCardTypeID;
            DefaultLaneID.Text = Properties.Settings.Default.DefaultLaneID;

            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            Properties.Settings.Default["PasswordSecurestring"] = Password.SecurePassword.EncryptString();
            Properties.Settings.Default["UserName"] = Username.Text;
            Properties.Settings.Default["BoardID"] = BoardID.Text;
            Properties.Settings.Default["DefaultLaneID"] = DefaultLaneID.Text;
            Properties.Settings.Default["TeamName"] = TeamName.Text;
            Properties.Settings.Default["DefaultCardTypeID"] = DefaultCardTypeID.Text;
            
            Properties.Settings.Default.Save();
            this.Close();
            
        }

        private void closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
        }

       
    }
}
