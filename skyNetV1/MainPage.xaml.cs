using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using System.Threading;
using System.IO;
using System.IO.IsolatedStorage;

namespace skyNetV1
{
    public partial class MainPage : PhoneApplicationPage
    {
        public string sitecode="";
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Thread.Sleep(1500);
            NavigationInTransition navigateInTransition = new NavigationInTransition();
 navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeIn };
 navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeIn };

 NavigationOutTransition navigateOutTransition = new NavigationOutTransition();
 navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeOut };
 navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeOut };
 TransitionService.SetNavigationInTransition(this, navigateInTransition);
 TransitionService.SetNavigationOutTransition(this, navigateOutTransition);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string txturl = urltxtbox.Text;
            if (txturl == "http://www." || txturl == "" || txturl == "http://" || txturl == "https://")
            {
                MessageBox.Show("Please enter Url");
            }
            else
            {
                if (txturl.Contains(".com") || txturl.Contains(".co.in") || txturl.Contains(".nic.in") || txturl.Contains(".in") || txturl.Contains(".pk") || txturl.Contains(".org") || txturl.Contains(".net"))
                {
                    if (txturl.Contains("www.") && !txturl.Contains("http://") && !txturl.Contains("https://"))
                    {
                        txturl = "http://" + txturl;
                        NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + txturl, UriKind.Relative));
                    }
                    else if (!txturl.Contains("http://www.") && !txturl.Contains("https://www.") && !txturl.Contains("http://") && !txturl.Contains("https://"))
                    {
                        txturl = "http://www." + txturl;

                        NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + txturl, UriKind.Relative));
                    }
                }
                if ((txturl.Contains("http://") || txturl.Contains("https://")) && !txturl.Contains("www."))
                {
                    string a;
                    if (txturl.Contains("http://"))
                    {
                        a = "http://www." + txturl.Substring(7);
                        txturl = a;
                    }
                    else if (txturl.Contains("https://"))
                    {
                        a = "https://www." + txturl.Substring(8);
                        txturl = a;
                    }

                    NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + txturl, UriKind.Relative));
                }
                else
                    NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + txturl, UriKind.Relative));
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=1", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=2", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=3", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=4", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=5", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=6", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=7", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_7(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=8", UriKind.Relative));
        }

        private void Image_MouseLeftButtonDown_8(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=9", UriKind.Relative));
        }

        private void abtus_Click(object sender, EventArgs e)
        {


          //   NavigationService.Navigate(new Uri("/abtus.xaml", UriKind.Relative));
        }


        private void tab_Click(object sender, EventArgs e)
        {
           // NavigationService.Navigate(new Uri("/abtus.xaml", UriKind.Relative));
            
        }

        private void ext_Click(object sender, EventArgs e)
        {
           //
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask market = new MarketplaceReviewTask();
            market.Show();
        }

        private void findus_Click(object sender, EventArgs e)
        {
            BingMapsTask bings = new BingMapsTask();
            bings.Center = new GeoCoordinate(28.613400,77.360382);
            bings.ZoomLevel = 2;
            bings.Show();
        }

        private void email_Click(object sender, EventArgs e)
        {
            EmailComposeTask em = new EmailComposeTask();
            em.Subject = "message subject";
            em.Body = "message body";
            em.To = "recipient@example.com";
            em.Cc = "cc@example.com";
            em.Show();
        }

        private void aboutus_Click(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(new Uri("/aboutPage.xaml?", UriKind.Relative));
        }

       

        private void bookmark_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/bookmarks.xaml?", UriKind.Relative));
        }

        private void urltxtbox_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            urltxtbox.SelectAll();
        }

        

        private void menuItem1_Click(object sender, EventArgs e)
        {
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                MessageBox.Show("No History");
            }
            else
                NavigationService.Navigate(new Uri("/history_page.xaml?", UriKind.Relative));

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5;
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "prevSession.txt";
            if (myfile.FileExists(sfile))
            {
                StreamReader reader = new StreamReader(new IsolatedStorageFileStream(sfile, FileMode.Open, myfile));
                s1 = reader.ReadLine();
                s2 = reader.ReadLine();
                s3 = reader.ReadLine();
                s4 = reader.ReadLine();
                s5 = reader.ReadLine();
                reader.Close();
                myfile.DeleteFile(sfile);
               
                NavigationService.Navigate(new Uri("/browserPage.xaml?key=-1&key1=" + s1 + "&key2=" + s2 + "&key3=" + s3 + "&key4=" + s4 + "&key5=" + s5, UriKind.Relative));
            }
            else
                MessageBox.Show("No previous Session recorded");

        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "prevSession.txt";
            if (myfile.FileExists(sfile))
            {
                myfile.DeleteFile(sfile);
                MessageBox.Show("Session Cleared");
            }
            else
                MessageBox.Show("No Session to clear");
        }

       

       

       
        

       
        

      

       
    }
}