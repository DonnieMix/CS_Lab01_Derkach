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
using Lab01_Derkach.ViewModels;

namespace Lab01_Derkach.Views
{
    /// <summary>
    /// Логика взаимодействия для CalendarView.xaml
    /// </summary>
    public partial class CalendarView : Window
    {
        private CalendarViewModel _viewModel;

        public CalendarView()
        {
            _viewModel = new CalendarViewModel(this);
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.DatePicker_SelectedDateChanged(sender, e);
        }
    }
}
