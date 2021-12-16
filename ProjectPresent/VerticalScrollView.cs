
using Android.Widget;
using Android.Util;
using Android.Content;
using System.ComponentModel;
using Android.Runtime;


namespace ProjectPresent
{
	[DesignTimeVisible (true)]
	[Register("com.nyp.projectpresent.VerticalScrollview")]
	public class VerticalScrollview : ScrollView{

		public VerticalScrollview(Context context)
			:base(context)
		{ }

		public VerticalScrollview(Context context, IAttributeSet attrs) 
				:base(context, attrs)
		{ }

		public VerticalScrollview(Context context, IAttributeSet attrs, int defStyle) 
			:base(context, attrs, defStyle)
		{ }

		public override bool OnInterceptTouchEvent (Android.Views.MotionEvent ev)
		{
			Android.Views.MotionEventActions action = ev.Action;
			switch (action)
			{
			case Android.Views.MotionEventActions.Down: 
				Log.Info ("VerticalScrollview", "onInterceptTouchEvent: DOWN super false");
				base.OnTouchEvent (ev);
				break;

			case Android.Views.MotionEventActions.Move:
				return false; // redirect MotionEvents to ourself

			case Android.Views.MotionEventActions.Cancel:
				Log.Info("VerticalScrollview", "onInterceptTouchEvent: CANCEL super false" );
				base.OnTouchEvent(ev);
				break;

			case Android.Views.MotionEventActions.Up:
				Log.Info("VerticalScrollview", "onInterceptTouchEvent: UP super false" );
				return false;

			default: Log.Info("VerticalScrollview", "onInterceptTouchEvent: " + action ); 
				break;
			}

			return false;

		}

		public override bool OnTouchEvent (Android.Views.MotionEvent e)
		{
			Log.Info("VerticalScrollview", "onTouchEvent. action: " + e.Action);
			return base.OnTouchEvent (e);
		}
	}
}

