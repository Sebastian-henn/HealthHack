using UnityEngine;
using UnityEngine.EventSystems;

public class Victory : MonoBehaviour
{
	private float _transparency;
	public float widthRatio = 700;
	public float heightRatio = 300;
	public string title = "Put instructions here!";
	public Vector2 titlePos = new Vector2(0, 0);
	public Vector2 titleSize = new Vector2(100, 50);
	public string text = "Put instructions here!";
	public Vector2 textPos = new Vector2(0, 0);
	public Vector2 textSize = new Vector2(100, 50);
	public Material material;
	public Texture2D texture = null;
	public Vector2 texturePos = new Vector2(0, 0);
	public Vector2 textureSize = new Vector2(100, 50);
	
	bool start = false;
	long startTime = 0;
	long time = 0;

	
	public void Awake()
	{
		System.Diagnostics.Debug.Assert (material != null, "Instructions require a material.");
		System.Diagnostics.Debug.Assert (material.passCount > 0, "Material requires at least one pass.");
		_transparency = 1f;
		
	}
	
	public void OnGUI()
	{
		if (_transparency == 0f)
		{
			return;
		}
		var content = new GUIContent (text);
		
		// Create the font style.
		var style = new GUIStyle ();
		style.alignment = TextAnchor.MiddleCenter;
		style.wordWrap = true;
		style.fontSize = 30;
		// Tobii EyeX color: EC0088
		style.normal.textColor = new Color (0.925f, 0f, 0.533f, _transparency);
		
		float height = Screen.height * heightRatio;
		float width = Screen.width * widthRatio;
		// Calculate the boundaries.
		var bounds = new Rect ((Screen.width - width) / 2, 
		                       (Screen.height - height) / 2, width, height);
		
		// Draw the background rectangle.
		DrawRectangle (bounds);
		
		//Draw the Willy's Picture//
		float w1 = textureSize.x / 1000 * width;
		float h1 = textureSize.y / 1000 * height;
		float r = (float) texture.width / (float) texture.height;
		if (h1 > w1 / r) {
			h1 = w1 / r;
		} else {
			w1 = r * h1;
		}
		
		GUI.DrawTexture(new Rect(bounds.x + texturePos.x / 1000f * width, 
		                         bounds.y + texturePos.y / 1000f * height, 
		                         w1, 
		                         h1), texture);
		
		if (GUI.Button(new Rect(bounds.x + 300f, 
		                        bounds.y + bounds.height - 100f, 
		                        bounds.width - 450f, 60f), "Play"))
		{
			GameObject timer = GameObject.FindGameObjectWithTag ("TagTimer");
		}
		
		// Draw the label.
		GUI.Label(new Rect(bounds.x + titlePos.x / 1000f * width, 
		                   bounds.y + titlePos.y / 1000f * height, 
		                   titleSize.x / 1000f * width,
		                   titleSize.y / 1000f * height), title, style);
		
		GUI.Label(new Rect(bounds.x + textPos.x / 1000f * width, 
		                   bounds.y + textPos.y / 1000f * height, 
		                   textSize.x / 1000f * width,
		                   textSize.y / 1000f * height), text, style);
		
	}
	
	void DrawRectangle (Rect position)
	{    
		// We shouldn't draw until we are told to do so.
		if (Event.current.type != EventType.Repaint) 
		{
			return;
		}
		// Make sure we have a material with at least on pass.
		if(material == null || material.passCount == 0 || _transparency == 0f)
		{
			return;
		}
		
		// Activate the first pass.
		material.SetPass (0);
		
		GL.Begin (GL.QUADS);
		GL.Color ( new Color (0f, 0f, 0f, _transparency));
		GL.Vertex3 (position.x, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y + position.height, 0);
		GL.Vertex3 (position.x, position.y + position.height, 0);
		GL.End ();
	}
	
	
}