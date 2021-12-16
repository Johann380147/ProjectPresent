using System;
using Android.Text.Format;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Android.Util;
using System.Timers;

namespace ProjectPresent
{
	public class PastRecordsActivity : Android.Support.V4.App.Fragment
	{
		string[] dates;
		Timer timer;
		LinearLayout tempView;
		TextView tempTextView;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.PastRecordsLayout, container, false);
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			Space spaceRecords = View.FindViewById<Space> (Resource.Id.spaceRecords);
			LinearLayout layout = View.FindViewById<LinearLayout> (Resource.Id.pastRecordsLayout);
			TextView btnDate;
			TextView txtMonthCategory;

			var param = spaceRecords.LayoutParameters;
			param.Height = (int)(HelperClass.GetScreenDimensions (Activity.WindowManager).Y * 0.05);

			Time time = new Time ();
			time.SetToNow ();
			var layoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			var txtLayoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			txtLayoutParameters.SetMargins (0, 15, 0, 15);

			btnDate = new TextView (Activity) {
				Text = "Today " + "(" + time.Format ("%Y-%m-%d") + ")",
				LayoutParameters = layoutParameters,
				Clickable = true,
				TextSize = 22
			};
			btnDate.SetPadding (0, 20, 0, 20);
			btnDate.SetTextColor (Android.Graphics.Color.ParseColor("#D32F2F"));
			btnDate.Click += (object sender, EventArgs e) => {
				Intent i = new Intent(Activity, typeof(MainActivity));
				i.PutExtra("date", time.Format ("%Y-%m-%d"));
				i.PutExtra("code", 4);
				Activity.SetResult(Result.FirstUser, i);
				Activity.Finish();
			};
			layout.AddView(btnDate);

			dates = Activity.Intent.Extras.GetStringArray("date");

			if (dates != null) {
				Array.Reverse (dates);

				List<string> months = new List<string> ();
				foreach (string date in dates) {
					if (!months.Contains (date.Remove (7))) {
						months.Add (date.Remove (7));
					}
				}

				foreach (string month in months) {
					int counter = 0;
					txtMonthCategory = new TextView (Activity) {
						Text = month,
						Clickable = true,
						LayoutParameters = txtLayoutParameters
					};
					txtMonthCategory.SetTextAppearance (Activity, Resource.Style.Base_TextAppearance_AppCompat_Headline);
					txtMonthCategory.SetCompoundDrawablesWithIntrinsicBounds (Resource.Drawable.triangle_right, 0, 0, 0);
					layout.AddView (txtMonthCategory);
					LinearLayout buttonLayout = new LinearLayout (Activity) {
						LayoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent),
						Orientation = Orientation.Vertical,
						Visibility = ViewStates.Gone
					};
					layout.AddView (buttonLayout);
					if(month == time.Format("%Y-%m"))
					{
						tempTextView = txtMonthCategory;
						tempView = buttonLayout;
					}

					bool altColor = true;
					for (int x = 0; x < dates.Length; x++) {
						if (dates [x] == time.Format ("%Y-%m-%d"))
							continue;
						if (dates [x].Remove (7) == month) 
						{
							string id = month.Replace ("-", "") + counter;
							btnDate = new TextView (Activity) {
								Id = int.Parse (id),
								Text = dates [x],
								LayoutParameters = layoutParameters,
								Clickable = true,
								TextSize = 20
							};
							btnDate.SetPadding (30, 20, 30, 20);
							if(altColor)
							{
								btnDate.SetBackgroundColor (Android.Graphics.Color.ParseColor("#78909C"));
								btnDate.SetTextColor (Android.Graphics.Color.Beige);
							}
							else
								btnDate.SetBackgroundColor (Android.Graphics.Color.ParseColor("#B0BEC5"));
								
							btnDate.Click += (object sender, EventArgs e) => {
								Intent i = new Intent (Activity, typeof(MainActivity));
								var temp = sender as TextView;
								i.PutExtra ("date", temp.Text);
								i.PutExtra("code", 4);
								Activity.SetResult (Result.FirstUser, i);
								Activity.Finish ();	
							};
							buttonLayout.AddView (btnDate);
							counter++;
							altColor = !altColor;
						}
					}

					txtMonthCategory.Click += (object sender, EventArgs e) => {
						int num = 0;
						var s = sender as TextView;
						string id = s.Text.Replace ("-", "") + num;
						var tempBtn = View.FindViewById<TextView> (int.Parse (id));
						if (tempBtn != null) 
						{
							var tempLayout = (LinearLayout)(ViewGroup)tempBtn.Parent;
							if (tempLayout.Visibility == ViewStates.Gone) 
							{
								if(timer != null) timer.Close();
								tempLayout.Visibility = ViewStates.Visible;
								HelperClass.SlideDown (Activity, tempLayout);
								s.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.triangle_down, 0, 0, 0);
							}
							else 
							{
								HelperClass.SlideUp (Activity, tempLayout);
								s.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.triangle_right, 0, 0, 0);

								if(timer != null) timer.Close();
								timer = new Timer(180);
								timer.Enabled = true;
								timer.Elapsed += (object send, ElapsedEventArgs a) => {
									// Analysis disable once ConvertToLambdaExpression
									Activity.RunOnUiThread(() => tempLayout.Visibility = ViewStates.Gone);
									timer.Stop();
									timer.Close();
								};
								timer.Start();

							}
						}

					};

				}
				if(tempView.ChildCount == 0)
				{
					layout.RemoveView (tempTextView);
					layout.RemoveView (tempView);
					tempTextView.Dispose ();
					tempView.Dispose ();
				}
			}


		}

	}
}

