using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Diagnostics;

namespace FluentDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		// ThemeMode は Binding 可能なプロパティではないので、View で設定する必要がある
		WeakReferenceMessenger.Default.Register<MainWindow, PropertyChangedMessage<ThemeMode>>(this, static (window, message) =>
		{
			Debug.WriteLine($"ThemeModeChanging:{message.OldValue} -> {message.NewValue}");
			window.ThemeMode = message.NewValue;
		});
	}
}