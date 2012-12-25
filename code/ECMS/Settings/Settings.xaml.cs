using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ECMS
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void changePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.ChangePassword ChangePasswordObj = new ECMS.ChangePassword();
            ChangePasswordObj.Show();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveChangesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
