using IMDBApplication.Entities;
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

namespace IMDBApplication
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {
        public Info(ImdbRow item)
        {
            InitializeComponent();
            SetData(item);
        }

        private void SetData(ImdbRow item)
        {
            image.Source = new BitmapImage(new Uri(item.Poster));
            tbTtitle.Text = item.Title;
            tbImdbRating.Text = item.ImdbRating;
            tbLanguage.Text = item.Language;
            tbReleased.Text = item.Released;
            tbCountry.Text = item.Country;
            tbImdbVotes.Text = item.ImdbVotes;
            tbGenre.Text = item.Genre;
            tbWriter.Text = item.Writer;


        }
    }
}
