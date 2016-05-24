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
using System.Windows.Shapes;
using Logic.Validators;
using Logic.Repositories;
using Logic.Formatters;
using Logic;
using Logic.XML;
using Logic.Entities;
using System.Windows.Forms;
using System.Media;
using Logic.Exceptions;

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            initComponents();
        }

        /// <summary>
        /// körs vid start av programmet
        /// </summary>
        public void initComponents()
        {
            tbFeedName.Visibility = Visibility.Hidden;
            labelFeedName.Visibility = Visibility.Hidden;
            btnFeedName.Visibility = Visibility.Hidden;
            labelAddFavSearch.Visibility = Visibility.Hidden;
            btnAddCatShow.Visibility = Visibility.Hidden;
            cbCatAddFav.Visibility = Visibility.Hidden;
            tbNewCat.Visibility = Visibility.Hidden;
            btnAddCat.Visibility = Visibility.Hidden;
            tbEditCatName.Visibility = Visibility.Hidden;
            labelEditCatName.Visibility = Visibility.Hidden;
            btnDeleteCat.Visibility = Visibility.Hidden;
            btnEditCatOK.Visibility = Visibility.Hidden;
            tbInterval1.Visibility = Visibility.Hidden;
            labelInterval.Visibility = Visibility.Hidden;
            labelAddCat.Visibility = Visibility.Hidden;
            tbAddCat.Visibility = Visibility.Hidden;
            btnAddCatAccept.Visibility = Visibility.Hidden;

            List<String> categories = loadXML.addCatToCb();
            foreach (var item in categories)
            {
                cbCategory.Items.Add(item);
                cbCatAddFav.Items.Add(item);
            }

            if (cbCategory.SelectedIndex != -1)
            {
                List<String> feeds = loadXML.loadLocalCategoryFeed(cbCategory.SelectedItem.ToString());
                foreach (var feed in feeds)
                {
                    cbFeeds.Items.Add(feed);
                }
            }


        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            lwFeed.Items.Clear();
            var url = tbUrl.Text;  //hämtar url från tbUrl
            if (url[0] != 'h')
            {
                url = "http://" + url;
            }
            // kollar så att urlen är angiven korrekt
            if (validateURL.checkURL(url))
            {

                retrieveRssDataRepository ret = new retrieveRssDataRepository();
                List<Logic.Entities.FeedItem> items = ret.retrieveData(url);   // hämtar feeditems o lägger dem i en lista

                foreach (var item in items)
                {

                    // Formaterar Date så den visar snyggare --
                    string date = formatDate.FormatDate(item.date.ToString());

                    // ------------------------------------------

                    //---OBS----OBS------// OBS!!!! måste göra om denna sen för att kolla om filen redan finns på datorn
                    var downloaded = "";
                    bool check = checkFileExistRepository.checkFileExist(item.title);
                    if (check == true)
                    {
                        downloaded = "Yes";
                    }
                    else
                    {
                        downloaded = "No";
                    }

                    lwFeed.Items.Add(new { Title = item.title.ToString(), Date = date, Downloaded = downloaded, File = item.mediaUrl.ToString() });
                }


                // kör funktionen för att hämta generell info om podcasten
                string[] info = ret.catchInfo(url);
                string title = info[0];
                string image = info[1];

                if (image != null){
                    //skapar bitmap
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(image, UriKind.Absolute);
                    bitmap.EndInit();

                    //sätter värden på controls
                    labelChannel.Content = title;
                    imgChannel.Source = bitmap;
                }
            }


            else
            {
                tbUrl.Text = "Vänligen ange en korrekt RSS URL";
            }
        }

        private void btnAddFavorite_Click(object sender, RoutedEventArgs e)
        {
            // när man vill lägga till något så visas nya textboxes för att ange feednamn etc
            tbFeedName.Visibility = Visibility.Visible;
            labelFeedName.Visibility = Visibility.Visible;
            btnFeedName.Visibility = Visibility.Visible;
            labelAddFavSearch.Visibility = Visibility.Visible;
            btnAddCatShow.Visibility = Visibility.Visible;
            cbCatAddFav.Visibility = Visibility.Visible;
            tbInterval1.Visibility = Visibility.Visible;
            labelInterval.Visibility = Visibility.Visible;
        }

        private void btnFeedName_Click(object sender, RoutedEventArgs e)
        {

            var url = tbUrl.Text;
            retrieveRssDataRepository ret = new retrieveRssDataRepository();
            List<Logic.Entities.FeedItem> podItems = ret.retrieveData(url);
            string category = cbCatAddFav.SelectedItem.ToString();
            int interval;
            if (tbInterval1.Text != "")
            {
                interval = Int32.Parse(tbInterval1.Text);
            }
            else {
                interval = 10;
            }
            if (validateURL.checkURL(tbUrl.Text) == true)   // validerar urlen

                if (tbFeedName.Text == string.Empty) // körs om inget namn anges
                {
                    try
                    {
                        favoriteFeed.saveFeed(podItems, interval, category, url);
                    }
                    catch (ValidationException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }

                }
                else   // körs om namn anges
                {
                    favoriteFeed.saveFeed(podItems, tbFeedName.Text, interval, category, url);
                }

            // döljer återigen textboxes
            tbFeedName.Visibility = Visibility.Hidden;
            labelFeedName.Visibility = Visibility.Hidden;
            btnFeedName.Visibility = Visibility.Hidden;
            labelAddFavSearch.Visibility = Visibility.Hidden;
            btnAddCatShow.Visibility = Visibility.Hidden;
            cbCatAddFav.Visibility = Visibility.Hidden;
            tbInterval1.Visibility = Visibility.Hidden;
            labelInterval.Visibility = Visibility.Hidden;

            cbFeeds.Items.Clear();
            List<String> feeds = loadXML.getFeed();
            foreach (var item in feeds)
            {
                cbFeeds.Items.Add(item);
            }

            cbFeeds.SelectedIndex = 0;

        }

        



        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (lwFeed.SelectedIndex != -1)
            {
                var podcastitem = lwFeed.SelectedItem.ToString();
                var mediaFile = playMedia.playFile(podcastitem);
                mediaPlayer.Source = new Uri(mediaFile, UriKind.Absolute);
                mediaPlayer.Play();
                saveXML.saveListened(mediaFile);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btnDL_Click(object sender, RoutedEventArgs e)
        {
            downloadFilesRepository.downloadPod(lwFeed.SelectedItem.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbDir.Text = dialog.SelectedPath.ToString();
            }

            var path = dialog.SelectedPath.ToString();
            saveDownLoadPathRepository.saveDownLoadPath(path);
        }

        private void btnAddFav_Click(object sender, RoutedEventArgs e)
        {
            labelAddCat.Visibility = Visibility.Visible;
            tbAddCat.Visibility = Visibility.Visible;
            btnAddCatAccept.Visibility = Visibility.Visible;
        }

        private void btnAddCatShow_Click(object sender, RoutedEventArgs e)
        {
            tbNewCat.Visibility = Visibility.Visible;
            btnAddCat.Visibility = Visibility.Visible;
        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            tbNewCat.Visibility = Visibility.Hidden;
            btnAddCat.Visibility = Visibility.Hidden;
            var category = tbNewCat.Text;
            saveXML.saveCategory(category);

            cbCategory.Items.Clear();
            cbCatAddFav.Items.Clear();
            List<String> categories = loadXML.addCatToCb();
            foreach (var item in categories)
            {
                cbCategory.Items.Add(item);
                cbCatAddFav.Items.Add(item);
            }
        }

        private void btnEditCat_Click(object sender, RoutedEventArgs e)
        {
            tbEditCatName.Visibility = Visibility.Visible;
            labelEditCatName.Visibility = Visibility.Visible;
            btnDeleteCat.Visibility = Visibility.Visible;
            btnEditCatOK.Visibility = Visibility.Visible;
        }

        private void btnEditCatOK_Click(object sender, RoutedEventArgs e)
        {
            tbEditCatName.Visibility = Visibility.Hidden;
            labelEditCatName.Visibility = Visibility.Hidden;
            btnDeleteCat.Visibility = Visibility.Hidden;
            btnEditCatOK.Visibility = Visibility.Hidden;

        }

        private void btnAddCatAccept_Click(object sender, RoutedEventArgs e)
        {
            labelAddCat.Visibility = Visibility.Hidden;
            tbAddCat.Visibility = Visibility.Hidden;
            btnAddCatAccept.Visibility = Visibility.Hidden;
            var category = tbAddCat.Text;
            if (validateCategory.checkCategory(category))
            {
                saveXML.saveCategory(category);
                cbCategory.Items.Clear();
                cbCatAddFav.Items.Clear();
                List<String> categories = loadXML.addCatToCb();
                foreach (var item in categories)
                {
                    cbCategory.Items.Add(item);
                    cbCatAddFav.Items.Add(item);
                }
            }

        }

        private void btnDL_Local_Click(object sender, RoutedEventArgs e)
        {
            downloadFilesRepository.downloadPod(lwFavFeed.SelectedItem.ToString());
        }

        private void cbFeeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lwFavFeed.Items.Clear();

            if (cbFeeds.Items.Count > 0)
            {
                try
                {
                    string feedName = cbFeeds.SelectedItem.ToString();
                    List<FeedItem> localFeed = loadXML.loadLocalFeed(feedName);
                    foreach (var item in localFeed)
                    {

                        var downloaded = "";
                        bool check = checkFileExistRepository.checkFileExist(item.title);
                        if (check == true)
                        {
                            downloaded = "Yes";
                        }
                        else
                        {
                            downloaded = "No";
                        }

                        lwFavFeed.Items.Add(new { Title = item.title.ToString(), Date = item.date.ToString(), Downloaded = downloaded, File = item.mediaUrl.ToString() });
                    }
                    var interval = loadXML.loadLocalFeedInteval(feedName);
                    labelCurrentInterval.Content = interval;
                    int timerInterval = Int32.Parse(interval) * 60000;
                    Timer timer = new Timer();
                    timer.Interval = timerInterval;
                    timer.Tick += Timer_Tick;
                    timer.Start();

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

        }

        void Timer_Tick(object sender, EventArgs e)
        {

                int interval = 0;
                Int32.TryParse(labelCurrentInterval.Content.ToString(), out interval);
                var url = loadXML.loadLocalFeedUrl(cbFeeds.SelectedItem.ToString());
                try
                {
                    lwFavFeed.Items.Clear();
                    retrieveRssDataRepository ret = new retrieveRssDataRepository();
                    List<FeedItem> feed = ret.retrieveData(url);
                    foreach (var item in feed)
                    {
                        var downloaded = "";
                        bool check = checkFileExistRepository.checkFileExist(item.title);
                        if (check == true)
                        {
                            downloaded = "Yes";
                        }
                        else
                        {
                            downloaded = "No";
                        }
                        lwFavFeed.Items.Add(new { Title = item.title.ToString(), Date = item.date.ToString(), Downloaded = downloaded, File = item.mediaUrl.ToString() });
                        saveXML.removeFeed(cbFeeds.SelectedItem.ToString());
                        favoriteFeed.saveFeed(feed, cbFeeds.SelectedItem.ToString(), interval, cbCategory.SelectedItem.ToString(), url);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }

           
        }

        private void btnRemoveFav_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("You are about to delete the feed, are you sure?", "Attention", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                saveXML.removeFeed(cbFeeds.SelectedItem.ToString());
                cbFeeds.Items.Clear();
                List<String> feeds = loadXML.getFeed();
                foreach (var item in feeds)
                {
                    cbFeeds.Items.Add(item);
                }
            }
        }

        private void btnPlayFav_Click(object sender, RoutedEventArgs e)
        {
            if (lwFavFeed.SelectedIndex != -1)
            {
                var podcastitem = lwFavFeed.SelectedItem.ToString();
                var mediaFile = playMedia.playFile(podcastitem);
                try
                {
                    mediaElementFavs.Source = new Uri(mediaFile, UriKind.Absolute);
                    mediaElementFavs.Play();
                    saveXML.saveListened(mediaFile);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPauseFav_Click(object sender, RoutedEventArgs e)
        {
            mediaElementFavs.Pause();
        }

        private void sliderVol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //mediaPlayer.Volume = sliderVol.Value;
        }

        private void sliderVolFav_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //mediaElementFavs.Volume = sliderVol.Value;
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFeeds.Items.Clear();
            if (cbCategory.SelectedIndex != -1)
            {
                List<String> feeds = loadXML.loadLocalCategoryFeed(cbCategory.SelectedItem.ToString());
                foreach (var feed in feeds)
                {
                    cbFeeds.Items.Add(feed);
                }
                cbFeeds.SelectedIndex = 0;
            }
        }

        private void btnEditFeed_Click(object sender, RoutedEventArgs e)
        {
            EditFeedItem editWindows = new EditFeedItem(cbFeeds.SelectedItem.ToString());
            editWindows.Show();
        }

        private void btnPlayWMP_Click(object sender, RoutedEventArgs e)
        {
            if (lwFeed.SelectedIndex != -1)
            {
                var podcastitem = lwFeed.SelectedItem.ToString();
                var mediaFile = playMedia.playFile(podcastitem);

                try
                {
                    playMedia.playWMP(mediaFile);
                    saveXML.saveListened(mediaFile);
                }
                
                catch ( Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnPlayWMPFav_Click(object sender, RoutedEventArgs e)
        {
            if (lwFavFeed.SelectedIndex != -1)
            {
                var podcastitem = lwFavFeed.SelectedItem.ToString();
                var mediaFile = playMedia.playFile(podcastitem);
                try
                {
                    playMedia.playWMP(mediaFile);
                    saveXML.saveListened(mediaFile);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
