using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace skyNetV1
{
    public partial class browserPage : PhoneApplicationPage
    {
        
        public string site="";
        Stack<Uri> history = new Stack<Uri>();
        Uri current=null,current1=null,current2=null,current3=null,current4=null;

        Popup popup;
        int fuckedupcounter = 0, fuckedupcounter2 = 0, fuckedupcounter3 = 0, fuckedupcounter4 = 0, fuckedupcounter5 = 0;
       
        public browserPage()
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
       



        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?","Confirm Exit?",
                                    MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                e.Cancel = true;

            }
            else
            {
                if (tb1.Text != "" || tb2.Text != "" || tb3.Text != "" || tb4.Text != "" || tb5.Text != "")
                {
                    IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                    string sfile = "prevSession.txt";

                    if (!myfile.FileExists(sfile))
                    {
                        IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                        datafile.Close();
                    }



                    StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));
                    if (tb1.Text.Contains("#"))
                        writer.WriteLine("no_url");
                    else
                       writer.WriteLine(tb1.Text);
                    if (tb2.Text.Contains("#"))
                        writer.WriteLine("no_url");
                    else
                    writer.WriteLine(tb2.Text);
                    if (tb3.Text.Contains("#"))
                        writer.WriteLine("no_url");
                    else
                    writer.WriteLine(tb3.Text);
                    if (tb4.Text.Contains("#"))
                        writer.WriteLine("no_url");
                    else
                    writer.WriteLine(tb4.Text);
                    if (tb5.Text.Contains("#"))
                        writer.WriteLine("no_url");
                    else
                    writer.WriteLine(tb5.Text);
                    writer.Close();
                }
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if(NavigationContext.QueryString.ContainsKey("key"))
                site=NavigationContext.QueryString["key"];

            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "prevSession.txt";
            if (myfile.FileExists(sfile))
            {
                myfile.DeleteFile(sfile);
            }
            


            if (site == "1")
            {
                tb1.Text = "http://www.cricbuzz.com";
                string url1 = "http://www.cricbuzz.com";
                wb1.Navigate(new Uri(url1, UriKind.Absolute));
                
                

            }
            else if (site == "2")
            {
                tb1.Text = "http://www.bing.com";
                string url2 = "http://www.bing.com";
                wb1.Navigate(new Uri(url2, UriKind.Absolute));
                
            }
            else if (site == "3")
            {
                tb1.Text = "http://www.w3schools.com";
                string url3 = "http://www.w3schools.com";
                wb1.Navigate(new Uri(url3, UriKind.Absolute));
                
            }
            else if (site == "4")
            {
                tb1.Text = "http://www.facebook.com";
                string url4 = "http://www.facebook.com";
                wb1.Navigate(new Uri(url4, UriKind.Absolute));
                
            }
            else if (site == "5")
            {
                tb1.Text = "http://www.google.com";
                string url5 = "http://www.google.com";
                wb1.Navigate(new Uri(url5, UriKind.Absolute));
                
            }
            else if (site == "6")
            {
                tb1.Text = "http://www.timesofindia.indiatimes.com";
                string url6 = "http://www.timesofindia.indiatimes.com";
                wb1.Navigate(new Uri(url6, UriKind.Absolute));
                
            }
            else if (site == "7")
            {
                tb1.Text = "http://www.twitter.com";
                string url7 = "http://www.twitter.com";
                wb1.Navigate(new Uri(url7, UriKind.Absolute));
                
            }
            else if (site == "8")
            {
                tb1.Text = "http://www.youtube.com";
                string url8 = "http://www.youtube.com";
                wb1.Navigate(new Uri(url8, UriKind.Absolute));
                
            }
            else if (site == "9")
            {
                tb1.Text = "http://www.gmail.com";
                string url9 = "http://www.gmail.com";
                wb1.Navigate(new Uri(url9, UriKind.Absolute));
                
            }
            else if (site == "-1")
            {
                string text1 = NavigationContext.QueryString["key1"];
                string text2 = NavigationContext.QueryString["key2"];
                string text3 = NavigationContext.QueryString["key3"];
                string text4 = NavigationContext.QueryString["key4"];
                string text5 = NavigationContext.QueryString["key5"];
                if (text1 != "")
                {
                    if (text1.Contains("http://") || text1.Contains("https://"))
                    {
                        tb1.Text = text1;
                        wb1.Navigate(new Uri(tb1.Text, UriKind.Absolute));
                    }
                    else
                        tb1.Text = "no valid url found";
                }
                if (text2 != "")
                {
                    if (text2.Contains("http://") || text2.Contains("https://"))
                    {
                        tb2.Text = text2;
                        wb2.Navigate(new Uri(tb2.Text, UriKind.Absolute));
                    }
                    else
                        tb2.Text = "no valid url found";
                }
                if (text3 != "")
                {
                    if (text3.Contains("http://") || text3.Contains("https://"))
                    {
                        tb3.Text = text3;
                        wb3.Navigate(new Uri(tb3.Text, UriKind.Absolute));
                    }
                    else
                        tb3.Text = "no valid url found";
                }
                if (text4 != "")
                {
                    if (text4.Contains("http://") || text4.Contains("https://"))
                    {
                        tb4.Text = text4;
                        wb4.Navigate(new Uri(tb4.Text, UriKind.Absolute));
                    }
                    else
                        tb4.Text = "no valid url found";
                }
                if (text5 != "")
                {
                    if (text5.Contains("http://") || text5.Contains("https://"))
                    {
                        tb5.Text = text5;
                        wb5.Navigate(new Uri(tb5.Text, UriKind.Absolute));
                    }
                    else
                        tb5.Text = "no valid url found";
                }


            }
            else
            {
                try
                {
                    if (tb1.Text == "")
                    {
                        tb1.Text = site;
                        string txturl1 = site;
                        if (site != "")
                        {
                            if (txturl1.Contains("http://www.") || txturl1.Contains("https://www.") || txturl1.Contains("http://") || txturl1.Contains("https://"))
                            {
                                wb1.Navigate(new Uri(tb1.Text, UriKind.Absolute));

                            }

                            else
                            {
                                string urlx = "http://www.google.com/search?q=" + txturl1;
                                tb1.Text = urlx;
                                wb1.Navigate(new Uri(urlx, UriKind.Absolute));

                            }

                        }
                    }

                }
                catch (System.UriFormatException)
                {                   
                    MessageBox.Show("Invalid Url");
                    return;
                }
            }

            
            
            }

        private void backb1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wb1.InvokeScript("eval", "history.go(-1)");
            }
            catch { MessageBox.Show("Unable to go back"); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st1 = tb1.Text;
                if (st1 == "" || st1 == "http://" || st1 == "https://" || st1 == "http://www." || st1 == "https://www.")
                {
                    MessageBox.Show("You have not entered any url or query");
                }
                else
                {

                    if (st1.Contains(".com") || st1.Contains(".co.in") || st1.Contains(".nic.in") || st1.Contains(".in") || st1.Contains(".pk") || st1.Contains(".org") || st1.Contains(".net"))
                    {
                        if (st1.Contains("www.") && !st1.Contains("http://") && !st1.Contains("https://"))
                        {
                            st1 = "http://" + st1;
                            wb1.Navigate(new Uri(st1, UriKind.Absolute));
                        }
                        else if (!st1.Contains("http://www.") && !st1.Contains("https://www.") && !st1.Contains("http://") && !st1.Contains("https://"))
                        {
                            st1 = "http://www." + st1;
                            wb1.Navigate(new Uri(st1, UriKind.Absolute));
                        }
                        else if ((st1.Contains("http://") || st1.Contains("https://")) && !st1.Contains("www."))
                        {
                            string a;
                            if (st1.Contains("http://"))
                            {
                                a = "http://www." + st1.Substring(7);
                                st1 = a;
                                wb1.Navigate(new Uri(st1, UriKind.Absolute));
                            }
                            else if (st1.Contains("https://"))
                            {
                                a = "https://www." + st1.Substring(8);
                                st1 = a;
                                wb1.Navigate(new Uri(st1, UriKind.Absolute));
                            }


                        }
                        else if (st1.Contains("http://www.") || st1.Contains("https://www."))
                        {
                            wb1.Navigate(new Uri(st1, UriKind.Absolute));
                        }

                    }



                    else
                    {
                        string urlx = "http://www.google.com/search?q=" + st1;
                        tb1.Text = urlx;
                        wb1.Navigate(new Uri(urlx, UriKind.Absolute));

                    }
                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid Url");
                return;
            }
        }


        private void b2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st2 = tb2.Text;
                if (st2 == "" || st2 == "http://" || st2 == "https://" || st2 == "http://www." || st2 == "https://www.")
                {
                    MessageBox.Show("You have not entered any url or query");
                }
                else
                {

                    if (st2.Contains(".com") || st2.Contains(".co.in") || st2.Contains(".nic.in") || st2.Contains(".in") || st2.Contains(".pk") || st2.Contains(".org") || st2.Contains(".net"))
                    {
                        if (st2.Contains("www.") && !st2.Contains("http://") && !st2.Contains("https://"))
                        {
                            st2 = "http://" + st2;
                            wb2.Navigate(new Uri(st2, UriKind.Absolute));
                        }
                        else if (!st2.Contains("http://www.") && !st2.Contains("https://www.") && !st2.Contains("http://") && !st2.Contains("https://"))
                        {
                            st2 = "http://www." + st2;
                            wb2.Navigate(new Uri(st2, UriKind.Absolute));
                        }
                        else if ((st2.Contains("http://") || st2.Contains("https://")) && !st2.Contains("www."))
                        {
                            string a;
                            if (st2.Contains("http://"))
                            {
                                a = "http://www." + st2.Substring(7);
                                st2 = a;
                                wb2.Navigate(new Uri(st2, UriKind.Absolute));
                            }
                            else if (st2.Contains("https://"))
                            {
                                a = "https://www." + st2.Substring(8);
                                st2 = a;
                                wb2.Navigate(new Uri(st2, UriKind.Absolute));
                            }



                        }
                        else if (st2.Contains("http://www.") || st2.Contains("https://www."))
                        {
                            wb2.Navigate(new Uri(st2, UriKind.Absolute));
                        }
                    }


                    else
                    {
                        string urlx = "http://www.google.com/search?q=" + st2;
                        tb2.Text = urlx;
                        wb2.Navigate(new Uri(urlx, UriKind.Absolute));

                    }



                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid Url");
                return;
            }
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st3 = tb3.Text;
                if (st3 == "" || st3 == "http://" || st3 == "https://" || st3 == "http://www." || st3 == "https://www.")
                {
                    MessageBox.Show("You have not entered any url or query");
                }
                else
                {

                    if (st3.Contains(".com") || st3.Contains(".co.in") || st3.Contains(".nic.in") || st3.Contains(".in") || st3.Contains(".pk") || st3.Contains(".org") || st3.Contains(".net"))
                    {
                        if (st3.Contains("www.") && !st3.Contains("http://") && !st3.Contains("https://"))
                        {
                            st3 = "http://" + st3;
                            wb3.Navigate(new Uri(st3, UriKind.Absolute));
                        }
                        else if (!st3.Contains("http://www.") && !st3.Contains("https://www.") && !st3.Contains("http://") && !st3.Contains("https://"))
                        {
                            st3 = "http://www." + st3;
                            wb3.Navigate(new Uri(st3, UriKind.Absolute));
                        }
                        else if ((st3.Contains("http://") || st3.Contains("https://")) && !st3.Contains("www."))
                        {
                            string a;
                            if (st3.Contains("http://"))
                            {
                                a = "http://www." + st3.Substring(7);
                                st3 = a;
                                wb3.Navigate(new Uri(st3, UriKind.Absolute));
                            }
                            else if (st3.Contains("https://"))
                            {
                                a = "https://www." + st3.Substring(8);
                                st3 = a;
                                wb3.Navigate(new Uri(st3, UriKind.Absolute));
                            }


                        }
                        else if (st3.Contains("http://www.") || st3.Contains("https://www."))
                        {
                            wb3.Navigate(new Uri(st3, UriKind.Absolute));
                        }

                    }


                    else
                    {
                        string urlx = "http://www.google.com/search?q=" + st3;
                        tb3.Text = urlx;
                        wb3.Navigate(new Uri(urlx, UriKind.Absolute));

                    }
                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid Url");
                return;
            }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st4 = tb4.Text;
                if (st4 == "" || st4 == "http://" || st4 == "https://" || st4 == "http://www." || st4 == "https://www.")
                {
                    MessageBox.Show("You have not entered any url or query");
                }
                else
                {

                    if (st4.Contains(".com") || st4.Contains(".co.in") || st4.Contains(".nic.in") || st4.Contains(".in") || st4.Contains(".pk") || st4.Contains(".org") || st4.Contains(".net"))
                    {
                        if (st4.Contains("www.") && !st4.Contains("http://") && !st4.Contains("https://"))
                        {
                            st4 = "http://" + st4;
                            wb4.Navigate(new Uri(st4, UriKind.Absolute));
                        }
                        else if (!st4.Contains("http://www.") && !st4.Contains("https://www.") && !st4.Contains("http://") && !st4.Contains("https://"))
                        {
                            st4 = "http://www." + st4;
                            wb4.Navigate(new Uri(st4, UriKind.Absolute));
                        }
                        else if ((st4.Contains("http://") || st4.Contains("https://")) && !st4.Contains("www."))
                        {
                            string a;
                            if (st4.Contains("http://"))
                            {
                                a = "http://www." + st4.Substring(7);
                                st4 = a;
                                wb4.Navigate(new Uri(st4, UriKind.Absolute));
                            }
                            else if (st4.Contains("https://"))
                            {
                                a = "https://www." + st4.Substring(8);
                                st4 = a;
                                wb4.Navigate(new Uri(st4, UriKind.Absolute));
                            }


                        }
                        else if (st4.Contains("http://www.") || st4.Contains("https://www."))
                        {
                            wb4.Navigate(new Uri(st4, UriKind.Absolute));
                        }

                    }


                    else
                    {
                        string urlx = "http://www.google.com/search?q=" + st4;
                        tb4.Text = urlx;
                        wb4.Navigate(new Uri(urlx, UriKind.Absolute));

                    }
                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid Url");
                return;
            }
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st5 = tb5.Text;
                if (st5 == "" || st5 == "http://" || st5 == "https://" || st5 == "http://www." || st5 == "https://www.")
                {
                    MessageBox.Show("You have not entered any url or query");
                }
                else
                {

                    if (st5.Contains(".com") || st5.Contains(".co.in") || st5.Contains(".nic.in") || st5.Contains(".in") || st5.Contains(".pk") || st5.Contains(".org") || st5.Contains(".net"))
                    {
                        if (st5.Contains("www.") && !st5.Contains("http://") && !st5.Contains("https://"))
                        {
                            st5 = "http://" + st5;
                            wb5.Navigate(new Uri(st5, UriKind.Absolute));
                        }
                        else if (!st5.Contains("http://www.") && !st5.Contains("https://www.") && !st5.Contains("http://") && !st5.Contains("https://"))
                        {
                            st5 = "http://www." + st5;
                            wb5.Navigate(new Uri(st5, UriKind.Absolute));
                        }
                        else if ((st5.Contains("http://") || st5.Contains("https://")) && !st5.Contains("www."))
                        {
                            string a;
                            if (st5.Contains("http://"))
                            {
                                a = "http://www." + st5.Substring(7);
                                st5 = a;
                                wb5.Navigate(new Uri(st5, UriKind.Absolute));
                            }
                            else if (st5.Contains("https://"))
                            {
                                a = "https://www." + st5.Substring(8);
                                st5 = a;
                                wb5.Navigate(new Uri(st5, UriKind.Absolute));
                            }


                        }
                        else if (st5.Contains("http://www.") || st5.Contains("https://www."))
                        {
                            wb5.Navigate(new Uri(st5, UriKind.Absolute));
                        }


                    }
                    else
                    {
                        string urlx = "http://www.google.com/search?q=" + st5;
                        tb5.Text = urlx;
                        wb5.Navigate(new Uri(urlx, UriKind.Absolute));

                    }
                }
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid Url");
                return;
            }
        }

        private void forb1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (fuckedupcounter == 0)
            {
                popup = new Popup();
                //popup.Height = 250;
                //popup.Width = 350;
                popup.VerticalOffset = 370;
                popup.HorizontalOffset = 0;


                WindowsPhoneControl1 control = new WindowsPhoneControl1();
                popup.Child = control;
                fuckedupcounter = 1;

                popup.IsOpen = true;


                control.frwrd_button.Click += (s, args) =>
                {
                    fuckedupcounter = 0;
                    popup.IsOpen = false;
                    try
                    {
                        wb1.InvokeScript("eval", "history.go(1)");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to go forward");
                    }
                   

                };

                control.cancel_button.Click += (s, args) =>
                {
                    fuckedupcounter = 0;
                    popup.IsOpen = false;
                };
                control.bookmark_button.Click += (s, args) =>
                    {
                        fuckedupcounter = 0;
                        popup.IsOpen = false;
                        if (tb1.Text != "")
                        {
                           
                            popup = new Popup();
                            create_bookmark controlnested = new create_bookmark();
                            popup.Child = controlnested;
                            popup.IsOpen = true;
                            controlnested.book_url.Text = tb1.Text;

                            controlnested.cancelButton.Click += (s1, args1) =>
                                {
                                    popup.IsOpen = false;
                                };
                            controlnested.add_book.Click += (s1, args1) =>
                                {

                                    if (controlnested.book_name.Text == "")
                                    {
                                        MessageBox.Show("Please enter a name");
                                    }

                                    else if (controlnested.book_url.Text.Contains("http://") || controlnested.book_url.Text.Contains("https://"))
                                    {
                                        try
                                        {
                                            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                                            string sfile = "book.text";

                                            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                                            writer.WriteLine(controlnested.book_name.Text);
                                            writer.WriteLine(controlnested.book_url.Text);
                                            writer.Close();
                                            popup.IsOpen = false;
                                            MessageBox.Show("Bookmark Added");
                                        }
                                        catch { MessageBox.Show("Unable to add bookmark"); }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Url");
                                    }
                                };

                        }
                        else
                            MessageBox.Show("No url to bookmark. Please enter a url");
                    };

            }
        }

        

        private void backb2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wb2.InvokeScript("eval", "history.go(-1)");
            }
            catch { MessageBox.Show("Unable to go back"); }
        }

        private void forb2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (fuckedupcounter2 == 0)
            {
                popup = new Popup();
                //popup.Height = 250;
                //popup.Width = 350;
                popup.VerticalOffset = 370;
                popup.HorizontalOffset = 0;


                WindowsPhoneControl1 control = new WindowsPhoneControl1();
                popup.Child = control;
                fuckedupcounter2 = 1;

                popup.IsOpen = true;


                control.frwrd_button.Click += (s, args) =>
                {
                    fuckedupcounter2 = 0;
                    popup.IsOpen = false;
                    try
                    {
                        wb2.InvokeScript("eval", "history.go(1)");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to go forward");
                    }
                    

                };

                control.cancel_button.Click += (s, args) =>
                {
                    fuckedupcounter2 = 0;
                    popup.IsOpen = false;
                };
                control.bookmark_button.Click += (s, args) =>
                {
                    fuckedupcounter2 = 0;
                    popup.IsOpen = false;
                    if (tb2.Text != "")
                    {
                        
                        popup = new Popup();
                        create_bookmark controlnested = new create_bookmark();
                        popup.Child = controlnested;
                        popup.IsOpen = true;
                        controlnested.book_url.Text = tb2.Text;

                        controlnested.cancelButton.Click += (s1, args1) =>
                        {
                            popup.IsOpen = false;
                        };
                        controlnested.add_book.Click += (s1, args1) =>
                        {

                            if (controlnested.book_name.Text == "")
                            {
                                MessageBox.Show("Please enter a name");
                            }

                            else if (controlnested.book_url.Text.Contains("http://") || controlnested.book_url.Text.Contains("https://"))
                            {
                                try
                                {
                                    IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                                    string sfile = "book.text";

                                    StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                                    writer.WriteLine(controlnested.book_name.Text);
                                    writer.WriteLine(controlnested.book_url.Text);
                                    writer.Close();
                                    popup.IsOpen = false;
                                    MessageBox.Show("Bookmark Added");
                                }
                                catch { MessageBox.Show("Unable to add bookmark"); }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Url");
                            }
                        };

                    }
                    else
                        MessageBox.Show("No url to bookmark. Please enter a url");
                };
                
                
            }
        }

        private void backb3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wb3.InvokeScript("eval", "history.go(-1)");
            }
            catch { MessageBox.Show("Unable to go back"); }
        }

        private void forb3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (fuckedupcounter3 == 0)
            {
                popup = new Popup();
                //popup.Height = 250;
                //popup.Width = 350;
                popup.VerticalOffset = 370;
                popup.HorizontalOffset = 0;


                WindowsPhoneControl1 control = new WindowsPhoneControl1();
                popup.Child = control;
                fuckedupcounter3 = 1;

                popup.IsOpen = true;


                control.frwrd_button.Click += (s, args) =>
                {
                    fuckedupcounter3 = 0;
                    popup.IsOpen = false;

                    try
                    {
                        wb3.InvokeScript("eval", "history.go(1)");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to go forward");
                    }
                   
                };

                control.cancel_button.Click += (s, args) =>
                {
                    fuckedupcounter3 = 0;
                    popup.IsOpen = false;
                };
                control.bookmark_button.Click += (s, args) =>
                {
                    fuckedupcounter3 = 0;
                    popup.IsOpen = false;

                    if (tb3.Text != "")
                    {
                       
                        popup = new Popup();
                        create_bookmark controlnested = new create_bookmark();
                        popup.Child = controlnested;
                        popup.IsOpen = true;
                        controlnested.book_url.Text = tb3.Text;

                        controlnested.cancelButton.Click += (s1, args1) =>
                        {
                            popup.IsOpen = false;
                        };
                        controlnested.add_book.Click += (s1, args1) =>
                        {

                            if (controlnested.book_name.Text == "")
                            {
                                MessageBox.Show("Please enter a name");
                            }

                            else if (controlnested.book_url.Text.Contains("http://") || controlnested.book_url.Text.Contains("https://"))
                            {
                                try
                                {
                                    IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                                    string sfile = "book.text";

                                    StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                                    writer.WriteLine(controlnested.book_name.Text);
                                    writer.WriteLine(controlnested.book_url.Text);
                                    writer.Close();
                                    popup.IsOpen = false;
                                    MessageBox.Show("Bookmark Added");
                                }
                                catch { MessageBox.Show("Unable to add bookmark"); }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Url");
                            }
                        };

                    }
                    else
                        MessageBox.Show("No url to bookmark. Please enter a url");
                };

            }
        }

        private void backb4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wb4.InvokeScript("eval", "history.go(-1)");
            }
            catch { MessageBox.Show("Unable to go back"); }
        }

        private void forb4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (fuckedupcounter4 == 0)
            {
                popup = new Popup();
                //popup.Height = 250;
                //popup.Width = 350;
                popup.VerticalOffset = 370;
                popup.HorizontalOffset = 0;


                WindowsPhoneControl1 control = new WindowsPhoneControl1();
                popup.Child = control;
                fuckedupcounter4 = 1;

                popup.IsOpen = true;


                control.frwrd_button.Click += (s, args) =>
                {
                    fuckedupcounter4 = 0;
                    popup.IsOpen = false;
                    try
                    {
                        wb4.InvokeScript("eval", "history.go(1)");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to go forward");
                    }
                    

                };

                control.cancel_button.Click += (s, args) =>
                {
                    fuckedupcounter4 = 0;
                    popup.IsOpen = false;
                };
                control.bookmark_button.Click += (s, args) =>
                {
                    fuckedupcounter4 = 0;
                    popup.IsOpen = false;
                    if (tb4.Text != "")
                    {

                        popup = new Popup();
                        create_bookmark controlnested = new create_bookmark();
                        popup.Child = controlnested;
                        popup.IsOpen = true;
                        controlnested.book_url.Text = tb4.Text;

                        controlnested.cancelButton.Click += (s1, args1) =>
                        {
                            popup.IsOpen = false;
                        };
                        controlnested.add_book.Click += (s1, args1) =>
                        {

                            if (controlnested.book_name.Text == "")
                            {
                                MessageBox.Show("Please enter a name");
                            }

                            else if (controlnested.book_url.Text.Contains("http://") || controlnested.book_url.Text.Contains("https://"))
                            {
                                try
                                {
                                    IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                                    string sfile = "book.text";

                                    StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                                    writer.WriteLine(controlnested.book_name.Text);
                                    writer.WriteLine(controlnested.book_url.Text);
                                    writer.Close();
                                    popup.IsOpen = false;
                                    MessageBox.Show("Bookmark Added");
                                }
                                catch { MessageBox.Show("Unable to add bookmark"); }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Url");
                            }
                        };

                    }
                    else
                        MessageBox.Show("No url to bookmark. Please enter a url");
                };


            }

        }

        private void backb5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                wb5.InvokeScript("eval", "history.go(-1)");
            }
            catch { MessageBox.Show("Unable to go back"); }
        }

        private void forb5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (fuckedupcounter5 == 0)
            {
                popup = new Popup();
                //popup.Height = 250;
                //popup.Width = 350;
                popup.VerticalOffset = 370;
                popup.HorizontalOffset = 0;


                WindowsPhoneControl1 control = new WindowsPhoneControl1();
                popup.Child = control;
                fuckedupcounter5 = 1;

                popup.IsOpen = true;


                control.frwrd_button.Click += (s, args) =>
                {
                    fuckedupcounter5 = 0;
                    popup.IsOpen = false;
                    try
                    {
                        wb5.InvokeScript("eval", "history.go(1)");
                    }
                    catch
                    {
                        MessageBox.Show("Unable to go forward");
                    }
                    

                };

                control.cancel_button.Click += (s, args) =>
                {
                    fuckedupcounter5 = 0;
                    popup.IsOpen = false;
                };
                control.bookmark_button.Click += (s, args) =>
                {
                    fuckedupcounter5 = 0;
                    popup.IsOpen = false;
                    if (tb5.Text != "")
                    {

                        popup = new Popup();
                        create_bookmark controlnested = new create_bookmark();
                        popup.Child = controlnested;
                        popup.IsOpen = true;
                        controlnested.book_url.Text = tb5.Text;

                        controlnested.cancelButton.Click += (s1, args1) =>
                        {
                            popup.IsOpen = false;
                        };
                        controlnested.add_book.Click += (s1, args1) =>
                        {

                            if (controlnested.book_name.Text == "")
                            {
                                MessageBox.Show("Please enter a name");
                            }

                            else if (controlnested.book_url.Text.Contains("http://") || controlnested.book_url.Text.Contains("https://"))
                            {
                                try
                                {
                                    IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
                                    string sfile = "book.text";

                                    StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                                    writer.WriteLine(controlnested.book_name.Text);
                                    writer.WriteLine(controlnested.book_url.Text);
                                    writer.Close();
                                    popup.IsOpen = false;
                                    MessageBox.Show("Bookmark Added");
                                }
                                catch { MessageBox.Show("Unable to add bookmark"); }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Url");
                            }
                        };

                    }
                    else
                        MessageBox.Show("No url to bookmark. Please enter a url");
                };


            }
        }

        private void r1_MouseLeftButtonDown(object sender, EventArgs e)
        {
            try
            {

                if (tb1.Text != "")
                {
                    //if (history.Peek() != null)
                    wb1.InvokeScript("eval", "if(history.length>0){history.go()}");
                }
                else
                    MessageBox.Show("Cannot refresh an Empty page!");
            }
            catch(System.SystemException) 
            {
                MessageBox.Show("Unable to refresh");
                return;
            }
           
        }

        private void r2_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (current1 == null)
                MessageBox.Show("Unable to refresh!!");
            else
            { wb2.Navigate(new Uri(current1.ToString(), UriKind.Absolute)); }
           
        }
        

        private void r3_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (current2 == null)
                MessageBox.Show("Unable to refresh!!");
            else
            { wb3.Navigate(new Uri(current2.ToString(), UriKind.Absolute)); }
           
            
        }

        private void r4_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (current3 == null)
                MessageBox.Show("Unable to refresh!!");
            else
            { wb4.Navigate(new Uri(current3.ToString(), UriKind.Absolute)); }
           
            
        }

        private void r5_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (current4 == null)
                MessageBox.Show("Unable to refresh!!");
            else
            { wb5.Navigate(new Uri(current4.ToString(), UriKind.Absolute)); }
            
        }
        private void wb1_Navigated(object sender, NavigationEventArgs e)
        {
            ProgBar1.Visibility = Visibility.Collapsed;
            current = e.Uri;
            tb1.Text = current.ToString();
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }
            
            
            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append , myfile));
           
            writer.WriteLine(tb1.Text);
            writer.Close();

            
            
        }


        private void wb1_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgBar1.Visibility = Visibility.Visible;
            ProgBar1.Margin = new Thickness(0, -2, 0, 0);
            
        }

        private void wb2_Navigated(object sender, NavigationEventArgs e)
        {
            
            ProgBar2.Visibility = Visibility.Collapsed;
            current1 = e.Uri;
            tb2.Text = current1.ToString();
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }

            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));
            //writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.WriteLine(tb2.Text);
            writer.Close();
            
        }

        private void wb2_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgBar2.Visibility = Visibility.Visible;
            ProgBar2.Margin = new Thickness(0, -25, 0, 0);
            
        }

        private void wb3_Navigated(object sender, NavigationEventArgs e)
        {
           
            ProgBar3.Visibility = Visibility.Collapsed;
            current2 = e.Uri;
            tb3.Text = current2.ToString();
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }

            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));
            //writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.WriteLine(tb3.Text);
            writer.Close();
        }

        private void wb3_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgBar3.Visibility = Visibility.Visible;
            ProgBar3.Margin = new Thickness(0, -25, 0, 0);
        }

        private void wb4_Navigated(object sender, NavigationEventArgs e)
        {
           
            ProgBar4.Visibility = Visibility.Collapsed;
            current3 = e.Uri;
            tb4.Text = current3.ToString();
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }

            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));
            //writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.WriteLine(tb4.Text);
            writer.Close();
        }

        private void wb4_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgBar4.Visibility = Visibility.Visible;
            ProgBar4.Margin = new Thickness(0, -25, 0, 0);
        }

        private void wb5_Navigated(object sender, NavigationEventArgs e)
        {
           
            ProgBar5.Visibility = Visibility.Collapsed;
            current4 = e.Uri;
            tb5.Text = current4.ToString();
            IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
            string sfile = "data.txt";
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }

            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));
            //writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.WriteLine(tb5.Text);
            writer.Close();
        }

        private void wb5_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgBar5.Visibility = Visibility.Visible;
            ProgBar5.Margin = new Thickness(0,-25,0,0);
        }

        private void wb1_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            ProgBar1.Visibility = Visibility.Collapsed;

        }

        private void wb2_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            ProgBar2.Visibility = Visibility.Collapsed;
        }

        private void wb3_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            ProgBar3.Visibility = Visibility.Collapsed;
        }

        private void wb4_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            ProgBar4.Visibility = Visibility.Collapsed;
        }

        private void wb5_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            ProgBar5.Visibility = Visibility.Collapsed;
        }

        
        private void tb2_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tb2.SelectAll();
        }


        private void tb1_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tb1.SelectAll();
        }

        private void tb3_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tb3.SelectAll();
        }

        private void tb4_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tb4.SelectAll();
        }

        private void tb5_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tb5.SelectAll();
        }

        
        //public void history_load(string x)
        //{
           
        //    h20.Content = h19.Content;
        //    h19.Content = h18.Content;
        //    h18.Content = h17.Content;
        //    h17.Content = h16.Content;
        //    h16.Content = h15.Content;
        //    h15.Content = h14.Content;
        //    h14.Content = h13.Content;
        //    h13.Content = h12.Content;
        //    h12.Content = h11.Content;
        //    h11.Content = h10.Content;
        //    h10.Content = h9.Content;
        //    h9.Content = h8.Content;
        //    h8.Content = h7.Content;
        //    h7.Content = h6.Content;
        //    h6.Content = h5.Content;
        //    h5.Content = h4.Content;
        //    h4.Content = h3.Content;
        //    h3.Content = h2.Content;
        //    h2.Content = h1.Content;


        //    if (x != "")
        //        h1.Content = x;
           
           
        //}

        //private void h1_Click(object sender, RoutedEventArgs e)
        //{
        //    string a = h1.Content.ToString();
        //    wb5.Navigate(new Uri(a, UriKind.Absolute));
        //}


       }

        }