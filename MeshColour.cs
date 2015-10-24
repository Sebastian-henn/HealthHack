using UnityEngine;
using System.Collections;

public class MeshColour : MonoBehaviour
{
	public Color colourStart = Color.white;
	public Color colourEnd = Color.green;
	public float duration = 1.0F;

	private Color currentColor;
	private Material materialColored;
	public Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer>();
		//rend.material.shader = Shader.Find ("Specular");
	}

	void Update()
	{
		FaceObject currentFace = this.GetComponent<CountTime> ().thisFace ();
		float value = (float)((currentFace.counter / 5000));
		if (value > duration)
			value = duration;
		//print (value);

		float lerp = Mathf.PingPong (value, duration) / duration;

		//Color col = new Color (10, 10, value);
		rend.material.color = Color.Lerp (colourStart,colourEnd,lerp);
	}


}