using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;
using Core01;
using Data01;


namespace FirstScreen
{
    public partial class SecondScreen : Window
    {
        public SecondScreen()
        {
            InitializeComponent();
            LoadEnums();
        }

        public void LoadEnums()
        {
            foreach (var elemento in Enum.GetValues(typeof(SistemasPromob)))
                opcoesComboBox.Items.Add(elemento);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var idSystem = new Evaluate().ConvertToInteger(txtSystemID.Text);
                new Serialize().SerializeJson(idSystem, (SistemasPromob)opcoesComboBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtSystemID.Clear();
        }
    }
}
