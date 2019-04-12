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
        List<PictureBox> picList = new List<PictureBox>();

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            //Displays the temps and calls the condition method for each day
            date1.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            min1.Text = Form1.days[1].tempLow + " °C";
            max1.Text = Form1.days[1].tempHigh + " °C";
            drawImage(0);

            date2.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
            min2.Text = Form1.days[2].tempLow + " °C";
            max2.Text = Form1.days[2].tempHigh + " °C";
            drawImage(1);

            date3.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            min3.Text = Form1.days[3].tempLow + " °C";
            max3.Text = Form1.days[3].tempHigh + " °C";
            drawImage(2);

            date4.Text = DateTime.Now.AddDays(4).DayOfWeek.ToString();
            min4.Text = Form1.days[4].tempLow + " °C";
            max4.Text = Form1.days[4].tempHigh + " °C";
            drawImage(3);

            date5.Text = DateTime.Now.AddDays(5).DayOfWeek.ToString();
            min5.Text = Form1.days[5].tempLow + " °C";
            max5.Text = Form1.days[5].tempHigh + " °C";
            drawImage(4);

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void drawImage(int dayNum)
        {
            //displays that days conditions and temps depending on which day was input
            picList.Add(day1Box);
            picList.Add(day2Box);
            picList.Add(day3Box);
            picList.Add(day4Box);
            picList.Add(day5Box);

            int temp = int.Parse(Form1.days[dayNum].conNumber);

            if (temp >= 200 && temp <= 299)
            {
                //Thunderstorm
                picList[dayNum].BackgroundImage = Properties.Resources.thunderstorm;
            }
            else if (temp >= 300 && temp <= 499)
            {
                //raining
                picList[dayNum].BackgroundImage = Properties.Resources.raining;
            }
            else if (temp >= 500 && temp <= 599)
            {
                //raining
                picList[dayNum].BackgroundImage = Properties.Resources.raining;
            }
            else if (temp >= 600 && temp <= 699)
            {
                //snow
                picList[dayNum].BackgroundImage = Properties.Resources.snow;
            }
            else if (temp >= 700 && temp <= 799)
            {
                //Windy
                picList[dayNum].BackgroundImage = Properties.Resources.windy;
            }
            else if (temp == 800)
            {
                //clear
                picList[dayNum].BackgroundImage = Properties.Resources.sunny;

            }
            else if (temp >= 801 && temp <= 900)
            {
                //cloudy
                picList[dayNum].BackgroundImage = Properties.Resources.cloudy;
            }
        }
    }
}
