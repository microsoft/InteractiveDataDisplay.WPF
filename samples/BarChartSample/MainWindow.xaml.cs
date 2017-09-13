// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Windows;

namespace BarChartSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int N = 100;
            double[] y = new double[N];

            Random r = new Random();
            double k;

            for (int i = 0; i < N; i++)
            {
                k = r.NextDouble();
                y[i] = k < 0.5 ? r.Next(100) : -r.Next(100);
            }
            barChart.PlotBars(y);
        }
    }
}
