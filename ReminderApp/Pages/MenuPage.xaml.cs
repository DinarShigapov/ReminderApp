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
using ReminderApp.Model;

namespace ReminderApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        Reminder reminderContext = new Reminder() { User = App.LoggedUser };

        public MenuPage()
        {
            InitializeComponent();
            DataContext = reminderContext;
            DPTime.Text = DateTime.Now.ToString();
            Refresh();
        }

        private void Refresh() 
        {
            LVReminder.ItemsSource = App.DB.Reminder.Where(x => x.UserId == App.LoggedUser.Id).ToList();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var selectDate = DPTime.SelectedDate;
            string error = "";
            if (selectDate == null)
            {
                error = "Укажите дату\n";
            }
            if (reminderContext.Description == null || reminderContext.Description == "")
            {
                error = "Введите описание\n";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            reminderContext.Date = selectDate.Value;


            App.DB.Reminder.Add(reminderContext);
            App.DB.SaveChanges();
            Refresh();
        }
    }
}
