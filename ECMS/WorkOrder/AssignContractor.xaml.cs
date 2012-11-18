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
    /// Interaction logic for AssignContractor.xaml
    /// </summary>
    public partial class AssignContractor : Window
    {
        ObservableCollection<ContractorInfo> _contractorCollection = new ObservableCollection<ContractorInfo>();


        public ObservableCollection<ContractorInfo> contractorCollection
        {
            get
            {
                return _contractorCollection;
            }
        }
        public AssignContractor(estimateInfo info)
        {
            InitializeComponent();

            applicationNoTB.Text = info.appsNo;
            nameTxtbox.Text = info.name;
            addressTxtbox.Text = info.address;
            contactNoTxtbox.Text = info.contact;
            assignedEstimatorTxtbox.Text = info.estimator;
            wireLengthRequiredTB.Text =Convert.ToString(info.wireLength);
            angleTypeTB.Text = Convert.ToString(info.angleType);
            weightofAngleCalculationTB.Text = Convert.ToString(info.angleWeight);
            quotationAmountTB.Text =Convert.ToString(info.quotationAmount);

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ContractorInfo> contractors = ESCMSStorage.DbInteraction.GetAllContractorList();

            _contractorCollection.Clear();

            foreach (ContractorInfo contractor in contractors)
            {
                _contractorCollection.Add(contractor);
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateData = new ESCMSData.estimateInfo();
            estimateData.appsNo = applicationNoTB.Text;
            estimateData.contractor = assignedContractorCB.Text;
            ESCMSStorage.DbInteraction.assignContractor(estimateData);
            this.Close();
 
        }
    }
}
