using UnityEngine;
using System.Collections;

public class GUIButtons : MonoBehaviour {

	public Texture2D play_Btn;
	public Texture2D settings_Btn;
	public Texture2D quit_Btn;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width / 2,225,play_Btn.width,play_Btn.height),play_Btn))
		{
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width /2,250,settings_Btn.width,settings_Btn.height),settings_Btn))
		{
			Application.LoadLevel(4);
		}
		if(GUI.Button(new Rect(Screen.width/2,300,quit_Btn.width,quit_Btn.height),quit_Btn))
		{
			Application.Quit();
		}
	}
}
