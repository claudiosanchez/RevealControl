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
using RevealControl;


public class SWRevealViewController : UIViewController
{
	public float RearViewRevealWidth { get; set;}
	public float RearViewRevealOverdraw { get; set;}

	public float RightViewRevealWidth { get; set;}
	public float RightViewRevealOverdraw { get; set;}


	public FrontViewPosition FrontViewPosition {
		get;
		set;
	}

	public float FrontViewShadowRadius {
		get;
		set;
	}

	public SizeF FrontViewShadowOffset {
		get;
		set;
	}

	private UIGestureRecognizerDelegate _delegate;

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

	FrontViewPosition _panInitialFrontPosition;

	const int FrontViewPositionNone = 0xff;

	FrontViewPosition RearViewPosition {
		get;
		set;
	}

	FrontViewPosition RightViewPosition {
		get;
		set;
	}

	bool BounceBackOnOverdraw {
		get;
		set;
	}

	bool BounceBackOnLeftOverdraw {
		get;
		set;
	}

	bool StableDragOnOverdraw {
		get;
		set;
	}

	bool StableDragOnLeftOverdraw {
		get;
		set;
	}

	float _quickFlickVelocity;

	float QuickFlickVelocity {
		get;
		set;
	}

	double ToggleAnimationDuration {
		get;
		set;
	}

	bool UserInteractionStore {
		get;
		set;
	}

	void InitializeDefaultProperties ()
	{
		RearViewPosition  = FrontViewPosition.FrontViewPositionLeft;
		RightViewPosition = FrontViewPosition.FrontViewPositionLeft;
		RearViewRevealWidth = 260.0f;
		RearViewRevealOverdraw = 60.0f;
		RightViewRevealWidth = 260.0f;
		RightViewRevealOverdraw = 60.0f;
		BounceBackOnOverdraw = true;
		BounceBackOnLeftOverdraw = true;
		StableDragOnOverdraw = false;
		StableDragOnLeftOverdraw = false;
		QuickFlickVelocity = 250.0f;
		ToggleAnimationDuration = 0.25;
		FrontViewShadowRadius = 2.5f;
		FrontViewShadowOffset = new SizeF(0.0f, 2.5f);
		UserInteractionStore = true;
	}

	void Initialize ()
	{
		InitializeDefaultProperties();
	}

	public SWRevealViewController ()
	{
		
	}

	public SWRevealViewController (UIViewController rearViewController, UIViewController frontViewController)
	{
		Initialize ();

		RearViewController = rearViewController;
		FrontViewController = frontViewController;


	}

	public void SetFrontViewController (UIViewController frontController, bool isAnimated)
	{
		throw new NotImplementedException ();
	}

	public void RevealToggleAnimated (bool isAnimated)
	{
		throw new NotImplementedException ();
	}

	public void RightRevealToggle (bool iSAnimated)
	{
		throw new NotImplementedException ();
	}

	public void GetBounceBack(out bool bounceBack, out bool stableDrag, int simetry)
	{
		throw new NotImplementedException ();
	}

	public void GetAdjustedFrontViewPosition(FrontViewPosition position, int simetry)
	{
		throw new NotImplementedException ();
	}

	public void GetRevealWidth (out float revealWidth, out float revealOverdraw, int simetry)
	{
		throw new NotImplementedException ();
	}

	public override void LoadView ()
	{
		
		// This is what Apple tells us to set as the initial frame, which is of course totally irrelevant
		// with the modern view controller containment patterns, let's leave it for the sake of it!
		var frame = UIScreen.MainScreen.ApplicationFrame;

		// create a custom content view for the controller
		var ContentView = new SWRevealView (frame, this);

		// set the content view to resize along with its superview
		//[_contentView setAutoresizingMask:UIViewAutoresizingFlexibleWidth|UIViewAutoresizingFlexibleHeight];

		// set our contentView to the controllers view
		//self.view = _contentView;

	}


}




