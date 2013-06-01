 //
// View.cs
//
// Author:
//       Claudio Sanchez <claudio@megsoftconsulting.com>
//
// Copyright (c) 2013 Megsoft Consulting Inc
//
//
using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace RevealControl
{
	/*
@property (nonatomic, readonly) UIView *rearView;
@property (nonatomic, readonly) UIView *rightView;
@property (nonatomic, readonly) UIView *frontView;
@property (nonatomic, assign) BOOL disableLayout;
	  * */


	public class SWRevealView: UIView
	{
		void Initialize ()
		{
			FrontView = new UIView (Bounds);
			FrontView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			AddSubview (FrontView);

			var layer = FrontView.Layer;

			layer.MasksToBounds = false;
			layer.ShadowColor = UIColor.Black.CGColor;
			layer.ShadowOpacity = 1.0f;
			/*
			 * frontViewLayer.shadowOffset = _c.frontViewShadowOffset;
        frontViewLayer.shadowRadius = _c.frontViewShadowRadius
        */

		}

		public SWRevealView (RectangleF frame, SWRevealViewController controller): base(frame)
		{
			Controller = controller;
			Initialize ();

		}

		public UIView RearView {
			get;
			private set;
		}

		public UIView RightView
		{
			get;
			private set;
		}

		public UIView FrontView  {
			get;
			private set;
		}

		public bool DisableLayout {
			get;
			set;
		}

		public SWRevealViewController Controller {
			get;
			private set;
		}


	}
}

