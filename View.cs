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
using System.Linq;

namespace RevealControl
{
	public class SWRevealView: UIView
	{
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

		public SWRevealView (RectangleF frame, SWRevealViewController controller): base(frame)
		{
			Controller = controller;
			Initialize ();
		}

		void Initialize ()
		{
			FrontView = new UIView (Bounds);
			FrontView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			AddSubview (FrontView);

			var layer = FrontView.Layer;

			layer.MasksToBounds = false;
			layer.ShadowColor = UIColor.Black.CGColor;
			layer.ShadowOpacity = 1.0f;

			layer.ShadowOffset = Controller.FrontViewShadowOffset;
			layer.ShadowRadius = Controller.FrontViewShadowRadius;
		}

		private void LayoutRearViews ()
		{
			float rearWidth = Controller.RearViewRevealWidth + Controller.RearViewRevealOverdraw;
			RearView.Frame = new RectangleF (0, 0, rearWidth, Bounds.Size.Height);

			var rightWidth = Controller.RightViewRevealWidth + Controller.RightViewRevealOverdraw;
			RightView.Frame = new RectangleF (Bounds.Size.Width- rightWidth, 0, rightWidth, Bounds.Size.Height);
		}

		public override void LayoutSubviews ()
		{
			if (DisableLayout)
				return;

			this.LayoutRearViews ();
			float xPosition = FrontLocationForPosition (Controller.FrontViewPosition);
			FrontView.Frame = new RectangleF (xPosition, 0.0f, Bounds.Size.Width, Bounds.Size.Height);

			UIBezierPath shadowPath = UIBezierPath.FromRect (FrontView.Bounds);
			FrontView.Layer.ShadowPath = shadowPath.CGPath;

		}

		void PrepareForNewPosition (FrontViewPosition newPosition)
		{
			if (RearView == null || RightView == null) return;

			int symetry = newPosition < FrontViewPosition.FrontViewPositionLeft ? -1 : 1;

			var rearIndex = Subviews.ToList ().IndexOf (RearView);
			var rightIndex = Subviews.ToList ().IndexOf (RightView);

			if ((symetry < 0 && rightIndex < rearIndex) || (symetry > 0 && rearIndex < rightIndex))
				ExchangeSubview (rightIndex, rearIndex);
		}

		void PrepareRearViewForPosition(FrontViewPosition newPosition)
		{
			if ( RearView == null )
			{
				RearView = new UIView (Bounds);
				RearView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
				InsertSubviewBelow (RearView, FrontView);
			}
			LayoutRearViews ();
			PrepareForNewPosition (newPosition);
		}

		FrontViewPosition _frontViewPosition;

		float FrontLocationForPosition(FrontViewPosition newPosition)
		{
			var location = 0.0f;

			float revealWidth, revealOverdraw;
			int simetry = (_frontViewPosition < FrontViewPosition.FrontViewPositionLeft) ? -1 : 1;

			Controller.GetRevealWidth (out revealWidth, out revealOverdraw, simetry);

			if (_frontViewPosition == FrontViewPosition.FrontViewPositionRight)
				location = revealWidth;
			else if (_frontViewPosition > FrontViewPosition.FrontViewPositionRight)
				location = revealWidth + revealOverdraw;

			return location * simetry;



		}

		void DragFrontViewToXPosition(float xPosition)
		{
			xPosition = AdjustedDragLocationForLocation (xPosition);
			FrontView.Frame = new RectangleF (xPosition, 0.0f, Bounds.Size.Width, Bounds.Size.Height);
		}

		void PrepareRightViewForPosition(FrontViewPosition newPosition)
		{
			if (RightView == null) {
				RightView = new UIView (Bounds);
				RightView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
				InsertSubviewBelow (RightView, FrontView);
			}

			LayoutRearViews ();
			PrepareForNewPosition (newPosition);
		
		}

		private void GetAdjustedFrontViewPosition(FrontViewPosition frontViewPosition, int symetry)
		{
				
		}

		private float AdjustedDragLocationForLocation(float x)
		{
			float result, revealWidth, revealOverdraw;
			bool bounceBack, stableDrag;
			var position = Controller.FrontViewPosition;

			int symetry = x<0 ? -1 : 1;

			Controller.GetRevealWidth (out revealWidth, out revealOverdraw, symetry);

			Controller.GetBounceBack (out bounceBack, out stableDrag, symetry);

			bool stableTrack = (!bounceBack || stableDrag || (position == FrontViewPosition.FrontViewPositionRightMost) || position==FrontViewPosition.FrontViewPositionLeftSideMost);

			if (stableTrack) {
				revealWidth += revealOverdraw;
				revealOverdraw = 0.0f;
			}

			x = x * symetry;
	

		if (x <= revealWidth)
			result = x;         // Translate linearly.

		else if (x <= revealWidth+2*revealOverdraw)
			result = revealWidth + (x-revealWidth)/2;   // slow down translation by halph the movement.

		else
			result = revealWidth+revealOverdraw;        // keep at the rightMost location.

		return result * symetry;
	
		}
	}
}

