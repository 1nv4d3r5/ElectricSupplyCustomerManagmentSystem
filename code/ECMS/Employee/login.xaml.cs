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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {

        public delegate void delegateOnSucccesfulLogin(bool IsSuccess);
        public event delegateOnSucccesfulLogin OnSucccesfulLogin;

        public login()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OnSucccesfulLogin != null)
                OnSucccesfulLogin(false);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((userNameTxtbox.Text.Equals("1")) && (passwordPbox.Password.Equals("1")))
            {
                if (OnSucccesfulLogin != null)
                    OnSucccesfulLogin(true);

                this.Hide();
            }
            else
                MessageBox.Show("Wrong User Name or Password.");


            userNameTxtbox.Text = String.Empty;
            passwordPbox.Password = String.Empty;
        }

        //private void Enter_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    String uname;
        //    String passwd;

        //    if (User_Name_txt.TextInput = null)
        //    {
        //        MessageBox.Show("Please Give The Value of User_Name ........ ");
        //        return;
        //    }
        //    else if (Password_passwordBox.GetValue = null)
        //    {
        //        MessageBox.Show("Please Give The Value of Password ........ ");
        //        return;
        //    }

        //    ECMS.AllLoginwindow ea = new ECMS.AllLoginwindow();
        //    ea.ShowDialog();
        //}



    }
}
