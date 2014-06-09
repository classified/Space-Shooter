using UnityEngine;
using System.Collections;

public class PointsMovement : MonoBehaviour {

	[HideInInspector]
	public float speed=0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0f,speed * Time.smoothDeltaTime,0f);

	}
}
