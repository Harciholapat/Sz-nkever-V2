using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Szinkeveres()
        {
            teglalap.Fill = new SolidColorBrush(
                Color.FromRgb(
                    Convert.ToByte(piros.Value), Convert.ToByte(zöld.Value), Convert.ToByte(kek.Value)
                    )
                );
        }

        private void rogzit_Click(object sender, RoutedEventArgs e)
        {
                String szinadatok = $"{Convert.ToByte(piros.Value)};{Convert.ToByte(zöld.Value)};{Convert.ToByte(kek.Value)}";
                
                if (!szinek.Items.Contains(szinadatok))
                {
                    szinek.Items.Add(szinadatok);
                }
                else
                {
                    MessageBox.Show("A szín már a listában van!");
                }            
        }

        private void torol_Click(object sender, RoutedEventArgs e)
        {
            if (szinek.SelectedIndex >= 0)
            {
                szinek.Items.RemoveAt(szinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában");
            }
        }

        private void urit_Click(object sender, RoutedEventArgs e)
        {
            szinek.Items.Clear();
        }

        private void piros_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void zöld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void kek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void szinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (szinek.SelectedIndex != -1)
            {
                string[] szin = szinek.Items[szinek.SelectedIndex].ToString().Split(';');
                piros.Value = Convert.ToByte(szin[0]);
                zöld.Value = Convert.ToByte(szin[1]);
                kek.Value = Convert.ToByte(szin[2]);
            }
        }
    }
}
