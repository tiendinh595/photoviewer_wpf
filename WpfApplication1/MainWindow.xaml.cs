using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            CGlobal.imgSource = ((Image)stpListImage.Children[index]).Source;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {

            if (WindowState == System.Windows.WindowState.Normal)
                this.WindowState = System.Windows.WindowState.Maximized;
            else
                this.WindowState = System.Windows.WindowState.Normal;
        }

        int index = 1;
        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            Image imgSelected = (Image)sender;
            index = Convert.ToInt32(imgSelected.Tag);
            changeImage();

        }

        private void changeImage()
        {
            imgLeft.Source = imgRight.Source = null;
            imgCenter.Source = CGlobal.imgSource = ((Image)stpListImage.Children[index]).Source;
            if (index - 1 >= 0)
                imgLeft.Source = ((Image)stpListImage.Children[index - 1]).Source;
            if (index + 1 <= stpListImage.Children.Count - 1)
                imgRight.Source = ((Image)stpListImage.Children[index + 1]).Source;
        }

        private void imgFrev_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (index > 0)
            {
                index--;
                changeImage();
            }
        }

        private void imgFull_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fmrFullSceen form = new fmrFullSceen();
            form.ShowDialog();
        }

        private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (index < stpListImage.Children.Count-1)
            {
                index++;
                changeImage();
            }
        }

        private void imgFrev_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
