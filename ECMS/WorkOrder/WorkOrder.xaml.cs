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
    /// Interaction logic for WorkOrder.xaml
    /// </summary>
    public partial class WorkOrder : Window
    {
        ObservableCollection<estimateInfo> _estimateCollection = new ObservableCollection<estimateInfo>();


        public ObservableCollection<estimateInfo> estimateCollection
        {
            get
            {
                return _estimateCollection;
            }
        }
        public WorkOrder()
        {
            InitializeComponent();
        }

        private void addWorkOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateToEdit = GetSelectedItem();
            if (estimateToEdit != null)
            {
                ECMS.AssignContractor AddWorkOrderObj = new ECMS.AssignContractor(estimateToEdit);
                AddWorkOrderObj.Show();
            }
        }

        private estimateInfo GetSelectedItem()
        {
            estimateInfo estimateToDelete = null;

            if (workOrderView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                estimateInfo i = (estimateInfo)workOrderView.SelectedItem;
                estimateToDelete = _estimateCollection.Where(item => item.appsNo.Equals(i.appsNo)).First();
            }

            return estimateToDelete;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewWorkOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            List<estimateInfo> estimates = ESCMSStorage.DbInteraction.GetAllEstimateListWithContractor();

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
    }
}
