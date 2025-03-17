using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FluentDemo;

public partial class ListItem : ObservableObject
{
	[ObservableProperty]
	public partial string Item { get; set; }

	[ObservableProperty]
	public partial string SubItem { get; set; }

	[ObservableProperty]
	public partial int SubItem2 { get; set; }

	[ObservableProperty]
	public partial bool SubItem3 { get; set; }

	public ListItem( string item, string subItem, int subItem2, bool subItem3 )
	{
		Item = item;
		SubItem = subItem;
		SubItem2 = subItem2;
		SubItem3 = subItem3;
	}
}
