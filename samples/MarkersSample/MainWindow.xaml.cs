// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Windows;

namespace MarkersSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const int N =100;
            const int M = 1000;
            double[] x = new double[N];
            double[] y = new double[N];
            double[] c = new double[N];
            double[] d = new double[N];

            Random rand = new Random();
            //circles
            for (int i = 0; i < N; i++)
            {
                x[i] = rand.Next(M);
                y[i] = rand.Next(M);
                c[i] = rand.NextDouble();
                d[i] = 20 * rand.NextDouble();
            }

            circles.PlotColorSize(x, y, c, d);
            //diamonds
            x = new double[N];
            y = new double[N];
            c = new double[N];
            d = new double[N];

            for (int i = 0; i < N; i++)
            {
                x[i] = rand.Next(M);
                y[i] = rand.Next(M);
                c[i] = rand.NextDouble();
                d[i] = 20 * rand.NextDouble();
            }
            diamonds.PlotColorSize(x, y, c, d);
        }
    }
}
