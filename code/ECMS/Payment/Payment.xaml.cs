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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {

        ObservableCollection<PaymentInfo> _paymentCollection = new ObservableCollection<PaymentInfo>();


        public ObservableCollection<PaymentInfo> paymentCollection
        {
            get
            {
                return _paymentCollection;
            }
        }


        public Payment()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addPaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddPayment AddPaymentObj = new ECMS.AddPayment(null);
            AddPaymentObj.Show();
        }

        private void viewConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            List<PaymentInfo> payments = ESCMSStorage.DbInteraction.GetAllPaymentList();

            _paymentCollection.Clear();

            foreach (PaymentInfo payment in payments)
            {
                ESCMSData.CustomerInfo cusInfo = ESCMSStorage.DbInteraction.GetCustomerInfo(payment.customerId);
                payment.name = cusInfo.name;
                _paymentCollection.Add(payment);
            }
        }

        private void deleteConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            PaymentInfo paymentToDelete = GetSelectedItem();
            if (paymentToDelete != null)
            {
                _paymentCollection.Remove(paymentToDelete);
                ESCMSStorage.DbInteraction.DeletePayment(paymentToDelete.id);
            }
        }
        private PaymentInfo GetSelectedItem()
        {

            PaymentInfo paymentToDelete = null;

            if (paymentView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                PaymentInfo i = (PaymentInfo)paymentView.SelectedItem;

                paymentToDelete = _paymentCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return paymentToDelete;
        }

        private void editConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            PaymentInfo paymentToEdit = GetSelectedItem();
            if (paymentToEdit != null)
            {
                ECMS.AddPayment AddPaymentObj = new ECMS.AddPayment(paymentToEdit);
                AddPaymentObj.Show();
            }
        }
       
     }
}
