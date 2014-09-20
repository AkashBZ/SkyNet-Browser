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
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;


namespace skyNetV1
{
    public partial class history_page : PhoneApplicationPage
    {
        string sfile = "data.txt";
        IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
        StreamReader reader;
        string x;
        int k = 0,buttons_made=0,maxk;
        string[] stack = new string[10000];
        Button btn;
        public history_page()
        {
            InitializeComponent();
            NavigationInTransition navigateInTransition = new NavigationInTransition();
            navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeIn };
            navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeIn };

            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();
            navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeOut };
            navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeOut };
            TransitionService.SetNavigationInTransition(this, navigateInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);

        }

        //void history_page_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Memory cleared");
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
            
        //}
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            mystackpanel.Children.Clear();
            reader = new StreamReader(new IsolatedStorageFileStream(sfile, FileMode.Open, myfile));



            x = reader.ReadLine();

            if (x == null)
            {
                MessageBox.Show("No History");

            }
            else
            {

                while (x != null)
                {
                    stack[k] = x;
                    x = reader.ReadLine();
                    k = k + 1;
                    if (k >= 10001)
                    {
                        MessageBox.Show(" Click on OK to delete old history to view the latest");
                        reader.Close();
                        if (myfile.FileExists(sfile))
                        {


                            myfile.DeleteFile(sfile);

                            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                        }
                    }
                }
                reader.Close();
                maxk = k - 1;
               
               
                    for (int i = 1; i <= 8; i++)
                    {
                        k = k - 1;
                        buttons_made++;
                        btn = new Button();
                        btn.Height = 70;
                        btn.Width = 450;
                        if (stack[k].Contains("www.google.com/search?q="))
                        {
                            btn.Content = "Google Search| " + stack[k].Substring(31);
                        }
                        else if (stack[k].Contains("facebook.com"))
                        {
                            if (stack[k].Contains("refid") || stack[k].Contains("fref=nf"))
                                btn.Content = "Facebook| " + stack[k].Substring(23);
                            else
                                btn.Content = "Facebook| " + stack[k];

                        }
                        else if (stack[k].Contains("http://timesofindia"))
                        {
                            btn.Content = "TOI| " + stack[k];
                        }
                        else if (stack[k].Contains("twitter.com"))
                        {
                            btn.Content = "Twitter| " + stack[k];
                        }
                        else if (stack[k].Contains("linkedin.com"))
                        {
                            btn.Content = "LinkedIn| " + stack[k];
                        }
                        else if (stack[k].Contains("youtube.com"))
                        {
                            btn.Content = "You Tube| " + stack[k];
                        }
                        else
                        {
                            btn.Content = stack[k];
                        }


                        btn.Click += btn_click;
                        mystackpanel.Children.Add(btn);
                        if (k == 0)
                            break;

                    }
                }


            
        }
        protected void btn_click(object sender, RoutedEventArgs e)
        {
            
            Button buton = sender as Button;
            string a = buton.Content.ToString();
            if (a.Contains("Facebook| "))
            {
                if (a.Contains("https://") || a.Contains("http://"))
                    a = a.Substring(10);
                else
                    a = "https://m.facebook.com/" + a.Substring(10);
            }
            else if (a.Contains("Google Search| "))
            {
                a = "http://www.google.com/search?q=" + a.Substring(15);
            }
            else if (a.Contains("TOI| "))
            {
                a = a.Substring(5);
            }
            else if (a.Contains("Twitter| "))
            {
                a = a.Substring(9);
            }
            else if (a.Contains("LinkedIn| "))
            {
                a = a.Substring(10);
            }
            else if (a.Contains("You Tube| "))
            {
                a = a.Substring(10);
            }

            mystackpanel.Children.Clear();
            k = 0;
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + a, UriKind.Relative));

        }



        private void clear_history_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete all history?", "Confirm Delete?",
                                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                if (myfile.FileExists(sfile))
                {


                    myfile.DeleteFile(sfile);
                    MessageBox.Show("History Cleared");

                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                else
                    MessageBox.Show("No history to delete");


            }
        }

        private void pre_history_Click(object sender, EventArgs e)
        {
           
            if (k == 0)
            {
                MessageBox.Show("No more History");
            }
            else
            {
                buttons_made = 0;
                mystackpanel.Children.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    k = k - 1;
                    buttons_made++;
                    btn = new Button();
                    btn.Height = 70;
                    btn.Width = 450;
                    if (stack[k].Contains("www.google.com/search?q="))
                    {
                        btn.Content = "Google Search| " + stack[k].Substring(31);
                    }
                    else if (stack[k].Contains("facebook.com"))
                    {
                        if (stack[k].Contains("refid") || stack[k].Contains("fref=nf"))
                            btn.Content = "Facebook| " + stack[k].Substring(23);
                        else
                            btn.Content = "Facebook| " + stack[k];

                    }
                    else if (stack[k].Contains("http://timesofindia"))
                    {
                        btn.Content = "TOI| " + stack[k];
                    }
                    else if (stack[k].Contains("twitter.com"))
                    {
                        btn.Content = "Twitter| " + stack[k];
                    }
                    else if (stack[k].Contains("linkedin.com"))
                    {
                        btn.Content = "LinkedIn| " + stack[k];
                    }
                    else if (stack[k].Contains("youtube.com"))
                    {
                        btn.Content = "You Tube| " + stack[k];
                    }
                    else
                    {
                        btn.Content = stack[k];
                    }


                    btn.Click += btn_click;
                    mystackpanel.Children.Add(btn);
                    if (k == 0)
                        break;

                }

            }
        }

        private void lat_history_Click(object sender, EventArgs e)
        {


            if ((buttons_made + k) >= maxk)
            {
                MessageBox.Show("No more latest History");
            }
            else
            {

                mystackpanel.Children.Clear();
                if (stack[buttons_made + k + 7] != null)
                    k = buttons_made + k + 7;
                else if (stack[buttons_made + k + 6] != null)
                    k = buttons_made + k + 6;
                else if (stack[buttons_made + k + 5] != null)
                    k = buttons_made + k + 5;
                else if (stack[buttons_made + k + 4] != null)
                    k = buttons_made + k + 4;
                else if (stack[buttons_made + k + 3] != null)
                    k = buttons_made + k + 3;
                else if (stack[buttons_made + k + 2] != null)
                    k = buttons_made + k + 2;
                else if (stack[buttons_made + k + 1] != null)
                    k = buttons_made + k + 1;
                else if (stack[buttons_made + k] != null)
                    k = buttons_made + k;

                buttons_made = 0;

                for (int i = 1; i <= 8; i++)
                {

                    buttons_made++;
                    btn = new Button();
                    btn.Height = 70;
                    btn.Width = 450;
                    if (stack[k].Contains("www.google.com/search?q="))
                    {
                        btn.Content = "Google Search| " + stack[k].Substring(31);
                    }
                    else if (stack[k].Contains("facebook.com"))
                    {
                        if (stack[k].Contains("refid") || stack[k].Contains("fref=nf"))
                            btn.Content = "Facebook| " + stack[k].Substring(23);
                        else
                            btn.Content = "Facebook| " + stack[k];

                    }
                    else if (stack[k].Contains("http://timesofindia"))
                    {
                        btn.Content = "TOI| " + stack[k];
                    }
                    else if (stack[k].Contains("twitter.com"))
                    {
                        btn.Content = "Twitter| " + stack[k];
                    }
                    else if (stack[k].Contains("linkedin.com"))
                    {
                        btn.Content = "LinkedIn| " + stack[k];
                    }
                    else if (stack[k].Contains("youtube.com"))
                    {
                        btn.Content = "You Tube| " + stack[k];
                    }
                    else
                    {
                        btn.Content = stack[k];
                    }

                    k--;
                    btn.Click += btn_click;
                    mystackpanel.Children.Add(btn);
                    if (k == -1)
                        break;
                }
                k = k + 1;
            }
        }

       

       
    }
}