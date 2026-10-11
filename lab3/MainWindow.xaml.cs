using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Medicine> _medicines = new List<Medicine>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMedicineBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameInput.Text;
                string dosage = DosageInput.Text;
                double price = Convert.ToDouble(PriceInput.Text);

                if (TypeComboBox.SelectedIndex == 0)
                {
                    int amount = Convert.ToInt32(SpecificInput.Text);
                    Tablet tab = new Tablet(name, dosage, price, amount);
                    _medicines.Add(tab);
                    MedicineList.Items.Add(tab.Apply());
                }
                else if (TypeComboBox.SelectedIndex == 1)
                {
                    double volume = Convert.ToDouble(SpecificInput.Text);
                    Syrup syr = new Syrup(name, dosage, price, volume);
                    _medicines.Add(syr);
                    MedicineList.Items.Add(syr.Apply());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void CalcTotalBtn_Click(object sender, RoutedEventArgs e)
        {
            double totalCost = MedicineAnalysis.GetTotalCost(_medicines);
            TotalCostText.Text = "Загальна сума: " + totalCost.ToString() + " грн";
        }
    }
}