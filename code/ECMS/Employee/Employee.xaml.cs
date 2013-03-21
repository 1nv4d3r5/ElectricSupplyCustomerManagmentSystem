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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {

        ObservableCollection<EmployeeInfo> _employeeCollection = new ObservableCollection<EmployeeInfo>();


        public ObservableCollection<EmployeeInfo> employeeCollection
        {
            get
            {
                return _employeeCollection;
            }
        }


        public Employee()
        {
            InitializeComponent();
        }

        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddEmployee AddEmployeeObj = new ECMS.AddEmployee(null);
            AddEmployeeObj.Show();
        }

        private void viewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeInfo> employees = ESCMSStorage.DbInteraction.GetAllEmployeeList();

            _employeeCollection.Clear();

            foreach (EmployeeInfo employee in employees)
            {
                _employeeCollection.Add(employee);
            }
        }

        private void deleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo employeeToDelete = GetSelectedItem();
            if (employeeToDelete != null)
            {
                _employeeCollection.Remove(employeeToDelete);
                ESCMSStorage.DbInteraction.DeleteEmployee(employeeToDelete.id);
            }
        }
        private EmployeeInfo GetSelectedItem()
        {

            EmployeeInfo employeeToDelete = null;

            if (employeeView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                EmployeeInfo i = (EmployeeInfo)employeeView.SelectedItem;

                employeeToDelete = _employeeCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return employeeToDelete;
        }

        private void editEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo employeeToEdit = GetSelectedItem();
            if (employeeToEdit != null)
            {
                ECMS.AddEmployee AddEmployeeObj = new ECMS.AddEmployee(employeeToEdit);
                AddEmployeeObj.Show();
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo empInfoObj = new EmployeeInfo();
            empInfoObj.name = searchTxtBlck.Text;

            List<EmployeeInfo> employees = ESCMSStorage.DbInteraction.SearchAllEmployeeList(empInfoObj);

            _employeeCollection.Clear();

            foreach (EmployeeInfo employee in employees)
            {
                _employeeCollection.Add(employee);
            }

        }
        
    }
}
