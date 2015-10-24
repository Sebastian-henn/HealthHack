using UnityEngine;

public class SomethingHappens : MonoBehaviour 
{
	private GazeAwareComponent _gazeAware;
	
	void Start () 
	{
		_gazeAware = GetComponent<GazeAwareComponent>();
	}
	
	void Update () 
	{
		if (_gazeAware.HasGaze) 
		{
			transform.Rotate(Vector3.forward);
		}
	}
}