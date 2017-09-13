// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Reactive.Linq;

namespace HeatmapSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private volatile bool isUnloaded = false;
        private AutoResetEvent renderComplete = new AutoResetEvent(false);
        private Thread thread;
        private double phase = 0;

        const int N = 1000;
        const int M = 500;

        double[] x = new double[N + 1];
        double[] y = new double[M + 1];
        double[,] f = new double[N, M];

        public MainWindow()
        {
            InitializeComponent();

            // Start computation thread when Page appears on the screen
            Loaded += (s, e) =>
            {
                thread = new Thread(ModelRun);
                isUnloaded = false;
                thread.Start();
            };

            // Stop computation thread when Page is removed from the screen
            Closing += (s, e) =>
            {
                isUnloaded = true;
                renderComplete.Set();
                thread.Join();
            };
        }

        private void ModelRun()
        {
            // Coordinate grid is constant
            for (int i = 0; i <= N; i++)
                x[i] = -Math.PI + 2 * i * Math.PI / N;

            for (int j = 0; j <= M; j++)
                y[j] = -Math.PI / 2 + j * Math.PI / M;

            while (!isUnloaded) // Run until page is on the screen
            {
                // Data array is updated
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        f[i, j] = Math.Sqrt(x[i] * x[i] + y[j] * y[j]) * Math.Abs(Math.Cos(x[i] * x[i] + y[j] * y[j] + phase));
                phase += 0.1;

                // Uncomment next line to simulate delay in computations
                // Thread.Sleep(1000);

                // Plot the computed array.
                // The Plot method must be called from the UI dispatcher thread. 
                // Unlike Tutoral3 sample here we wait for each frame to be rendered.
                if (!isUnloaded)
                {
                    renderComplete.Reset();
                    PlotDataDel handler = PlotData;
                    Dispatcher.BeginInvoke(handler);
                    renderComplete.WaitOne();
                }
            }
        }
        private delegate void PlotDataDel();
        private void PlotData()
        {
            // HeatmapGraph objects prepare images to be drawn in a background thread. 
            // The Plot method cancels current incomplete images before starting a new one. 
            // This increases responsiveness of the UI but may result in loss of certain 
            // or even all of the frames.
            // The following code shows how to wait until a certain data is actually drawn.

            long id = heatmap.Plot(f, x, y); // receive a unique operation identifier
            heatmap.RenderCompletion // an observable of completed and cancelled operations
                .Where(rc => rc.TaskId == id) // filter out an operation with the known id
                .Subscribe(dummy => { renderComplete.Set(); }); // signal when the id is observed
        }
    }
}
