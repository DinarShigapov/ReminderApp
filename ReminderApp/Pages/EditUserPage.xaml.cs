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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User contextUser;
        public EditUserPage()
        {
            InitializeComponent();
            LVUser.ItemsSource = App.DB.User.Where(x => x.Id != App.LoggedUser.Id).ToList();
        }

        private void BEd_Click(object sender, RoutedEventArgs e)
        {
            var ds = (sender as Button).DataContext as User;
            if (ds == null)
                return;

            contextUser = ds;
            SPUser.DataContext = ds;
            SPUser.Visibility = Visibility.Visible;
            LVUser.Visibility = Visibility.Collapsed;
        }

        private void BEditUser_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextUser.Name) == true)
            {
                errorMessage += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Login) == true)
            {
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Password) == true)
            {
                errorMessage += "Введите пароль\n";
            }
            
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            App.DB.SaveChanges();
            Refresh();

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            SPUser.Visibility = Visibility.Collapsed;
            LVUser.Visibility = Visibility.Visible;
            DataContext = null;
            LVUser.ItemsSource = App.DB.User.Where(x => x.Id != App.LoggedUser.Id).ToList();
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            var ds = (sender as Button).DataContext as User;
            if (ds == null)
                return;

            App.DB.User.Remove(ds);
            App.DB.SaveChanges();
            Refresh();
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            App.LoggedUser = null;
        }
    }
}
