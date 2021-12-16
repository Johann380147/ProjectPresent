using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using Android.Views;

namespace ProjectPresent
{
    public class xColumnArrayAdapter : ArrayAdapter
    {
        readonly List<Students> students;
        public xColumnArrayAdapter(Context context, int resource, List<Students> list)
            : base(context, resource, list)
        {
            this.students = list;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if (v == null)
            {
                LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
                v = inflater.Inflate(Resource.Layout.SimpleListItem1, parent, false);
            }
            v.FindViewById<TextView>(Resource.Id.text01).Text = students[position].Name;
            v.FindViewById<TextView>(Resource.Id.text02).Text = students[position].AdminNo;
            return v;
        }
        
    }

	public class DialogArrayAdapter : ArrayAdapter
	{
		SearchHistory searchHistory;

		public DialogArrayAdapter(Context context, int resource, SearchHistory searchHistory)
			: base(context, resource, searchHistory.studentDataList)
		{
			this.searchHistory = searchHistory;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View v = convertView;
			if (v == null)
			{
				LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
				v = inflater.Inflate(Resource.Layout.SimpleListItem1, parent, false);
			}
			searchHistory.textHistoryList.Reverse ();
			searchHistory.numberOfResults.Reverse ();
			v.FindViewById<TextView>(Resource.Id.text01).Text = "\"" + searchHistory.textHistoryList[position] + "\"";
			v.FindViewById<TextView>(Resource.Id.text02).Text = searchHistory.numberOfResults[position].ToString() + " Result(s) found";
			searchHistory.textHistoryList.Reverse ();
			searchHistory.numberOfResults.Reverse ();
			return v;
		}
	}

	public class ImageArrayAdapter : ArrayAdapter
	{
		List<string> text;
		List<int> image;
		public ImageArrayAdapter(Context context, int resource, List<string> text, List<int> image)
			:base(context, resource, text)
		{
			this.text = text;
			this.image = image;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View v = convertView;
			if (v == null)
			{
				LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
				v = inflater.Inflate(Resource.Layout.ImageList, parent, false);
			}
			var imageView = v.FindViewById<TextView> (Resource.Id.imageTextView);
			imageView.SetCompoundDrawablesWithIntrinsicBounds (image [position], 0, 0, 0);
			imageView.Text = text [position];
			return v;
		}
	}
    
}

