using UnityEngine;
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
			//print ("Face = " + thisFace().name + " Counter =" + thisFace().counter);
		} else {
			attentionTimer.Stop();
			distractionTimer.Start();

			if(distractionTimer.ElapsedMilliseconds > 500) {
				attentionTimer.Reset();
			}
		}
	}
	
	public FaceObject thisFace() 
	{
		switch (this.tag) {
		case "HappyTag":
		{

			return Happy;
		}
		case "SadTag":
			return Sad;;
		case "ConfusedTag":
			return Confused;
		default:
			return null;
		}
	}
}