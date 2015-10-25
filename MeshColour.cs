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
	public Renderer backgroundRenderer;
	public GameObject background;
	
	void Start()
	{
		//colourStart = background.GetComponent<Color> ();
		rend = GetComponent<Renderer>();
	}
	
	void Update()
	{
		FaceObject currentFace = this.GetComponent<CountTime> ().thisFace ();
		float value = (float)((currentFace.counter / 5000));
		if (value > duration)
			value = duration;




		float lerp = Mathf.PingPong (value, duration) / duration;
		rend.material.color = Color.Lerp (colourStart,colourEnd,lerp);

	}
}