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

        Reminder reminderContext = new Reminder();

        public MenuPage()
        {
            InitializeComponent();
            DataContext = reminderContext;
            LVReminder.ItemsSource = App.DB.Reminder.ToList();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            if (reminderContext.Date == null)
            {
                error = "Введите дату\n";
                return;
            }
            if (reminderContext.Description == null || reminderContext.Description == "")
            {
                error = "Введите описание\n";
                return;
            }

            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            App.DB.Reminder.Add(reminderContext);
            App.DB.SaveChanges();
        }
    }
}
