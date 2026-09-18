using System.Formats.Nrbf;
using System.Linq.Expressions;
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

namespace WpfAppSuper
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


        public const double PAY_PER_HOUR = 10.50;


        private void Button_Click_Summarize(object sender, RoutedEventArgs e)
        {

            try
            {
                //checking both normal boxes, ai told me about the double bars to smush these together
                if (string.IsNullOrWhiteSpace(FirstBox.Text) || string.IsNullOrWhiteSpace(LastBox.Text))

                    throw new Exception();

                //i'm doing a double this time to try to get a more accurate pay number
                double hours = double.Parse(HourBox.Text);

                //userproofing
                if (!(hours >= 0))
                    throw new Exception();

                double pay = hours * PAY_PER_HOUR;

                SumLabel.Foreground = Brushes.Black;
                SumLabel.Content = $"{FirstBox.Text.Trim()} {LastBox.Text.Trim()} worked {hours} hours and earned {pay:C}.";
            }
            catch
            {
                SumLabel.Foreground = Brushes.Red;
                SumLabel.Content = "Please re-enter your input and try again.";
            }
        }



        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            HourBox.Clear();
            LastBox.Clear();
            FirstBox.Clear();
            SumLabel.Content = string.Empty;

            SumLabel.Foreground = Brushes.Black;
            //reset this text back to black when button is pressed
        }

        private void FirstBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HourBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}