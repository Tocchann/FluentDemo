using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace FluentDemo;

public partial class MainViewModel : ObservableRecipient
{
	[ObservableProperty]
	[NotifyPropertyChangedRecipients]
	[NotifyPropertyChangedFor("IsThemeMode")]
	public partial ThemeMode SelectedThemeMode { get; set; }

	public List<ThemeMode> ThemeModeItems { get; } = new();

	[ObservableProperty]
	[NotifyPropertyChangedRecipients]
	public partial bool IsThemeMode { get; set; }
	
	public ObservableCollection<ListItem> Items { get; } = new();

	[ObservableProperty]
	public partial ListItem? SelectedItem { get; set; }

	[ObservableProperty]
	public partial bool IsEnabledButtons { get; set; }
	public MainViewModel()
	{
		SelectedThemeMode = ThemeMode.System;

		ThemeModeItems.Add(ThemeMode.System);
		ThemeModeItems.Add(ThemeMode.Light);
		ThemeModeItems.Add(ThemeMode.Dark);

		Items.Add(new("Item 1", "SubItem 1", 1, true));
		Items.Add(new("Item 2", "SubItem 2", 2, true));
		Items.Add(new("Item 3", "SubItem 3", 3, false));
	}
}
