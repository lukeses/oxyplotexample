using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using OxyPlot.Axes;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            //this.MyModel = new PlotModel { Title = "Example 1" };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this.MyModel = new PlotModel { Title = "Column series", LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightTop, LegendOrientation = LegendOrientation.Vertical };

            this.Items = new Collection<Item>
                            {
                                new Item {Label = "Apples", Value1 = 37, Value2 = 12, Value3 = 19},
                                new Item {Label = "Pears", Value1 = 7, Value2 = 21, Value3 = 9},
                                new Item {Label = "Bananas", Value1 = 23, Value2 = 2, Value3 = 29}
                            };
            
            // Add the axes, note that MinimumPadding and AbsoluteMinimum should be set on the value axis.
            this.MyModel.Axes.Add(new CategoryAxis { ItemsSource = this.Items, LabelField = "Label" });
            this.MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });

            // Add the series, note that the BarSeries are using the same ItemsSource as the CategoryAxis.
            this.MyModel.Series.Add(new ColumnSeries { Title = "2009", ItemsSource = this.Items, ValueField = "Value1" });
            this.MyModel.Series.Add(new ColumnSeries { Title = "2010", ItemsSource = this.Items, ValueField = "Value2" });
            this.MyModel.Series.Add(new ColumnSeries { Title = "2011", ItemsSource = this.Items, ValueField = "Value3" });

           

        }
        public PlotModel MyModel { get; private set; }
        public Collection<Item> Items { get; set; }
        public class Item
        {
            public string Label { get; set; }
            public double Value1 { get; set; }
            public double Value2 { get; set; }
            public double Value3 { get; set; }
        }

    }

}
