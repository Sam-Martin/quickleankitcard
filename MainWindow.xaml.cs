using System;
using System.Collections.Generic;
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
using LeanKit.API.Client.Library;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Reflection;

namespace QuickLeankitCard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            Settings Settings = new Settings();
            Settings.Show();
            this.Close();
        }

        private void backgroundWorkerAddCard_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Security.SecureString Password = Properties.Settings.Default.PasswordSecurestring.DecryptString();
            string Username = Properties.Settings.Default.UserName;
            Int32 BoardID = Int32.Parse(Properties.Settings.Default.BoardID);
            string TeamName = Properties.Settings.Default.TeamName;
            
            
            if (Password.Length !=0 && Username.Length != 0 && BoardID > 0 && TeamName.Length > 0)
            {
                
              LeanKit.API.Client.Library.TransferObjects.Card newCard = e.Argument as LeanKit.API.Client.Library.TransferObjects.Card;
               // Create Auth Object
               LeanKit.API.Client.Library.TransferObjects.LeanKitAccountAuth LeanKitAuth = new  LeanKit.API.Client.Library.TransferObjects.LeanKitAccountAuth{
                   Hostname = TeamName,
                   Username = Username,
                   Password = System.Runtime.InteropServices.Marshal.PtrToStringAuto(System.Runtime.InteropServices.Marshal.SecureStringToBSTR(Password)),
               };
                // Add new card
                try
                {
                    // Connect
                    var LeanKitAPI = new LeanKit.API.Client.Library.LeanKitClientFactory().Create(LeanKitAuth);
                    e.Result= LeanKitAPI.AddCard(BoardID, newCard);
                }
                catch (Exception ex)
                {
                    e.Result = ex.Message;
                }
            }
            else
            {
                Submit.Content = "Please configure";
            }
        }

        private void backgroundWorkerAddCard_Return(object sender,  RunWorkerCompletedEventArgs e)
        {
            Submit.Content = "Submit";
            Body.Text = "";
            Title.Text = "";
            Submit.IsEnabled = true;
            Body.IsEnabled = true;
            Title.IsEnabled = true;
            // Show our result
            Window window = new Window()
            {
                Title = "Result",
                ShowInTaskbar = false,               // don't show the dialog on the taskbar
                Topmost = true,                      // ensure we're Always On Top
                ResizeMode = ResizeMode.NoResize,    // remove excess caption bar buttons
                Owner = Application.Current.MainWindow,
                SizeToContent=SizeToContent.WidthAndHeight,
                FontSize=12,
                
            };

            if (e.Result.GetType().Name != "CardAddResult")
            {
                window.Content = e.Result;
                window.ShowDialog();
            }
            
            

        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {


            Int32 DefaultLaneID = Int32.Parse(Properties.Settings.Default.DefaultLaneID);
            Int32 DefaultCardTypeID = Int32.Parse(Properties.Settings.Default.DefaultCardTypeID);
            Int32 DefaultCardPriority = Int32.Parse(Properties.Settings.Default.DefaultCardPriority);
            System.Security.SecureString Password = Properties.Settings.Default.PasswordSecurestring.DecryptString();
            string Username = Properties.Settings.Default.UserName;
            Int32 BoardID = Int32.Parse(Properties.Settings.Default.BoardID);
            string TeamName = Properties.Settings.Default.TeamName;
            
            
            if (DefaultCardTypeID != 0 && DefaultLaneID > 0 && Password.Length !=0 && Username.Length != 0 && BoardID > 0 && TeamName.Length > 0 && DefaultCardPriority >=0 && DefaultCardPriority <=3)
            {
                // Create our card!
                LeanKit.API.Client.Library.TransferObjects.Card newCard = new LeanKit.API.Client.Library.TransferObjects.Card
                {
                    LaneId = DefaultLaneID,
                    TypeId = DefaultCardTypeID,
                    Title = Title.Text,
                    Priority = DefaultCardPriority,
                    Description = Body.Text,
                };
                var submitWorker = new BackgroundWorker();
                submitWorker.DoWork += backgroundWorkerAddCard_DoWork;
                submitWorker.RunWorkerAsync(newCard);
                submitWorker.RunWorkerCompleted += backgroundWorkerAddCard_Return;
                Submit.Content = "Submitting";
                Submit.IsEnabled = false;
                Body.IsEnabled = false;
                Title.IsEnabled = false;
            }
            else
            {
                Submit.Content = "Please configure";
            }
               
           
        }

       

    }
}
