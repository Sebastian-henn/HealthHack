using UnityEngine;
using System.Collections;

public class BackgroundColour : MonoBehaviour
{
	public Color colourStart = Color.white;
	public Color colourHappy = Color.green;
	public Color colourSad = Color.blue;
	public Color colourAngry = Color.red;

	public float duration = 1.0F;
	
	private Color currentColor;
	private Material materialColored;

	public Renderer rend;

	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;

	void Start()
	{
		rend = GetComponent<Renderer>();
	}
	
	void Update()
	{
		float f1 = (float)obj1.GetComponent<CountTime>().thisFace().counter;
		float f2 = (float)obj2.GetComponent<CountTime>().thisFace().counter;
		float f3 = (float)obj3.GetComponent<CountTime>().thisFace().counter;
		print (f1);
		print (f2);
		print (f3);

		Color colourEnd = colourHappy;

		float value = (float)((f1 / 5000));
		if (value > duration)
			value = duration;
		
		float lerp = Mathf.PingPong (value, duration) / duration;
		
		rend.material.color = Color.Lerp (colourStart,colourEnd,lerp);

		//Color col = new Color (10, 10, value);
		//rend.material.color = Color.green;
	}
	
	
}