﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        //  create list to hold day objects
        public static List<Day> days = new List<Day>();
        string tempH, tempL, tempC;
        decimal tempHigh, tempLow, tempCur;

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                // create a day object
                Day d = new Day();

                // fill day object with required data
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("name");
                d.conNumber = reader.GetAttribute("number");

                reader.ReadToFollowing("temperature");
                tempH = reader.GetAttribute("max");
                if (tempH != null)
                {
                    tempHigh = decimal.Parse(tempH);
                    tempH = Convert.ToString(Math.Round(tempHigh));
                    d.tempHigh = tempH;
                }
                tempL = reader.GetAttribute("min");
                if (tempL != null)
                {
                    tempLow = decimal.Parse(tempL);
                    tempL = Convert.ToString(Math.Round(tempLow));
                    d.tempLow = tempL;
                }
                // if day object not null add to the days list
                if (d.date != null)
                {
                    days.Add(d);
                }
            }
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list
            
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");
            reader.ReadToFollowing("temperature");
            
            tempC = reader.GetAttribute("value");
            if (tempC != null)
            {
                tempCur = decimal.Parse(tempC);
                tempC = Convert.ToString(Math.Round(tempCur));
                days[0].currentTemp = tempC;
            }
            reader.ReadToFollowing("weather");
            days[0].condition = reader.GetAttribute("value");
            days[0].conNumber = reader.GetAttribute("number");
        }


    }
}
