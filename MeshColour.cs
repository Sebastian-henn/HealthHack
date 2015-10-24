﻿using UnityEngine;
using System.Collections;

public class MeshColour : MonoBehaviour
{
	public Color colourStart = Color.white;
	public Color colourHappy = Color.green;
	public Color colourSad = Color.blue;
	public Color colourAngry = Color.red;
	public float duration = 1.0F;
	
	private Color currentColor;
	private Material materialColored;
	public Renderer rend;
	public Renderer backgroundRenderer;
	public GameObject background;
	
	void Start()
	{
		//colourStart = background.GetComponent<Color> ();
		rend = GetComponent<Renderer>();
	}
	
	void Update()
	{
		Color colourEnd = colourHappy;

		FaceObject currentFace = this.GetComponent<CountTime> ().thisFace ();
		float value = (float)((currentFace.counter / 5000));
		if (value > duration)
			value = duration;
		
		float lerp = Mathf.PingPong (value, duration) / duration;

		rend.material.color = Color.Lerp (colourStart,colourEnd,lerp);

		backgroundRenderer.material.color = Color.Lerp (colourStart,colourEnd,lerp);
	}
	
	
}