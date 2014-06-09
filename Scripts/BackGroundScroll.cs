using UnityEngine;
using System.Collections;

public class BackGroundScroll : MonoBehaviour {

	private float scrollSpeed=-0.05f;
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTextureOffset("_MainTex" , new Vector2(1,Time.time * scrollSpeed));


	}
}
