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
    /// Interaction logic for AddQuotation.xaml
    /// </summary>
    public partial class AddQuotation : Window
    {
        string estimateQuotationId;
        bool isEdit = false;

        ObservableCollection<EmployeeInfo> _estimatorCollection = new ObservableCollection<EmployeeInfo>();        


        public ObservableCollection<EmployeeInfo> estimatorCollection
        {
            get
            {
                return _estimatorCollection;
            }
        }

        ObservableCollection<NewConnectionInfo> _newConnectionCollection = new ObservableCollection<NewConnectionInfo>();

        public ObservableCollection<NewConnectionInfo> newConnectionCollection
        {
            get
            {
                return _newConnectionCollection;
            }
        }

        public AddQuotation(estimateInfo info)
        {
            InitializeComponent();

            applicationNoTB.Text = info.appsNo;
            nameTxtbox.Text = info.name;
            addressTxtbox.Text = info.address;
            contactNoTxtbox.Text = info.contact;
            assignedEstimatorCB.Text = info.estimator;
            wireLengthRequiredTB.Text = Convert.ToString(info.wireLength);
            weightofAngleCalculationTB.Text = Convert.ToString(info.angleWeight);
            quotationAmountTB.Text = Convert.ToString(info.quotationAmount);
            List<EmployeeInfo> estimators = ESCMSStorage.DbInteraction.GetAllEstimatorList();

            _estimatorCollection.Clear();

            foreach (EmployeeInfo estimator in estimators)
            {
                _estimatorCollection.Add(estimator);
            }

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateData = new ESCMSData.estimateInfo();
            estimateData.appsNo = applicationNoTB.Text;
            estimateData.estimator = assignedEstimatorCB.Text;
            estimateData.wireLength = Convert.ToDouble(wireLengthRequiredTB.Text);
            estimateData.angleType = (AngleType)Enum.Parse(typeof(AngleType), angleTypeCB.Text, true);
            estimateData.angleWeight = Convert.ToDouble(weightofAngleCalculationTB.Text);
            estimateData.quotationAmount = Convert.ToDouble(quotationAmountTB.Text);
            ESCMSStorage.DbInteraction.EditEstimate(estimateData);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeInfo> estimators = ESCMSStorage.DbInteraction.GetAllEmployeeList();

            _estimatorCollection.Clear();

            foreach (EmployeeInfo estimator in estimators)
            {
                _estimatorCollection.Add(estimator);


            }
        }




     

    }
}
