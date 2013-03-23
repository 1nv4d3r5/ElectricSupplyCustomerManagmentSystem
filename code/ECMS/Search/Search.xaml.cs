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
using System.Collections.ObjectModel;

namespace ECMS
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {

        ObservableCollection<CustomerInfo> _customerCollection = new ObservableCollection<CustomerInfo>();


        public ObservableCollection<CustomerInfo> customerCollection
        {
            get
            {
                return _customerCollection;
            }
        }

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
            custinfo.name = searchTxtBlck.Text;
            List<CustomerInfo> customers = ESCMSStorage.DbInteraction.searchCustomerList(custinfo);

            foreach (CustomerInfo customer in customers)
            {
                _customerCollection.Add(customer);
            }
        }


    }
}
