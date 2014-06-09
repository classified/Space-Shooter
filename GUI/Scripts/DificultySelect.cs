using UnityEngine;

public class DificultySelect : BaseMenuState
{

	#region variables
    // for starting buttons positions
    public Vector2 offset;
		
    //our main gameobject
    public GameObject mainMenuGO;
		
    //the background texture
    public Texture backgroundTexture;
				
    public Texture2D GUI_Black ;
    //our gui skin!
		
    public GUIStyle introTextGS;

    //Strings
    public GameObject camera;
    public string diffSTR = "Select Difficulty";
    public string easySTR = "Easy";	
    public string mediumSTR = "Medium";
    public string hardSTR = "Hard";
    public string menuSTR = "Back";
    public string LevelToLoad;	
    [HideInInspector]
    public static bool
        easyLevel = false;	
    [HideInInspector]
    public static bool
        medLevel = false;
    [HideInInspector]
    public static bool
        HardLevel = false;
    //GUI scaling Elements
    [HideInInspector]
    public static bool
        done_player = false;
    [HideInInspector]
    public static bool
        player1 = false;

    public GUIStyle noGUIStyle;
    public Texture Done;
    public Texture player;
    private float orignalWidth;
    private float orignalHeight;
    private Vector3 scale;
  
    public Texture2D second;
			
		#endregion
		
		#region functions
		
		
    public void Start ()
    {
			
        easyLevel = false;
        medLevel = false;
        HardLevel = false;
        done_player = false;
        player1 = false;
        orignalWidth = Screen.width;
        orignalHeight = Screen.height;
        			
       

    }
    public void Update ()
    {
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
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
        if (backgroundTexture) {
            GUI.DrawTexture (GUIHelper.screenRect (0, 0, 1f, 1f), backgroundTexture, ScaleMode.StretchToFill);
        }	
			
        //draw the menu box
		
       
        GUI.Box (GUIHelper.screenRect (offsetX, offsetY, Screen.width, Screen.height), diffSTR);
			
        //GUI.Label(GUIHelper.screenRect (offsetX+.385f,offsetY+.775f,.55f,.1f),"HighScore : " + showHighScore.ToString(),introTextGS);
			
        //draw the button
        if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .275f, .35f, .1f), easySTR)) {
            easyLevel = true;
            //Application.LoadLevel (LevelToLoad);
            AutoFade.LoadLevel (LevelToLoad, 2, 1, Color.black);
        }
			
			
        //draw the option button
        if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .4f, .35f, .1f), mediumSTR)) {
            medLevel = true;
            //Application.LoadLevel (LevelToLoad);
            AutoFade.LoadLevel (LevelToLoad, 2, 1, Color.black);
        }
			
        //draw the credits  button
        if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .525f, .35f, .1f), hardSTR)) {
            HardLevel = true;
            //Application.LoadLevel (LevelToLoad);
            AutoFade.LoadLevel (LevelToLoad, 2, 1, Color.black);
        }				
			
			
        if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + 0.65f, .35f, .1f), menuSTR)) {
            swapObjects (mainMenuGO);
        }		
			
        if (GUI.Button (new Rect (0, Screen.height / 2 - 50, Done.width, Done.height), Done, noGUIStyle)) {
            Debug.Log ("done chossen");
            done_player = true;
				
					
        }
        if (GUI.Button (new Rect (0, Screen.height / 2 + 50, Done.width, Done.height), player, noGUIStyle)) {
            Debug.Log ("player chossen");
            player1 = true;
        }
       
        GUI.matrix = svMat;

    }	
		#endregion

		
}


