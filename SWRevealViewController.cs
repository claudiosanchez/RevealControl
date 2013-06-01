//
// obj-c.cs
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


public class SWRevealViewController : UIViewController, UIGestureRecognizerDelegate 
{
	public UIViewController RearViewController {
		get;
		set;
	}

	public UIViewController RightViewController {
		get;
		set;
	}

	public UIViewController FrontViewController {
		get;
		set;
	}

	public UIPanGestureRecognizer PanGestureRecognizer {
		get;
		set;
	}

	void Initialize ()
	{
		throw new NotImplementedException ();
	}

	public SWRevealViewController (UIViewController rearViewController, UIViewController frontViewController)
	{

		RearViewController = rearViewController;
		FrontViewController = frontViewController;

		Initialize ();
	}

	public void SetFrontViewController (UIViewController frontController, bool isAnimated)
	{

	}

	public void RevealToggleAnimated (bool isAnimated)
	{

	}

	public void RightRevealToggle (bool iSAnimated)
	{
	}


	void GetRevealWidth(float revealWidth, float revealOverdraw, int symetry)
	{
	}

	void GetBounceBack(bool bounceBack, bool stableDrag, int simetry)
	{
	}

	void GetAdjustedFrontViewPosition(FrontViewPosition position, int simetry)
	{
	}
}




