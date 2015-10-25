using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	private int i = 0;
	Renderer rend;
	public Slider slider1;
	public Slider slider2;
	public Slider slider3;
	private int state = 0;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.color = new Color (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (slider1.value == 1)
			state = 1;
		if (slider2.value == 1)
			state = 2;
		if (slider3.value == 1)
			state = 3;
		if (state != 0)
			fadeSuccess ();
	}

	void fadeSuccess() {
		Color c = new Color (0, 0, 0);
		switch (state) {
		case 1:
			c = new Color (0, (float)(i++ / 100.0), 0); break;
		case 2:
			c = new Color (0, 0, (float)(i++ / 100.0)); break;
		case 3:
			c = new Color ((float)(i++ / 100.0), 0, 0); break;
		}
		rend.material.color = c;
	}
}
