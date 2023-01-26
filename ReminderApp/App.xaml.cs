﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ReminderApp.Model;

namespace ReminderApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ReminderDBEntities DB = new ReminderDBEntities();
        public static User LoggedUser;
    }
}
