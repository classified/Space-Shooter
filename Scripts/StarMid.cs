using UnityEngine;
using System.Collections;

public class StarMid : MonoBehaviour {

	private float scrollSpeed=-0.15f;
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTextureOffset("_MainTex" , new Vector2(1,Time.time * scrollSpeed));
	}
}
