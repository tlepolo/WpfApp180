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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp18
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        StringAnimationUsingKeyFrames animation = new StringAnimationUsingKeyFrames();
        public MainWindow()
        {
            InitializeComponent();
            animation.FillBehavior = FillBehavior.Stop;
            for (int i = 6; i >= 0; i--)
            {
                animation.KeyFrames.Add(new DiscreteStringKeyFrame()
                {
                    Value = $"{i}秒后在获取",
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6 - i))
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false;
            button.Foreground = Brushes.Black;
            animation.Completed += (s, args) =>
            {
                button.IsEnabled = true;
                button.Foreground = Brushes.White;

            };
            button.BeginAnimation(Button.ContentProperty, animation);
        }


    }
}
