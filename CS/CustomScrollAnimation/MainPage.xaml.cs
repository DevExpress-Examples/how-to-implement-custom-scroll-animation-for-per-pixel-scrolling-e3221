using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CustomScrollAnimation {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = GetData();
        }

        private void tableView1_CustomScrollAnimation(object sender, DevExpress.Xpf.Grid.CustomScrollAnimationEventArgs e) {
            e.Storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = e.OldOffset;
            animation.To = e.NewOffset;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(600));
            animation.EasingFunction = new ExponentialEase() { Exponent = 0 };
            e.Storyboard.Children.Add(animation);
        }

        private List<TestDataObject> GetData() {
            List<TestDataObject> _list = new List<TestDataObject>();
            for (int i = 0; i < 100; i++)
                _list.Add(new TestDataObject() { ID = i, Value = string.Format("Value {0}", i) });
            return _list;
        }

    }

    public class TestDataObject {
        public int ID { get; set; }
        public string Value { get; set; }
    }

}
