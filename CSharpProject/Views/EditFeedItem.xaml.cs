using Logic.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for EditFeedItem.xaml
    /// </summary>
    public partial class EditFeedItem : Window
    {
        public EditFeedItem(string originalName)
        {
            InitializeComponent();
            labelName.Content = originalName;

            List<String> categories = loadXML.addCatToCb();
            foreach (var item in categories)
            {
                cbEditCategory.Items.Add(item);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9.-]+");
                int interval;
                string name = tbEditFeedName.Text;
                if (tbEditInterval.Text != "" && regex.IsMatch(tbEditInterval.Text))
                {
                    interval = Int32.Parse(tbEditInterval.Text);
                }
                else
                {
                    interval = 10;
                }
                string category = cbEditCategory.Text;

                saveXML.editCategory(name, interval, category, labelName.Content.ToString());

                this.Hide();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }
    }
}
