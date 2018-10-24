using System.Linq;
using UIKit;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

            var songs = await SongLoader.Load();

			TableView.Source = new ViewControllerSource<Song>(TableView) {
				DataSource = songs.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " " + s.Album,
			};
		}
	}

}

