﻿using System;
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

namespace CamDo
{
    /// <summary>
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        public ManagementWindow()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_customer.Visibility = Visibility.Collapsed;
                tt_pawn.Visibility = Visibility.Collapsed;
                tt_remind.Visibility = Visibility.Collapsed;
                tt_search.Visibility = Visibility.Collapsed;
                tt_manage.Visibility = Visibility.Collapsed;
                tt_expense.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_customer.Visibility = Visibility.Visible;
                tt_pawn.Visibility = Visibility.Visible;
                tt_remind.Visibility = Visibility.Visible;
                tt_search.Visibility = Visibility.Visible;
                tt_manage.Visibility = Visibility.Visible;
                tt_expense.Visibility = Visibility.Visible;
            }
        }
    }
}
