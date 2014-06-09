using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	#region variables

	public Texture backgroundTexture;
	public Texture playButton;
	public Texture optionButton;
	public Texture helpButton;
	public Texture quitButton;
	public GUIStyle noGUIStyle;	
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture,ScaleMode.ScaleAndCrop);
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,playButton.width,playButton.height),playButton,noGUIStyle))
		{

		}
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 70,optionButton.width,optionButton.height),optionButton,noGUIStyle))
		{

		}
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 120,helpButton.width,helpButton.height),optionButton,noGUIStyle))
		{
			
		}
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 150,quitButton.width,quitButton.height),quitButton,noGUIStyle))
		{
			
		}

	}
}
