using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditCalc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calc : ContentPage
    {
        private int selectedIndex = 0;
        public Calc()
        {
            InitializeComponent();
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
        }

        public void percentSlider(object sender, ValueChangedEventArgs e)
        {

            try
            {
                if (creditPicker.SelectedIndex != -1)
                {
                    if (double.Parse(sum.Text) > 0 && int.Parse(duration.Text) > 0)
                    {
                        switch (creditPicker.SelectedIndex)
                        {
                            case 0:
                                {
                                    double newValue = e.NewValue / 100;
                                    monthlyPayment.Text = $"Ежемесячный платеж: {Convert.ToString((Convert.ToDouble(sum.Text) + Convert.ToDouble(sum.Text) * newValue) / Convert.ToDouble(duration.Text))} Р";
                                    sum.Text = $"Общая сумма: {Convert.ToString((Convert.ToDouble(sum.Text) + Convert.ToDouble(sum.Text) * newValue))} Р";
                                }
                                break;
                            case 1:
                                {
                                    double newValue = e.NewValue / 100;
                                    monthlyPayment.Text = $"Ежемесячный платеж: {Convert.ToString((Convert.ToDouble(sum.Text) / Convert.ToDouble(sum.Text) * newValue) / Convert.ToDouble(duration.Text))} Р";
                                    sum.Text = $"Общая сумма: {Convert.ToString((Convert.ToDouble(sum.Text) * newValue))} Р";
                                }
                                break;
                        }
                    }
                    else
                    {
                        monthlyPayment.Text = $"Ежемесячный платеж: N/A";
                        sum.Text = $"Общая сумма: N/A";
                        overpayment.Text = $"Переплата: N/A";
                    }
                }
            }
            catch
            {
                monthlyPayment.Text = $"Ежемесячный платеж: N/A";
                sum.Text = $"Общая сумма: N/A";
                overpayment.Text = $"Переплата: N/A";
            }
        }

        public void picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}