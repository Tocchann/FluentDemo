using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
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

namespace FluentDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		WeakReferenceMessenger.Default.Register<MainWindow, PropertyChangedMessage<ThemeMode>>(this, static (window, message) =>
		{
			if( window.DataContext is MainViewModel vm && vm.IsThemeMode )
			{
				window.ThemeMode = message.NewValue;
			}
		});

		WeakReferenceMessenger.Default.Register<MainWindow, PropertyChangedMessage<bool>>(this, static (window, message) =>
		{
			if( message.NewValue)
			{
				if (window.DataContext is MainViewModel vm)
				{
					window.ThemeMode = vm.SelectedThemeMode;
				}
			}
			else
			{
				window.ThemeMode = ThemeMode.None;
			}
		});
	}
}