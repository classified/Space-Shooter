using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public GUISkin gui;
	// Use this for initialization
	private Transform myTrans;
	public Texture myTex;
	void Start () {
		myTrans = Camera.main.transform;
		myTex = guiTexture.texture;
		myTex.height = Screen.height;
		myTex.width  = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches[0].phase == TouchPhase.Moved)
		{
			
			var y = Input.touches[0].deltaPosition.y * Time.smoothDeltaTime; //removed deltapostion on x and y + time.time instead of time.smoothdeltatime
			var x = Input.touches[0].deltaPosition.x * Time.smoothDeltaTime;
			
			//myTrans.Translate( new Vector3(x  , 0 , y),Space.World);
			myTrans.Translate( new Vector3(x  , 0 , y),Space.World);
			

			
		}
	
	}
	void OnGUI ()
	{
		GUI.skin = gui;
		if (GUI.Button(new Rect(100,100,100,35),"Level 1"))
		{
			Application.LoadLevel(3);
		}
		if (GUI.Button(new Rect(100,200,100,35),"Level 2"))
		{
			Application.LoadLevel(6);
		}
	}
}
