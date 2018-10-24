using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            var songs = await SongLoader.Load();

            ListAdapter = new ListAdapter<Song>() {
                DataSource = songs.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " " + s.Album
			};
		}
	}
}


