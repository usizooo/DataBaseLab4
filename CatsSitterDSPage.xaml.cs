using DataBaseLab4.CatCafeDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DataBaseLab4
{
    /// <summary>
    /// Логика взаимодействия для CatsSitterDSPage.xaml
    /// </summary>
    public partial class CatsSitterDSPage : Page
    {
        catsitterTableAdapter catsitters = new catsitterTableAdapter();
        public CatsSitterDSPage()
        {
            InitializeComponent();
            catsSittersDataGrid.ItemsSource = catsitters.GetData();
            OutlinedComboBox.ItemsSource = catsitters.GetData();
            OutlinedComboBox.DisplayMemberPath = "workexperience";
        }

        private void SearchOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsSittersDataGrid.ItemsSource = catsitters.SearchByName(SearchTxt.Text);
        }

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsSittersDataGrid.ItemsSource = catsitters.GetData();
        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OutlinedComboBox.SelectedItem != null)
            {
                var work = (int)(OutlinedComboBox.SelectedItem as DataRowView).Row[4];
                catsSittersDataGrid.ItemsSource = catsitters.FilterByWorkexperience(work);
            }

        }
    }
}
