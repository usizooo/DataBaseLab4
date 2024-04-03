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
    /// Логика взаимодействия для CatsEFPage.xaml
    /// </summary>
    public partial class CatsEFPage : Page
    {
        CatCafeEntities context = new CatCafeEntities();
        public CatsEFPage()
        {
            InitializeComponent();
            catsDataGrid.ItemsSource = context.cats.ToList();
            OutlinedComboBox.ItemsSource = context.catsitter.ToList();
        }

        private void SearchOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsDataGrid.ItemsSource = context.cats.ToList().Where(cats => cats.nickname.Contains(SearchTxt.Text));
        }

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {
            catsDataGrid.ItemsSource = context.cats.ToList();
        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OutlinedComboBox.SelectedItem != null) 
            {
                var selectedCatsitter = OutlinedComboBox.SelectedItem as catsitter;
                int selectedCatsitterId = selectedCatsitter.ID_catsitter;
                catsDataGrid.ItemsSource = context.cats.Where(cat => cat.ID_catsitter == selectedCatsitterId).ToList();
            }
        }
    }
}
