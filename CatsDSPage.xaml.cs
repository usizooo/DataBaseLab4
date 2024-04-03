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
    /// Логика взаимодействия для CatsDSPage.xaml
    /// </summary>
    public partial class CatsDSPage : Page
    {
        catsTableAdapter cats = new catsTableAdapter();
        catsitterTableAdapter catsitter = new catsitterTableAdapter();
        public CatsDSPage()
        {
            InitializeComponent();
            catsDataGrid.ItemsSource = cats.GetData();
            OutlinedComboBox.ItemsSource = catsitter.GetData();
            OutlinedComboBox.DisplayMemberPath = "surname";
        }

        private void SearchOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsDataGrid.ItemsSource = cats.SearchByName(SearchTxt.Text);
        }

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsDataGrid.ItemsSource = cats.GetData();
        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OutlinedComboBox.SelectedItem != null)
            {
                var id = (int)(OutlinedComboBox.SelectedItem as DataRowView).Row[0];
                catsDataGrid.ItemsSource = cats.FilterBySitter(id); 
            }
        }
    }
}
