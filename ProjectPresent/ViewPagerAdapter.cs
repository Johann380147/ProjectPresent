using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang;

namespace ProjectPresent
{
	public class ViewPagerAdapter : FragmentPagerAdapter
	{
		private List<Fragment> mFragmentList = new List<Fragment>();
		private List<string> mFragmentTitleList = new List<string>();

		public ViewPagerAdapter (FragmentManager fm)
			:base (fm)
		{
		}

		public override Fragment GetItem (int position)
		{
			return mFragmentList [position];
		}

		public override int Count {
			get {
				return mFragmentList.Count;
			}
		}

		public void AddFragment(Fragment fragment, string title) 
		{
			mFragmentList.Add(fragment);
			mFragmentTitleList.Add(title);
		}

		public override ICharSequence GetPageTitleFormatted (int position)
		{
			ICharSequence text = new Java.Lang.String (mFragmentTitleList [position]);
			return text;
		}
	}
}

