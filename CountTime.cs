using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.Threading;

public class CountTime : MonoBehaviour 
{
	private GazeAwareComponent _gazeAware;

	public FaceObject Happy = new FaceObject("Happy");
	public FaceObject Sad = new FaceObject("Sad");
	public FaceObject Confused = new FaceObject("Confused");

	private FaceObject currentFace = new FaceObject("Current");
	private Stopwatch attentionTimer = new Stopwatch();
	private Stopwatch distractionTimer = new Stopwatch();


	public int counter = 0;

	void Start () 
	{
		_gazeAware = GetComponent<GazeAwareComponent>();
	}
	
	void Update () 
	{
		Slider slider1 = GameObject.Find ("Slider1").GetComponent<Slider>();
		Slider slider2 = GameObject.Find ("Slider2").GetComponent<Slider>();
		Slider slider3 = GameObject.Find ("Slider3").GetComponent<Slider>();


		if (_gazeAware.HasGaze) {
			attentionTimer.Start ();
			distractionTimer.Stop ();
			distractionTimer.Reset();
		
			switch (this.tag) {
			case "HappyTag":
				currentFace = Happy;
				break;
			case "SadTag":
				currentFace = Sad;
				break;
			case "ConfusedTag":
				currentFace = Confused;
				break;
			}

			thisFace().counter = attentionTimer.Elapsed.TotalMilliseconds;

			slider1.value = (float)(Happy.counter)/5000;
			slider2.value = (float)(Sad.counter)/5000;
			slider3.value = (float)(Confused.counter)/5000;

			//print ("Face = " + thisFace().name + " Counter =" + thisFace().counter);
		} else {
			attentionTimer.Stop();
			distractionTimer.Start();

			if(distractionTimer.ElapsedMilliseconds > 750) {
				attentionTimer.Reset();
			}
		}
	}
	
	public FaceObject thisFace() 
	{
		switch (this.tag) {
		case "HappyTag":
			return Happy;
		case "SadTag":
			return Sad;;
		case "ConfusedTag":
			return Confused;
		default:
			return null;
		}
	}
}