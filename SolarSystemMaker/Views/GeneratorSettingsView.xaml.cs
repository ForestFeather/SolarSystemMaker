using SolarSystemLibrary;
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
using System.Windows.Shapes;

namespace SolarSystemMaker.Views
{
    /// <summary>
    /// Interaction logic for GeneratorSettingsView.xaml
    /// </summary>
    public partial class GeneratorSettingsView : Window
    {
        public GeneratorSettingsView()
        {
            InitializeComponent();
            var diceModifiers = DiceModifiers.Instance;
            CurveHeight.Value = diceModifiers.CurveValue;
            CurveBias.Value = diceModifiers.CurveModifier;
        }


        private void OnSetProperties(object sender, RoutedEventArgs e)
        {
            DiceModifiers.Instance.SetValues((int)CurveHeight.Value, (int)CurveBias.Value);
            Close();
        }
    }
}
