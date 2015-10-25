using UnityEngine;
using System.Collections;


public class PlayMovie : MonoBehaviour {
	void Update () {
			Renderer r = GetComponent<Renderer>();
			MovieTexture movie = (MovieTexture)r.material.mainTexture;
			

			if (movie.isPlaying) {
				movie.Pause();
			}
			else {
				movie.Play();
			}
		}

}