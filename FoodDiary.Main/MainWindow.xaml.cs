using FoodDiary.Main.ViewModels;
using FoodDiary.Main.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FoodDiary.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainViewModel MyMainView { get; set; }
        public MainWindow()
        {
            MyMainView = new MainViewModel();
            ICommand UpdateViewCommand = new UpdateViewCommand(MyMainView);
            DataContext = MyMainView;
            MyMainView.CheckLoggin();
            if (MyMainView.IsLoggin == false)
                UpdateViewCommand.Execute("Login");
            else
                UpdateViewCommand.Execute("Diary");

        }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myCanvas.Width = e.NewSize.Width;
            myCanvas.Height = e.NewSize.Height;

            double xChange = 1, yChange = 1;

            if (e.PreviousSize.Width != 0)
                xChange = (e.NewSize.Width / e.PreviousSize.Width);

            if (e.PreviousSize.Height != 0)
                yChange = (e.NewSize.Height / e.PreviousSize.Height);

            ScaleTransform scale = new ScaleTransform(myCanvas.LayoutTransform.Value.M11 * xChange, myCanvas.LayoutTransform.Value.M22 * yChange);
            myCanvas.LayoutTransform = scale;
            myCanvas.UpdateLayout();
        }
    }
}
