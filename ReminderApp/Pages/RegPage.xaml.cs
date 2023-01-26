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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        User user = new User();

        public RegPage()
        {
            InitializeComponent();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(TBLogin.Text) == true)
            {
                error = "Введите корректный логин\n";
            }
            if (string.IsNullOrWhiteSpace(TBPassword.Text) == true)
            {
                error = "Введите корректный пароль\n";
            }

            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            user.Login = TBLogin.Text;
            user.Password = TBPassword.Text;


            App.DB.User.Add(user);
            App.DB.SaveChanges();
            MessageBox.Show("Успешный вход");
            NavigationService.GoBack();

        }
    }
}
