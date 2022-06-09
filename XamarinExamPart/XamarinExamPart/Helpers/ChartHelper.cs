using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XamarinExamPart.Helpers
{
    public class ChartHelper
    {

        public Chart CreateChart<T>(IEnumerable<T> data, Func<T, float> value, Func<T, string> label)
        {
            var entries = new List<ChartEntry>();

            data.ToList().ForEach(item => entries.Add(new ChartEntry(value(item))
            {
                Label = label(item),
                ValueLabel = value(item).ToString()
            }));

            var chart = new LineChart { Entries = entries };
            chart.LabelOrientation = Orientation.Horizontal;
            chart.ValueLabelOrientation = Orientation.Horizontal;
            chart.LineMode = LineMode.Straight;
            chart.LabelTextSize = 35;
            

            return chart;
        }
    }
}