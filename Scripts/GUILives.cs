using UnityEngine;
using System.Collections;

public class GUILives : MonoBehaviour {

	public Texture2D[] liveTexture;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		guiTexture.texture = liveTexture[GameController.PlayerLive];

	}
}
