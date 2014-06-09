using UnityEngine;
using System.Collections;

public class MainMenuControl : MonoBehaviour {


	private string clicked = "";
	public Texture background;
	public GUISkin myskin;
	private string messageToDisplayOnClick="You are in option";
	public GameObject fireWorks;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		
		Instantiate(fireWorks,new Vector3(3f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(5f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(6f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(8f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(9f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(10f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(3f,4f,5f),Quaternion.identity);
		Instantiate(fireWorks,new Vector3(2f,4f,5f),Quaternion.identity);

	}
	void LateUpdate()
	{
	}
	
	private void OnGUI()
	{
		//background
		if (background != null)
			GUI.DrawTexture (new Rect(0,0,Screen.width , Screen.height),background);
		
		if (clicked == "" || clicked == "Options")
		{
			/*//Logo
			if (LOGO !=null)
				GUI.DrawTexture (new Rect((Screen.width/2)-509,30,200,200), LOGO);
			//original: GUI.DrawTexture (new Rect((Screen.width/2)-509,30,200,200), LOGO);*/
		}
		if (clicked == "")
		{
			
			GUI.skin = myskin;


			GUI.Label(new Rect((Screen.width/2)-210,(Screen.height/2)-210,440,128),"");
			//Buttons
			// original is: if (GUI.Button (new Rect((Screen.width/2) - 100,Screen.height/2,200,30) , "Play Game"))
			if (GUI.Button (new Rect((Screen.width/2) -80 ,(Screen.height/2) - 20,200,30) , "Play Game"))
			{
				Application.LoadLevel(1);
				//code on what to do after clicked play
			}
			if (GUI.Button (new Rect((Screen.width / 2)-80,( Screen.height / 2 ) + 20, 200,30), "Options"))
			{
				//code on what to do when options are clicked
				clicked = "Options";
			}
			if (GUI.Button (new Rect((Screen.width / 2)-80, (Screen.height / 2)+ 60,200,30) , "Credits"))
			{
				//Code on what to do when Credits is clicked
				clicked = "Credits";
			}
			if (GUI.Button (new Rect((Screen.width / 2)-80, (Screen.height / 2)+ 100, 200, 30), "Quit Game"))
			{
				Application.Quit();
			}
		}
		else if (clicked == "Options")
		{
			GUI.Window (0, new Rect((Screen.width / 2), Screen.height / 2, 200, 50)  , optionsFunc , "Options");
		}
		else
		{
			GUI.Box (new Rect (0,0,Screen.width,Screen.height) , messageToDisplayOnClick);
		}
	}
	
	private void optionsFunc(int id)
	{
		GUILayout.Box ("Volume");
		
		if (GUILayout.Button ("Back"))
		{
			clicked = "";
		}
		
	}
	

}
