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
using ESCMSData;

namespace ECMS
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo custinfo = new CustomerInfo();
            custinfo.name = customerNameTxtbox.Text;
            List<CustomerInfo> customers = ESCMSStorage.DbInteraction.searchCustomerList(custinfo);

            foreach (CustomerInfo customer in customers)
            {
                addressxtbox.Text = customer.address;
                conntactTxtbox.Text = customer.contact;
            }
        }


    }
}
