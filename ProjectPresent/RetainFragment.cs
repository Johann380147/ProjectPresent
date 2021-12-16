
using System.Collections.Generic;
using Android.App;
using Android.OS;
using System.Collections;

namespace ProjectPresent
{
    class RetainFragment : Fragment
    {
        public List<Students> students { get; set; }
		public string Module { get; set; }
		public string Time { get; set; }
		public bool Blocked { get; set; }
		public string Text { get; set; }
		public string Text02 { get; set; }
		public SearchHistory searchHistory { get; set;}
		public int Position { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }
        
    }

	class RetainFragmentV4 : Android.Support.V4.App.Fragment
	{
		public List<Students> students { get; set; }
		public string Module { get; set; }
		public string Time { get; set; }
		public bool Blocked { get; set; }
		public string Text { get; set; }
		public SearchHistory searchHistory { get; set;}
		public bool NotEditable { get; set; }
		public string[] Dates { get; set; }

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
		}

	}
}