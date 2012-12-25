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
using System.Collections.ObjectModel;
using ESCMSData;

namespace ECMS
{
    /// <summary>
    /// Interaction logic for EstimationQuatationDisplay.xaml
    /// </summary>
    public partial class EstimationQuotationDisplay : Window
    {
        ObservableCollection<estimateInfo> _estimateCollection = new ObservableCollection<estimateInfo>();


        public ObservableCollection<estimateInfo> estimateCollection
        {
            get
            {
                return _estimateCollection;
            }
        }

        public EstimationQuotationDisplay()
        {
            InitializeComponent();
        }

        private void addPaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateToEdit = GetSelectedItem();
            if (estimateToEdit != null)
            {
                ECMS.AddQuotation EstimateQuotationObj = new ECMS.AddQuotation(estimateToEdit);
                EstimateQuotationObj.Show();
            }            
        }

        public estimateInfo GetSelectedItem()
        {
            estimateInfo estimateToDelete = null;

            if (estimateView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                estimateInfo i = (estimateInfo)estimateView.SelectedItem;
                estimateToDelete = _estimateCollection.Where(item => item.appsNo.Equals(i.appsNo)).First();
            }

            return estimateToDelete;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void viewEstimateBtn_Click(object sender, RoutedEventArgs e)
        {
            List<estimateInfo> estimates = ESCMSStorage.DbInteraction.GetAllEstimateList();

            _estimateCollection.Clear();

            foreach (estimateInfo esm in estimates)
            {
                string cusId = ESCMSStorage.DbInteraction.GetNewConnectionCustomerId(esm.appsNo);
                CustomerInfo cusInfo = ESCMSStorage.DbInteraction.GetCustomerInfo(cusId);

                esm.name = cusInfo.name;
                esm.address = cusInfo.address;
                esm.contact = cusInfo.contact;

                _estimateCollection.Add(esm);
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateToEdit = GetSelectedItem();
            if (estimateToEdit != null)
            {
               // ECMS.AddQuotation EstimateQuotationObj = new ECMS.AddQuotation(estimateToEdit);
                ECMS.AddEstimator AddEstimatorObj = new ECMS.AddEstimator(estimateToEdit);
                AddEstimatorObj.Show();
            }
           
        }
       
    }
}
