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
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            //Capitalizes each word in the current conditions
            string temp2 = Form1.days[0].condition;
            temp2 = char.ToUpper(temp2[0]) + temp2.Substring(1);

            for(int i = 0; i < temp2.Length; i++)
            {
                string temp3 = Convert.ToString(temp2[i]);
                if (temp3 == " ")
                {
                    temp2 = temp2.Substring(0,i+1) + char.ToUpper(temp2[i + 1]) + temp2.Substring(i + 2);
                }
            }

            //Displays all the information including an image matching the weather condition
            dateOutput.Text = DateTime.Now.ToString();
            conditionOutput.Text = temp2;
            cityOutput.Text = Form1.days[0].location;
            tempLabel.Text = Form1.days[0].currentTemp + " °C";
            minLabel.Text = Form1.days[0].tempLow + " °C";
            maxLabel.Text = Form1.days[0].tempHigh + " °C";

            int temp = int.Parse(Form1.days[0].conNumber);

            if (temp >= 200 && temp <= 299)
            {
                //Thunderstorm
                conditionBox.BackgroundImage = Properties.Resources.thunderstorm;
            }
            else if (temp >= 300 && temp <= 499)
            {
                //raining
                conditionBox.BackgroundImage = Properties.Resources.raining;
            }
            else if (temp >= 500 && temp <= 599)
            {
                //raining
                conditionBox.BackgroundImage = Properties.Resources.raining;
            }
            else if (temp >= 600 && temp <= 699)
            {
                //snow
                conditionBox.BackgroundImage = Properties.Resources.snow;
            }
            else if (temp >= 700 && temp <= 799)
            {
                //Windy
                conditionBox.BackgroundImage = Properties.Resources.windy;
            }
            else if (temp == 800)
            {
                //clear
                conditionBox.BackgroundImage = Properties.Resources.sunny;
               
            }
            else if (temp >= 801 && temp <= 900)
            {
                //cloudy
                conditionBox.BackgroundImage = Properties.Resources.cloudy;
            }
            Refresh();
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
