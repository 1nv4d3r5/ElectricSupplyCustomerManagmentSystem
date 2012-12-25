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
    /// Interaction logic for AddEstimator.xaml
    /// </summary>
    public partial class AddEstimator : Window
    {
        ObservableCollection<EmployeeInfo> _estimatorCollection = new ObservableCollection<EmployeeInfo>();


        public ObservableCollection<EmployeeInfo> estimatorCollection
        {
            get
            {
                return _estimatorCollection;
            }
        }

        public AddEstimator(estimateInfo info)
        {
            InitializeComponent();

            applicationNoTB.Text = info.appsNo;
            nameTxtbox.Text = info.name;
            addressTxtbox.Text = info.address;
            contactNoTxtbox.Text = info.contact;
            assignedEstimatorCB.Text = info.estimator;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeInfo> estimators = ESCMSStorage.DbInteraction.GetAllEmployeeList();

            _estimatorCollection.Clear();

            foreach (EmployeeInfo estimator in estimators)
            {
                _estimatorCollection.Add(estimator);


            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            estimateInfo estimateData = new ESCMSData.estimateInfo();
            estimateData.appsNo = applicationNoTB.Text;
            estimateData.estimator = assignedEstimatorCB.Text;
            ESCMSStorage.DbInteraction.assignEstimator(estimateData);
            this.Close();

        }
    }
}
