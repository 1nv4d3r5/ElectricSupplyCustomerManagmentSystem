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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {

        string customerId;
        bool isEdit = false;

        public AddCustomer(ESCMSData.CustomerInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                nameTxtbox.Text = info.name;
                addressTxtbox.Text = info.address;
                contactNoTxtbox.Text = info.contact;


                customerId = info.id;
            }
        }


        

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ESCMSData.CustomerInfo newCustomer = new ESCMSData.CustomerInfo();

            newCustomer.id = GenerateId();
            newCustomer.name = nameTxtbox.Text;
            newCustomer.address = addressTxtbox.Text;
            newCustomer.contact = contactNoTxtbox.Text;

            if (isEdit == false)
            {
                newCustomer.id = GenerateId();
                ESCMSStorage.DbInteraction.DoRegisterNewCustomer(newCustomer);
            }
            else
            {
                newCustomer.id = customerId;
                ESCMSStorage.DbInteraction.EditCustomer(newCustomer);
            }
            

            

            this.Close();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
