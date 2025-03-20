using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace FluentDemo;

public partial class MainViewModel : ObservableObject
{
	/// <summary>
	/// テーマモードの選択肢(コンボ用)
	/// </summary>
	public List<ThemeMode> ThemeModeItems { get; } = new();

	/// <summary>
	/// 現在のテーマモード
	/// </summary>
	[ObservableProperty]
	[NotifyPropertyChangedFor("IsThemeMode")]
	public partial ThemeMode SelectedThemeMode { get; set; }
	/// <summary>
	/// テーマモードの有効状態
	/// </summary>
	[ObservableProperty]
	public partial bool IsThemeMode { get; set; }

	/// <summary>
	/// SelectedThemeMode が切り替わるときに呼び出されるパーシャルメソッド(変更前に呼ばれるので、プロパティは古い値)
	/// </summary>
	/// <param name="value">新たに選択される値</param>
	partial void OnSelectedThemeModeChanging(ThemeMode value)
	{
		// テーマモードが有効な場合のみ、選択を通知する
		if( IsThemeMode )
		{
			App.Current.ThemeMode = value;
		}
	}
	/// <summary>
	/// IsThemeMode が切り替わるときに呼び出されるパーシャルメソッド(変更前に呼ばれるので、プロパティは古い値)
	/// </summary>
	/// <param name="value">新たに選択される</param>
	partial void OnIsThemeModeChanging( bool value)
	{
		// アプリ全体に影響を与えるので、アプリケーションクラスの値を設定する
		App.Current.ThemeMode = value ? SelectedThemeMode : ThemeMode.None;
	}
	[ObservableProperty]
	public partial int FontSize { get; set; }

	/// <summary>
	/// サンプルのリストデータ(Grid向けのサブアイテムを含む)
	/// </summary>
	public ObservableCollection<ListItem> Items { get; } = new();

	/// <summary>
	/// 現在選択されているリストのアイテム
	/// </summary>
	[ObservableProperty]
	public partial ListItem? SelectedItem { get; set; }

	/// <summary>
	/// ボタンデモ用の有効無効切り替えフラグ
	/// </summary>
	[ObservableProperty]
	public partial bool IsEnabledButtons { get; set; }

	/// <summary>
	/// App.xaml が Fluent.xaml を含んで定義されているかのフラグ(起動時固定)
	/// </summary>
	public bool IsThemeXamlNotIncluded { get; }

	public MainViewModel()
	{
		DumpResourceDictionaries(App.Current.Resources.MergedDictionaries);


		// Fluent.xaml を含んだ app.xaml として定義されているかの判定(動的切り替えの有無判定用)
		var detect = App.Current.Resources.MergedDictionaries.Any(resDir => resDir.Source.AbsoluteUri.Contains("Fluent.xaml"));
		IsThemeXamlNotIncluded = detect ==  false; // ここをtrueにすると、テーマのオンオフを切り替えできる
		OnPropertyChanged(nameof(IsThemeXamlNotIncluded));
		IsThemeMode = detect;
		SelectedThemeMode = ThemeMode.System;

		FontSize = 24;

		ThemeModeItems.Add(ThemeMode.System);
		ThemeModeItems.Add(ThemeMode.Light);
		ThemeModeItems.Add(ThemeMode.Dark);

		Items.Add(new("Item 1", "SubItem 1", 1, true));
		Items.Add(new("Item 2", "SubItem 2", 2, true));
		Items.Add(new("Item 3", "SubItem 3", 3, false));
	}

	private void DumpResourceDictionaries(Collection<ResourceDictionary> dictionaries)
	{
		foreach( var resDic in dictionaries)
		{
			Debug.WriteLine($"ResourceDictionary: {resDic.Source}");
			foreach ( var key in resDic.Keys)
			{
				Debug.WriteLine($"{key}={resDic[key]}");
			}
			DumpResourceDictionaries(resDic.MergedDictionaries);
		}
	}
}
