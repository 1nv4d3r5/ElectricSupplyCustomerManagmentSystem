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
    /// Interaction logic for AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {

        string paymentId;
        bool isEdit = false;


        ObservableCollection<CustomerInfo> _customerCollection = new ObservableCollection<CustomerInfo>();


        public ObservableCollection<CustomerInfo> customerCollection
        {
            get
            {
                return _customerCollection;
            }
        }

        public AddPayment(ESCMSData.PaymentInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                nameTxtbox.Text = info.customerId;
                amountTxtbox.Text = info.amount.ToString();
                dopDatePicker.Text = info.dop.ToString();

                paymentId = info.id;
            }
            else
            {
                paymentIdLbl.Content = GenerateId();
                dopDatePicker.SelectedDate = DateTime.Now;
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ESCMSData.PaymentInfo PaymentData = new ESCMSData.PaymentInfo();

            PaymentData.id = paymentIdLbl.Content.ToString();
            PaymentData.customerId = nameTxtbox.SelectedValue.ToString();
            PaymentData.amount = Convert.ToDouble(amountTxtbox.Text); 
            PaymentData.dop = dopDatePicker.SelectedDate.Value;

            if (isEdit == false)
            {
                PaymentData.id = GenerateId();
                ESCMSStorage.DbInteraction.DoRegisterNewPayment(PaymentData);
            }
            else
            {
                PaymentData.id = paymentId;
                ESCMSStorage.DbInteraction.EditPayment(PaymentData);
            }
            

            this.Close();
        }
        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void addCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddCustomer AddCustomerObj = new ECMS.AddCustomer(null);
            AddCustomerObj.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<CustomerInfo> customers = ESCMSStorage.DbInteraction.GetAllCustomerList();

            _customerCollection.Clear();

            foreach (CustomerInfo customer in customers)
            {
                _customerCollection.Add(customer);


            }
        }

        


 
        
    }
}
