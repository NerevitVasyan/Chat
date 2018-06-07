﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> mes = new ObservableCollection<string>();


        public MainWindow()
        {
            

            InitializeComponent();
            ListMessages.ItemsSource = mes;
            using (ChatEntities db = new ChatEntities())
            {
                var a = db.Messages.ToList();
                foreach(var item in a)
                {
                    mes.Add($"{item.Date}: {item.Text}");
                }
               
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message m = new Message() { Text = MyText.Text, Date = DateTime.Now };
            mes.Add($"{m.Date}: {m.Text}");
            using (ChatEntities db = new ChatEntities())
            {
               
                db.Messages.Add(m);
                db.SaveChanges();
            }
        }
    }
}