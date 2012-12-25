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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        login loginWindow;

        public MainWindow()
        {
            InitializeComponent();

            loginWindow = new login();
            loginWindow.OnSucccesfulLogin += new ECMS.login.delegateOnSucccesfulLogin(LoginWindowObj_OnSucccesfulLogin);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedIn == false)
            {
                //ECMS.login LoginWindowObj = new ECMS.login();
                //LoginWindowObj.OnSucccesfulLogin += new ECMS.login.delegateOnSucccesfulLogin(LoginWindowObj_OnSucccesfulLogin);
                //LoginWindowObj.ShowDialog();
                
            }
            else
            {
                //customerBrowserBtn.IsEnabled = false;
                //paymentBtn.IsEnabled = false;
                //newConnectionBtn.IsEnabled = false;
                //employeeBrowserBtn.IsEnabled = false;
                //estimateBtn.IsEnabled = false;
                //workOrderBtn.IsEnabled = false;
                //contractorBillBtn.IsEnabled = false;
                //contractorBrowserBtn.IsEnabled = false;
                //reportBtn.IsEnabled = false;
                //searchBtn.IsEnabled = false;
                //settingsBtn.IsEnabled = false;
                //helpBtn.IsEnabled = false;
                mainDocPanel.IsEnabled = false;

                loginBtn.Content = "Login";
                loginBtn.ToolTip = "Click to Login";
                LoggedIn = false;

                loginWindow.ShowDialog();
            }
        }

        bool LoggedIn = false;

        void LoginWindowObj_OnSucccesfulLogin(bool IsSuccess)
        {
            if (IsSuccess)
            {
                mainDocPanel.IsEnabled = true;
                loginBtn.Content = "Logout";
                loginBtn.ToolTip = "Click to Logout";
                LoggedIn = true;
            }
            else
            {
                this.Close();
            }
          
        }



        private void paymentBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Payment PaymentObj = new ECMS.Payment();
            PaymentObj.Show();
        }



        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void newConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Connection ConnectionObj = new ECMS.Connection();
            ConnectionObj.ShowDialog();
        }

        private void employeeBrowserBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Employee EmployeeObj = new ECMS.Employee();
            EmployeeObj.Show();
        }

        private void contractorBrowserBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Contractor ContractorObj = new ECMS.Contractor();
            ContractorObj.Show();
        }

        private void estimateBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.EstimationQuotationDisplay EstimationQuatationDisplayObj = new ECMS.EstimationQuotationDisplay();
            EstimationQuatationDisplayObj.Show();
        }

        private void customerBrowserBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Customer CustomerObj = new ECMS.Customer();
            CustomerObj.Show();
        }

        private void workOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.WorkOrder WorkOrderObj = new ECMS.WorkOrder();
            WorkOrderObj.Show();
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Settings SettingsObj = new ECMS.Settings();
            SettingsObj.Show();
        }

        private void searchBtn_Click_1(object sender, RoutedEventArgs e)
        {
            ECMS.Search SearchObj = new ECMS.Search();
            SearchObj.Show();
        }

        private void contractorBillBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.ContractorBill ContractorBillObj = new ECMS.ContractorBill();
            ContractorBillObj.Show();
        }


        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Report ReportObj = new ECMS.Report();
            ReportObj.Show();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!LoggedIn)
            {
                loginWindow.ShowDialog();
            }
        }

        private void creditBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.Credits HelpObj = new ECMS.Credits();
            HelpObj.Show();
        
        }




    }
}
