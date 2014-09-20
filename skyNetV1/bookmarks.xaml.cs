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
using System.ComponentModel;

namespace skyNetV1
{
    public partial class bookmarks : PhoneApplicationPage
    {
        IsolatedStorageFile myfile = IsolatedStorageFile.GetUserStoreForApplication();
        string sfile = "book.text";
        StreamReader reader;
        Button btn;
        string[] stack = new string[1000];
        int k = 0,maxk,buttons_made=0;

        public bookmarks()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            bookmark_stackpanel.Children.Clear();
           
            if (!myfile.FileExists(sfile))
            {
                IsolatedStorageFileStream datafile = myfile.CreateFile(sfile);
                datafile.Close();
            }
            reader = new StreamReader(new IsolatedStorageFileStream(sfile, FileMode.Open, myfile));
           string name=reader.ReadLine();
           string url = reader.ReadLine();
           if (name == null && url == null)
           {
               reader.Close();
               TextBlock txt = new TextBlock();
               txt.Text = "List is EMPTY";
               txt.Height = 70;
               txt.Width = 400;
               txt.FontSize = 45;
               txt.Margin = new Thickness(100, 100, 20, 20);


               bookmark_stackpanel.Children.Add(txt);

           }
           else
           {
               while (name != null && url != null)
               {
                   stack[k++] = name;
                   stack[k++] = url;
                   if (k >= 1001)
                   {
                       MessageBox.Show("You have reached maximum capacity. Latest Bookmarks will not be shown. Delete old Bookmarks to view new ones.");
                       break;
                   }
                   else
                   {
                       name=reader.ReadLine();
                       url = reader.ReadLine();
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
                   btn.Width = 350;
                   btn.Tag = stack[k--];
                   btn.Content = stack[k];


                   btn.Click += btn_click;
                   bookmark_stackpanel.Children.Add(btn);
                   if (k == 0)
                       break;

               }
           }
           
        }
        protected void btn_click(object sender, RoutedEventArgs e)
        {
            Button buton = sender as Button;
            string a = buton.Tag.ToString();
            bookmark_stackpanel.Children.Clear();
            k = 0;
            NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + a, UriKind.Relative));
        }

        private void only_add_Click(object sender, RoutedEventArgs e)
        {
            if (bookmark_name1.Text == "")
            {
                MessageBox.Show("Please enter Bookmark name");
            }
            else if (bookmark_url1.Text == "https://")
            {
                MessageBox.Show("Please enter a Url");
            }
            else
            {
                StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                writer.WriteLine(bookmark_name1.Text);
                writer.WriteLine(bookmark_url1.Text);
                writer.Close();
                MessageBox.Show("Bookmark Added");

                NavigationService.Navigate(new Uri("/MainPage.xaml?", UriKind.Relative));
            }
        }

        private void clear_bookmarks(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all bookmarks?", "Confirm Delete?",
                                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (myfile.FileExists(sfile))
                {


                    myfile.DeleteFile(sfile);

                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                else
                    MessageBox.Show("No bookmarks to delete");
                
            }
           
        }

        private void appbar_button2_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                MessageBox.Show("No more Bookmarks");
            }
            else
            {
                buttons_made = 0;
                bookmark_stackpanel.Children.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    k = k - 1;
                    buttons_made++;
                    btn = new Button();
                    btn.Height = 70;
                    btn.Width = 350;
                    btn.Tag = stack[k--];
                    btn.Content = stack[k];


                    btn.Click += btn_click;
                    bookmark_stackpanel.Children.Add(btn);
                    if (k == 0)
                        break;

                }

            }
        }

        private void appbar_button3_Click(object sender, EventArgs e)
        {
             if ((2*buttons_made + k) >= maxk)
            {
                MessageBox.Show("No more latest Bookmarks");
            }
            else
            {

               bookmark_stackpanel.Children.Clear();
                if (stack[2*buttons_made + k + 15] != null)
                    k = 2*buttons_made + k + 15;
                //else if (stack[2*buttons_made + k + 6] != null)
                //    k = 2*buttons_made + k + 6;
                //else if (stack[2*buttons_made + k + 5] != null)
                //    k = 2*buttons_made + k + 5;
                //else if (stack[2*buttons_made + k + 4] != null)
                //    k = 2*buttons_made + k + 4;
                //else if (stack[2*buttons_made + k + 3] != null)
                //    k = 2*buttons_made + k + 3;
                //else if (stack[2*buttons_made + k + 2] != null)
                //    k = 2*buttons_made + k + 2;
                //else if (stack[2*buttons_made + k + 1] != null)
                //    k = 2*buttons_made + k + 1;
                //else if (stack[2*buttons_made + k] != null)
                //    k = 2*buttons_made + k;

                buttons_made = 0;

                for (int i = 1; i <= 8; i++)
                {

                    buttons_made++;
                    btn = new Button();
                    btn.Height = 70;
                    btn.Width = 350;
                    btn.Tag = stack[k--];
                    btn.Content = stack[k];

                    k--;
                    btn.Click += btn_click;
                   bookmark_stackpanel.Children.Add(btn);
                    if (k == -1)
                        break;
                }
                k = k + 1;
            }
        }

       

        private void add_redirect1_Click(object sender, RoutedEventArgs e)
        {
             if (bookmark_name1.Text == "")
            {
                MessageBox.Show("Please enter Bookmark name");
            }
             else if (bookmark_url1.Text == "https://")
             {
                 MessageBox.Show("Please enter a Url");
             }
             else
             {
                 StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(sfile, FileMode.Append, myfile));

                 writer.WriteLine(bookmark_name1.Text);
                 writer.WriteLine(bookmark_url1.Text);
                 writer.Close();
                 MessageBox.Show("Bookmark Added");
                 bookmark_stackpanel.Children.Clear();

                 NavigationService.Navigate(new Uri("/browserPage.xaml?key=" + bookmark_url1.Text, UriKind.Relative));
             }
        }


    }
}