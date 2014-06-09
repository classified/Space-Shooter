using UnityEngine;
using System.Collections;

public class HighBTN : MonoBehaviour {


	public Texture backgroundTexture;
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture,ScaleMode.StretchToFill);
	}
}
