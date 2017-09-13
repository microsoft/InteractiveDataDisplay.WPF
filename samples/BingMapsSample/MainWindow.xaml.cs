// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace BingMapsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            plot.Tag = bingmap;

            List<double> lat = new List<double>(), lon = new List<double>(), data = new List<double>();
            using (var reader = new StreamReader(@"..\..\crop_area.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    lon.Add(Double.Parse(values[0], CultureInfo.InvariantCulture));
                    lat.Add(Double.Parse(values[1], CultureInfo.InvariantCulture));
                    data.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                }
            }

            markers.PlotColor(lon.ToArray(), lat.ToArray(), data.ToArray());
        }
    }
}
