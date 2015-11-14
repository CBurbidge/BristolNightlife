using System.Windows.Controls;
using System.Windows.Input;
using Cirrious.MvvmCross.WindowsPhone.Views;
using BristolNightlife.Core.ViewModels;

namespace BristolNightlife.Phone.Views
{
	public partial class PivotView : MvxPhonePage
	{
		public PivotView()
		{
			InitializeComponent();
		}

		private void EventsName_OnTap(object sender, GestureEventArgs e)
		{
			var listBox = ((ListBox)sender);
			var eventSummaryViewModel = (EventSummaryViewModel)listBox.SelectedItems[0];
			eventSummaryViewModel.GoToEventCommand.Execute(sender);
			
			_ClearListItemAfterItHasBeenClicked(listBox);
		}

		private static void _ClearListItemAfterItHasBeenClicked(ListBox listBox)
		{
			listBox.SelectionMode = SelectionMode.Multiple;
			listBox.SelectedItems.Clear();
		}
	}
}