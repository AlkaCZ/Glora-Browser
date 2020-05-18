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
using Gecko;
using System.Windows.Forms.Integration;
using Gecko.Events;
using System.IO;

namespace Browser_Glora_1._0
{

    public partial class MainWindow : Window
    {
        GeckoWebBrowser browser = new GeckoWebBrowser();


        public MainWindow()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            GeckoBrowser.Child = browser;


        }
        Stream stream = new FileStream("history.txt", FileMode.Create);
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://developer.mozilla.org/en-US/docs/Mozilla");
        }

        private void B_Go_Click(object sender, RoutedEventArgs e)
        {
            if (SerchBar.Text != null)
            {

                if (SerchBar.Text.Contains("https://www."))
                {
                    browser.Navigate(SerchBar.Text);
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();

                    //}

                }
                else if (SerchBar.Text.Contains("www."))
                {
                    SerchBar.Text = "https://" + SerchBar.Text;
                    browser.Navigate(SerchBar.Text);
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();

                    //}

                }
                else
                {
                    SerchBar.Text = "https://" + "www." + SerchBar.Text;
                    browser.Navigate(SerchBar.Text);
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();
                    //}


                }
            }
        }




        private void B_Home_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://developer.mozilla.org/en-US/docs/Mozilla");
            SerchBar.Text = null;
        }

        private void B_Forward_Click(object sender, RoutedEventArgs e)
        {

            browser.GoBack();
        }

        private void B_Backward_Click(object sender, RoutedEventArgs e)
        {
            browser.GoForward();
        }

        private void GeckoBrowser_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }
    }
    public class IsLoaded
    {
        public string SearchText { get; set; }
        public bool SearchTestIsNull(string t)
        {
            if (t == null)
            {
                return false;
            }
            return true;
        }


    }
    public class NoMoveForward
    {
        public int Max { get; set; }
        public int CurrentPosition { get; set; }
        public bool CantMove(int m, int c)
        {
            if (c >= m)
            {
                return true;
            }


            return false;

        }
    }
    public class NoMoveBack
    {
        public int Min { get; set; }
        public int CurrentPosition { get; set; }
        public bool CantMove(int m, int c)
        {
            if (c <= m)
            {
                return true;
            }


            return false;

        }
    }

}
