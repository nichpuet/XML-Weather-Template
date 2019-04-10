using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            
            date1.Text = DateTime.Now.DayOfWeek.ToString();
            min1.Text = Form1.days[1].tempLow + " °C";
            max1.Text = Form1.days[1].tempHigh + " °C";

            date2.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString() ;
            min2.Text = Form1.days[2].tempLow + " °C";
            max2.Text = Form1.days[2].tempHigh + " °C";

            date3.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
            min3.Text = Form1.days[3].tempLow + " °C";
            max3.Text = Form1.days[3].tempHigh + " °C";

            date4.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            min4.Text = Form1.days[4].tempLow + " °C";
            max4.Text = Form1.days[4].tempHigh + " °C";

            date5.Text = DateTime.Now.AddDays(4).DayOfWeek.ToString();
            min5.Text = Form1.days[5].tempLow + " °C";
            max5.Text = Form1.days[5].tempHigh + " °C";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void ImageBox(string boxLabel)
        {
            //int temp = int.Parse(Form1.days[0].conNumber);

            //if (temp >= 200 && temp <= 299)
            //{
            //    //Thunderstorm
            //    conditionBox.BackgroundImage = Properties.Resources.thunderstorm;
            //}
            //else if (temp >= 300 && temp <= 499)
            //{
            //    //raining
            //    conditionBox.BackgroundImage = Properties.Resources.raining;
            //}
            //else if (temp >= 500 && temp <= 599)
            //{
            //    //raining
            //    conditionBox.BackgroundImage = Properties.Resources.raining;
            //}
            //else if (temp >= 600 && temp <= 699)
            //{
            //    //snow
            //    conditionBox.BackgroundImage = Properties.Resources.snow;
            //}
            //else if (temp >= 700 && temp <= 799)
            //{
            //    //Windy
            //    conditionBox.BackgroundImage = Properties.Resources.windy;
            //}
            //else if (temp == 800)
            //{
            //    //clear
            //    conditionBox.BackgroundImage = Properties.Resources.sunny;

            //}
            //else if (temp >= 801 && temp <= 900)
            //{
            //    //cloudy
            //    conditionBox.BackgroundImage = Properties.Resources.cloudy;
            //}
        }
    }
}
