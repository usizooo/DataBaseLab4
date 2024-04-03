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

namespace DataBaseLab4
{
    /// <summary>
    /// Логика взаимодействия для CatsSitterEFPage.xaml
    /// </summary>
    public partial class CatsSitterEFPage : Page
    {
        private CatCafeEntities context = new CatCafeEntities();
        public CatsSitterEFPage()
        {
            InitializeComponent();
            catsSittersDataGrid.ItemsSource = context.catsitter.ToList();
            OutlinedComboBox.ItemsSource = context.catsitter.ToList();
        }

        private void SearchOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsSittersDataGrid.ItemsSource = context.catsitter.ToList().Where(catsitter => catsitter.surname.Contains(SearchTxt.Text));
        }

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsSittersDataGrid.ItemsSource = context.catsitter.ToList();
        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OutlinedComboBox.SelectedItem != null)
            {
                var selected = OutlinedComboBox.SelectedItem as catsitter;
                catsSittersDataGrid.ItemsSource = context.catsitter.ToList().Where(catsitter => catsitter.workexperience == selected.workexperience);
            }
        }
    }
}
