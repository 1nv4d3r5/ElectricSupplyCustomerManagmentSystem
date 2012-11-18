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

namespace ECMS
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {

        string employeeId;
        bool isEdit = false;

        public AddEmployee(ESCMSData.EmployeeInfo info)
        {
            InitializeComponent();


            if (info != null)
            {
                isEdit = true;
                nameTxtbox.Text = info.name;
                addressTxtbox.Text = info.address;
                contactNoTxtbox.Text = info.contact;
                typeComboBox.Text = info.postType.ToString();
                dateOfjoiningDateDatePicker.Text = info.doj.ToString();
                depertmentCB.Text = info.department;
                

                employeeId = info.id;
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ESCMSData.EmployeeInfo newEmployee = new ESCMSData.EmployeeInfo();

            newEmployee.id = GenerateId();
            newEmployee.name = nameTxtbox.Text;
            newEmployee.address = addressTxtbox.Text;
            newEmployee.contact = contactNoTxtbox.Text;
            newEmployee.postType = (PostType)Enum.Parse(typeof(PostType), typeComboBox.Text, true);
            newEmployee.doj = dateOfjoiningDateDatePicker.SelectedDate.Value;
            newEmployee.department = depertmentCB.Text;

            if (isEdit == false)
            {
                newEmployee.id = GenerateId();
                ESCMSStorage.DbInteraction.DoRegisterNewEmployee(newEmployee);
            }
            else
            {
                newEmployee.id = employeeId;
                ESCMSStorage.DbInteraction.EditEmployee(newEmployee);
            }
            
           
            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
