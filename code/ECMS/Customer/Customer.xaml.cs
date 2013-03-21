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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {


        ObservableCollection<CustomerInfo> _customerCollection = new ObservableCollection<CustomerInfo>();


        public ObservableCollection<CustomerInfo> customerCollection
        {
            get
            {
                return _customerCollection;
            }
        }


        public Customer()
        {
            InitializeComponent();
        }


        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddCustomer AddCustomerObj = new ECMS.AddCustomer(null);
            AddCustomerObj.Show();
        }

        private void viewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<CustomerInfo> customers = ESCMSStorage.DbInteraction.GetAllCustomerList();

            _customerCollection.Clear();

            foreach (CustomerInfo customer in customers)
            {
                _customerCollection.Add(customer);
            }
        }

        private void deleteCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo customerToDelete = GetSelectedItem();
            if (customerToDelete != null)
            {
                _customerCollection.Remove(customerToDelete);
                ESCMSStorage.DbInteraction.DeleteCustomer(customerToDelete.id);
            }
        }

        private CustomerInfo GetSelectedItem()
        {

            CustomerInfo customerToDelete = null;

            if (customerView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                CustomerInfo i = (CustomerInfo)customerView.SelectedItem;

                customerToDelete = _customerCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return customerToDelete;
        }

        private void editCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo customerToEdit = GetSelectedItem();
            if (customerToEdit != null)
            {
                ECMS.AddCustomer AddCustomerObj = new ECMS.AddCustomer(customerToEdit);
                AddCustomerObj.Show();
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo custinfo = new CustomerInfo();
            custinfo.name = searchTxtBlck.Text; 
            List<CustomerInfo> customers = ESCMSStorage.DbInteraction.searchCustomerList(custinfo);

            _customerCollection.Clear();

            foreach (CustomerInfo customer in customers)
            {
                _customerCollection.Add(customer);
            }
        }

       
        
    }
}
