//
// SWDirectionPanGestureRecognizer.cs
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

public class SWDirectionPanGestureRecognizer : UIPanGestureRecognizer
{
	public SWDirectionPanGestureRecognizerDirection Direction {
		get;
		set;
	}

	private bool _dragging;
	PointF _init;

	public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, UIEvent evt)
	{
		base.TouchesBegan (touches, evt);
		_init = this.LocationInView (View);
		_dragging = false;
	}

	public override void TouchesMoved (MonoTouch.Foundation.NSSet touches, UIEvent evt)
	{
		base.TouchesMoved (touches, evt);

		if (State == UIGestureRecognizerState.Failed || _dragging)
			return;

		const int directionPanTreshold = 5;

		var nowPoint = LocationInView (View);
		var moveX = nowPoint.X - _init.X;
		var moveY = nowPoint.Y - _init.Y;

		if (Math.Abs (moveX) > directionPanTreshold) {

			if (Direction == SWDirectionPanGestureRecognizerDirection.SWDirectionPanGestureRecognizerHorizontal)
				_dragging = true;
			else 
				State = UIGestureRecognizerState.Failed;

		} else if (Math.Abs (moveY) > directionPanTreshold) {
			if (Direction == SWDirectionPanGestureRecognizerDirection.SWDirectionPanGestureRecognizerVertical)
				_dragging = true;
			else 
				State = UIGestureRecognizerState.Failed;
		}
	}
}
