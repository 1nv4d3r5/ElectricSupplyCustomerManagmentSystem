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
    /// Interaction logic for newapplication.xaml
    /// </summary>
    public partial class newapplication : Window
    {

        string newConnectionId;
        bool isEdit = false;




        ObservableCollection<PaymentInfo> _paymentInfoCollection = new ObservableCollection<PaymentInfo>();


        public ObservableCollection<PaymentInfo> paymentInfoCollection
        {
            get
            {
                return _paymentInfoCollection;
            }
        }

        public newapplication(ESCMSData.NewConnectionInfo info)
        {
            InitializeComponent();

            string idPay = PopulatePaymentComboboxItems();

            if (info != null)
            {
                isEdit = true;
                paymentIDTxtbox.Text = info.paymentId;
                newConnectionId = info.appsNo;
                paymentIDTxtbox.Text = info.paymentId;
                applicationReceivedDateDatePicker.SelectedDate = info.receivedDate;
                PopulateItemsFromPaymentId(info.paymentId);
            }
            else
            {
                applicationReceivedDateDatePicker.SelectedDate = DateTime.Now;
                paymentIDTxtbox.Text = idPay;
                PopulateItemsFromPaymentId(idPay);
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            NewConnectionInfo newConnection = new ESCMSData.NewConnectionInfo();

            newConnection.paymentId = paymentIDTxtbox.Text;
            newConnection.customerId = customerIdlabel.Content.ToString();
            newConnection.receivedDate = applicationReceivedDateDatePicker.SelectedDate.Value;

            if (isEdit == false)
            {
                newConnection.appsNo = GenerateId();
                ESCMSStorage.DbInteraction.DoRegisterNewNewConnection(newConnection);

                estimateInfo esInfo = new estimateInfo();
                esInfo.appsNo = newConnection.appsNo;
                ESCMSStorage.DbInteraction.DoRegisterNewEstimate(esInfo);
            }
            else
            {
                newConnection.appsNo = newConnectionId;
                ESCMSStorage.DbInteraction.EditNewConnection(newConnection);
            }



            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();

        }

        private string serviceConnectionNo()
        {
            return DateTime.Now.ToOADate().ToString();

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string PopulatePaymentComboboxItems()
        {
            List<PaymentInfo> payments = ESCMSStorage.DbInteraction.GetUnassignedPaymentList();

            _paymentInfoCollection.Clear();

            foreach (PaymentInfo pay in payments)
            {
                _paymentInfoCollection.Add(pay);
            }

            if (_paymentInfoCollection.Count > 0)
                return _paymentInfoCollection[0].id;
            return null;
        }

        private void paymentIDTxtbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentPaymentId = (e.AddedItems[0] as PaymentInfo).id;
            PopulateItemsFromPaymentId(currentPaymentId);
        }

        private void PopulateItemsFromPaymentId(string payId)
        {
            PaymentInfo info = ESCMSStorage.DbInteraction.GetPaymentInfo(payId);

            customerIdlabel.Content = info.customerId;
            initialDepositAmountTxtbox.Content = info.amount;
            amountReceivedOnDatePicker.SelectedDate = info.dop;

           ESCMSData.CustomerInfo cusInfo = ESCMSStorage.DbInteraction.GetCustomerInfo(info.customerId);

            nameTxtbox.Content = cusInfo.name;
            addressTxtbox.Content = cusInfo.address;
            contactNoTxtbox.Content = cusInfo.contact;
        }

    }
}
