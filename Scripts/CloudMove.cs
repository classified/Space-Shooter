using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(0f,0f, Time.smoothDeltaTime * speed);
	}
}
