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
    /// Interaction logic for ContractorBrowser.xaml
    /// </summary>
    public partial class Contractor : Window
    {

        ObservableCollection<ContractorInfo> _contractorCollection = new ObservableCollection<ContractorInfo>();


        public ObservableCollection<ContractorInfo> contractorCollection
        {
            get
            {
                return _contractorCollection;
            }
        }

        public Contractor()
        {
            InitializeComponent();
        }

        private void addContractorBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddContractor AddContractorObj = new ECMS.AddContractor(null);
            AddContractorObj.Show();
        }

        private void viewContractorBtn_Click(object sender, RoutedEventArgs e)
        {
            List<ContractorInfo> contractors = ESCMSStorage.DbInteraction.GetAllContractorList();

            _contractorCollection.Clear();

            foreach (ContractorInfo contractor in contractors)
            {
                _contractorCollection.Add(contractor);
            }
        }

        private void deleteContractorBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractorInfo contractorToDelete = GetSelectedItem();
            if (contractorToDelete != null)
            {
                _contractorCollection.Remove(contractorToDelete);
                ESCMSStorage.DbInteraction.DeleteContractor(contractorToDelete.id);
            }
        }

        private ContractorInfo GetSelectedItem()
        {

            ContractorInfo contractorToDelete = null;

            if (contractorView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ContractorInfo i = (ContractorInfo)contractorView.SelectedItem;

                contractorToDelete = _contractorCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return contractorToDelete;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editContractorBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractorInfo contractorToEdit = GetSelectedItem();
            if (contractorToEdit != null)
            {
                ECMS.AddContractor AddContractorObj = new ECMS.AddContractor(contractorToEdit);
                AddContractorObj.Show();
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractorInfo conInfoObj = new ContractorInfo();
            conInfoObj.name = searchTxtBlck.Text;

             List<ContractorInfo> contractors = ESCMSStorage.DbInteraction.SearchContractorList(conInfoObj);

            _contractorCollection.Clear();

            foreach (ContractorInfo contractor in contractors)
            {
                _contractorCollection.Add(contractor);
            }
        }

        }

        
    }

