//
// FrontViewPosition.cs
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

public enum FrontViewPosition
{
	FrontViewPositionLeftSideMostRemoved
,
	FrontViewPositionLeftSideMost
,
	FrontViewPositionLeftSide
,

	// Left position, rear view is hidden behind front controller
	FrontViewPositionLeft
,

	// Right possition, front view is presented right-offseted by rearViewRevealWidth
	FrontViewPositionRight
,

	// Right most possition, front view is presented right-offseted by rearViewRevealWidth+rearViewRevealOverdraw
	FrontViewPositionRightMost
,

	// Front controller is removed from view. Animated transitioning from this state will cause the same
	// effect than animating from FrontViewPositionRightMost. Use this instead of FrontViewPositionRightMost when
	// you intent to remove the front controller view to be removed from the view hierarchy.
	FrontViewPositionRightMostRemoved
,

}
