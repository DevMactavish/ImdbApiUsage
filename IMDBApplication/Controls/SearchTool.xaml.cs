using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using IMDBApplication.Entities;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;

namespace IMDBApplication
{
    /// <summary>
    /// Interaction logic for SearchTool.xaml
    /// </summary>
    public partial class SearchTool : UserControl
    {
        public SearchTool()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string ImdbId = ValidateImdbId();
            string apiLink = ConfigurationManager.AppSettings["ApiLink"];
            apiLink = String.Format(apiLink, ImdbId);

            System.Net.WebClient client = new System.Net.WebClient();
            string downloadedText = client.DownloadString(apiLink);
            CheckDownladedText(downloadedText);

            ImdbRow imdbRow = GetImdbRowObject(downloadedText);
            spInfo.Children.Clear();
            if (!String.IsNullOrEmpty(imdbRow.Poster))
            {
                spInfo.Children.Add(new Info(imdbRow));
                clearValues.IsEnabled = true;
            }
        }

        private void CheckDownladedText(string downloadedText)
        {
            if (downloadedText.Contains("Incorrect IMDb ID"))
                MessageBox.Show("Imdb Id not found.");
        }

        private ImdbRow GetImdbRowObject(string jsonText)
        {
            ImdbRow row = new ImdbRow();
            row = JsonConvert.DeserializeObject<ImdbRow>(jsonText);
            return row;
        }

        private string ValidateImdbId()
        {
            if (String.IsNullOrEmpty(tbImdbId.Text))
                MessageBox.Show("Imdb Id empty or null");
            else if (!tbImdbId.Text.StartsWith("tt"))
            {
                MessageBox.Show("Imdb ID must be start tt. Example 'tt3896198' ");
                ResetForm();
            }
            return tbImdbId.Text;
        }

        private void ResetForm()
        {
            tbImdbId.Text = "";
        }

        private void ClearValues_Click(object sender, RoutedEventArgs e)
        {
            spInfo.Children.Clear();
            clearValues.IsEnabled = false;
        }
    }
}
