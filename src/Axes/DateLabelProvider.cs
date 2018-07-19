// Copyright © Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Globalization;

namespace InteractiveDataDisplay.WPF
{
    /// <summary>
    /// Provides mechanisms to generate labels displayed on an axis by DateTime ticks. 
    /// </summary>
    public class DateLabelProvider : ILabelProvider
    {
        public string Format { get; set; } = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Generates an array of labels from an array of double.
        /// </summary>
        /// <param name="ticks">An array of double ticks.</param>
        /// <returns>An array of <see cref="FrameworkElement"/>.</returns>
        public FrameworkElement[] GetLabels(double[] ticks)
        {
            if (ticks == null)
                throw new ArgumentNullException(nameof(ticks));

            List<TextBlock> Labels = new List<TextBlock>();
            foreach (double tick in ticks)
            {
                TextBlock text = new TextBlock
                {
                    Text = new DateTime((long)tick).ToString(Format)
                };
                Labels.Add(text);
            }
            return Labels.ToArray();
        }
    }
}

