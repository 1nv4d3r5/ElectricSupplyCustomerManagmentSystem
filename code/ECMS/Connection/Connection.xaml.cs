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
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {


        ObservableCollection<NewConnectionInfo> _newConnectionCollection = new ObservableCollection<NewConnectionInfo>();


        public ObservableCollection<NewConnectionInfo> newConnectionCollection
        {
            get
            {
                return _newConnectionCollection;
            }
        }


        public Connection()
        {
            InitializeComponent();
        }

        private void addNewConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.newapplication newapplicationObj = new ECMS.newapplication(null);
            newapplicationObj.Show();
        }


        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            List<NewConnectionInfo> newConnections = ESCMSStorage.DbInteraction.GetAllNewConnectionList();

            _newConnectionCollection.Clear();

            foreach (NewConnectionInfo newConnection in newConnections)
            {
                PaymentInfo info = ESCMSStorage.DbInteraction.GetPaymentInfo(newConnection.paymentId);
                newConnection.initialAmount = info.amount;
                newConnection.amountReceivedOn = info.dop;

                ESCMSData.CustomerInfo cusInfo = ESCMSStorage.DbInteraction.GetCustomerInfo(newConnection.customerId);
                newConnection.name = cusInfo.name;
                newConnection.address = cusInfo.address;
                newConnection.phone = cusInfo.contact;

                _newConnectionCollection.Add(newConnection);
            }
        }

        private void deleteConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            NewConnectionInfo newConnectionToDelete = GetSelectedItem();
            if (newConnectionToDelete != null)
            {
                _newConnectionCollection.Remove(newConnectionToDelete);
                ESCMSStorage.DbInteraction.DeleteNewConnection(newConnectionToDelete.appsNo);
            }
        }

        private NewConnectionInfo GetSelectedItem()
        {

            NewConnectionInfo newConnectionToDelete = null;

            if (newConnectionView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                NewConnectionInfo i = (NewConnectionInfo)newConnectionView.SelectedItem;

                newConnectionToDelete = _newConnectionCollection.Where(item => item.appsNo.Equals(i.appsNo)).First();
            }

            return newConnectionToDelete;
        }

        private void editConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            NewConnectionInfo newConnectionToEdit = GetSelectedItem();
            if (newConnectionToEdit != null)
            {
                ECMS.newapplication AddNewConnectionObj = new ECMS.newapplication(newConnectionToEdit);
                AddNewConnectionObj.Show();
            }
        }

        
    }
}
