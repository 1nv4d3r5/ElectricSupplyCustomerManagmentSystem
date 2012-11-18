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
    /// Interaction logic for ContractorBill.xaml
    /// </summary>
    public partial class ContractorBill : Window
    {
        public ContractorBill()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBillBtn_Click(object sender, RoutedEventArgs e)
        {
            ECMS.AddBill AddBillObj = new ECMS.AddBill();
            AddBillObj.Show();
        }

        private void completeBillBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
