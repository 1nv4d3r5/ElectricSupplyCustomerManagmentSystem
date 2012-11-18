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
    /// Interaction logic for Contractor.xaml
    /// </summary>
    public partial class AddContractor : Window
    {

        string contractorId;
        bool isEdit = false;

        public AddContractor(ESCMSData.ContractorInfo info)
        {
            InitializeComponent();


            if (info != null)
            {
                isEdit = true;
                nameTxtbox.Text = info.name;
                addressTxtbox.Text = info.address;
                contactNoTxtbox.Text = info.contact;
                contractDetailsTxtbox.Text = info.details;

                contractorId = info.id;
            }
        }

        


        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ESCMSData.ContractorInfo newContractor = new ESCMSData.ContractorInfo();

            newContractor.id = GenerateId();
            newContractor.name = nameTxtbox.Text;
            newContractor.address = addressTxtbox.Text;
            newContractor.contact = contactNoTxtbox.Text;
            newContractor.details = contractDetailsTxtbox.Text;


            if (isEdit == false)
            {
                newContractor.id = GenerateId();
                ESCMSStorage.DbInteraction.DoRegisterNewContractor(newContractor);
            }
            else
            {
                newContractor.id = contractorId;
                ESCMSStorage.DbInteraction.EditContractor(newContractor);
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
