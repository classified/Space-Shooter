//#define GOT_PRIME31_GAMECENTER

using UnityEngine;
using Facebook;
using System.Collections;
using Soomla;

public class MainMenu : BaseMenuState
{
	#region variables

	//the background texture
	public GameObject AlertBoxPrefeb;
	public Texture backTexture;
	
	//the options menu gameObject
	public GameObject optionsGO;
	
	//the credit menu gameObject
	public GameObject creditsGO;
	
	//the level select gameObject
	public GameObject levelSelectGO;

	//the Difficulty GameObject
	public GameObject difSelectGO;
	public Texture FacebookLogin;
	// public GameObject StoreGUI;
	//do  you want to use the quit button.
	public bool useQuitButton = false;
	
	//do  you want to use the highscore button.
	public bool useHighscoreButton = false;
	
	public Texture LeaderBoard;
	public string menuMenuSTR = "Main Menu";
	public string startButtonSTR = "Start";
	
	public string optionsSTR = "Options";
	public string creditsSTR = "Credits";
	public string quitSTR = "Quit";
	public string highscoreSTR = "Help";
	public GUIStyle introTextGS;
	int showHighScore;
	public GUIStyle noGUIStyle;
	bool isEnabled;
    
	bool isLogged;
	Texture pic;
	string userId;
	public Texture StoreLogin;
	//GUI scaling Elements

	//private float orignalWidth;
	//private float orignalHeight;
	private Vector3 scale;
	private static bool isUserLoggedIn = false;
	private string url = "www.google.com";
	// private GPGService  publicService = new GPGService ();

	#endregion

	private void SetInit ()
	{
		enabled = true; 
		// "enabled" is a magic global; this lets us wait for FB before we start rendering
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// start the game back up - we're getting focus again
			Time.timeScale = 1;
		}
	}

	void Start ()
	{

		FB.Init (SetInit, OnHideUnity);
		//lets show the cursor and unlock it (incase it was).
		Screen.lockCursor = false;
		Screen.showCursor = true;
		Time.timeScale = 1;
       
		m_on = true;
		Debug.Log (Application.persistentDataPath + "/PlayerPrefs.txt");
		//showHighScore = PreviewLabs.PlayerPrefs.GetInt("Highscore");
		//orignalWidth = Screen.width;
		//orignalHeight = Screen.height;
		// Saving Score if user goes into main menu while playing game.
		Debug.Log ("check from main menu to asking to save score " + EventTalk.EventTrigger.askToSaveScore);
		if (EventTalk.EventTrigger.askToSaveScore == true) {
			//  publicService.SubmitScoreToLeaderBoards ();
			LaserMove.Save ();
		}


	}

  
	void LoginCallBack (FBResult result)
	{
        
		if (result.Error != null) {
            
			Debug.Log ("Receive callback login error :: " + result.Error.ToString ());
			isLogged = true;
            
		} else {
            
			if (FB.IsLoggedIn) {
                
				// Case login was successful 
                
				isLogged = true;
                
				userId = FB.UserId;
                
                
                
			} else {
                
				// Case login failed (because of cancelling for example)
                
				isLogged = false;
                
			}
            
		}
        
	}
	//deactivate this object and active the incoming one.
	void changeGameObject (GameObject go)
	{
		go.active = true;
		gameObject.active = false;
	}

	void GetProfilePicAnswer (FBResult response)
	{
        
		// This method method will be called withing the callback received by FB.API()
        
		// You can add a control here for any kind of failure to print up a default picture for example
        
		if (response.Texture != null) {
            
			pic = response.Texture;
            
		}
        
	}

	void LogCallback (FBResult response)
	{
		Debug.Log (response.Text);
	}

	public override void onGUI ()
	{
		float offsetX = transform.position.x + MenuConstants.OFFSET_X;
		float offsetY = transform.position.y + MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;

		//Scaling GUI MATRIX FOR ALL RESOLUTION
		scale.x = Screen.width / Screen.width;
		scale.y = Screen.height / Screen.height;
		scale.z = 1f;
		var svMat = GUI.matrix;

		Debug.Log (scale.x.ToString ());
		Debug.Log (scale.y.ToString ());
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

		//draw out background texture
		if (backTexture) {
			GUI.DrawTexture (GUIHelper.screenRect (0, 0, 1f, 1f), backTexture, ScaleMode.StretchToFill);
		}	

		//draw the menu box

		GUI.Box (GUIHelper.screenRect (offsetX, offsetY, Screen.width, Screen.height), menuMenuSTR);

		if (GUI.Button (new Rect (0, Screen.height / 2, 100, 50), StoreLogin, noGUIStyle)) {
			Application.LoadLevel ("Store");


		}
		//GUI.Label(GUIHelper.screenRect (offsetX+.385f,offsetY+.775f,.55f,.1f),"HighScore : " + showHighScore.ToString(),introTextGS);
		if (GUI.Button (new Rect (60, 0, FacebookLogin.width / 2, 50), FacebookLogin, noGUIStyle)) {
			FB.Login ("email,publish_actions,user_games_activity,friends_games_activity", LoginCallBack);
			//FB.API ("/me/picture", HttpMethod.GET, GetProfilePicAnswer);
		}
		if (GUI.Button (new Rect (0, 0, LeaderBoard.width, 50), LeaderBoard, noGUIStyle)) {
			Debug.Log ("Calling Leaderboards");
//            publicService.LeaderBoardShow ();
		}

		//draw the button
		if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .275f, .35f, .1f), startButtonSTR)) {
           

			swapObjects (difSelectGO);



		}

		
		//draw the option button
		if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .4f, .35f, .1f), optionsSTR)) {
			swapObjects (optionsGO);
		}

		//draw the credits  button
		if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .525f, .35f, .1f), creditsSTR)) {
			swapObjects (creditsGO);
		}				
	
		if (useHighscoreButton) {
			if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + 0.65f, .35f, .1f), highscoreSTR)) {

				Application.LoadLevel ("HighScore");

			}		
		}
		
		//draw the quit button
		if (useQuitButton) {
			if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .775f, .35f, .1f), quitSTR)) {
			
				Application.Quit (); 
								
				
			}				
		}
		GUI.matrix = svMat;
	}

	void Update ()
	{
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
             
       
		if (Input.GetKeyDown (KeyCode.Escape)) {

			FB.Logout ();
			Instantiate (AlertBoxPrefeb, transform.position, transform.rotation);
		}


	}

	

}