using UnityEngine;
using System.Collections;



public class GameController : MonoBehaviour
{

	#region Declared
    //Declaring Player Live
		
    public static int PlayerLive = 3;
    public GameObject PlayerPrefeb;
    public object respawns;
    public static bool isDead = false ;
    public static bool gameOver = false;
    public static int score = 100 ;
    public GameObject AlertBoxPrefeb;
    //HighScore Elements
    public GameObject pauseButton;
    public Texture2D HighScoreTexture;

    //Enemy control
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public GameObject[] enemy1;
    private int hazardCount;
    public Vector3 spawnValues;


    //PowerUp Control
    public float powerWait;
    public float powerSpawnWait;
    public float powerWaveWait;
    public GameObject powerUP;
    public int powerUPCount;
    public Vector3 powerSpawn;

    //GUI Controls
    private bool finishedLevel = false;
    //public Vector2 startLocation;
    //public Rect windowRect = new Rect(Screen.width /2 - 200,Screen.height/2 - 250,400,400);
    public GUISkin skins;
    public Texture box;
    public static int killCounter = 0;
    public GameObject HighScore;
    //public GameObject hName;
    public GUIStyle noGUIStyle;

    //Drawing Life
    public Texture2D[] lives;

    private GPGService publicService = new GPGService ();

    [HideInInspector]
    public float
        deathTimer = 0f;
    public float spawnDelay = 5f;
    public static int playerHealthCheck;
    private int scrChecker = 0;

    //GUI scaling Elements
    public GameObject[] player;	
    private float orignalWidth;
    private float orignalHeight;
    private Vector3 scale;
    private string playerChosen = "Player1";
    private static int playerSpawnCount = 0;
    private GameObject[] obj;
    private int high = 0;
		
		#endregion

		#region Functions
    void Start ()
    {
        EventTalk.EventTrigger.askToSaveScore = false;
        BridgeJTOC.Bridge.ObjectState = false;
        score = 0;
        PlayerLive = 3;
        finishedLevel = false;
        playerSpawnCount = 0;
        StartCoroutine (SpawnWaves ());
        StartCoroutine (SpawnPowers ());

        NotificationCenter.DefaultCenter ().PostNotification (this, "Save");
        orignalWidth = Screen.width;
        orignalHeight = Screen.height;

        high = PreviewLabs.PlayerPrefs.GetInt ("0Score");
        if (high == 0) {
            try {
                high = PreviewLabs.PlayerPrefs.GetInt ("1Score");
            } catch (PlayerPrefsException ex) {
                Debug.Log (ex.ToString ());
            }
        }
        publicService.SubmitScoreToLeaderBoards ();

        // fbCheck ();
   

       
    }
    void LogCallback (FBResult response)
    {
        Debug.Log (response.Text);
    }
    void fbCheck ()
    {
        Time.timeScale = 0;
        FB.AppRequest (
            message: "Come play this great game!", 
            callback: LogCallback
        );
    }
    void fbFeed ()
    {
    
        FB.Feed (
            link: "https://example.com/myapp/?storyID=thelarch",
            linkName: "The Larch",
            linkCaption: "I thought up a witty tagline about larches",
            linkDescription: "There are a lot of larch trees around here, aren't there?",
            picture: "https://example.com/myapp/assets/1/larch.jpg",
            callback: LogCallback
        );
    }
    void playerSpawn ()
    {
        if (playerSpawnCount == 0) {	
            Debug.Log ("PlayerName :" + playerChosen);
            GameObject varObj;
            varObj = Instantiate (Resources.Load (playerChosen, typeof(GameObject)), (new Vector3 (0.25f, 0.3f, -2.50f)), Quaternion.identity)as GameObject;
            varObj.name = " Player ";
            playerSpawnCount = 1;
                        
        }
			
    }
				
    // Update is called once per frame
    void Update ()
    {

        if (DificultySelect.done_player) {
            Debug.Log ("done_player true");
            playerChosen = "Done_Player";
            playerSpawn ();
        }
        if (DificultySelect.player1) {
            Debug.Log ("player true");
            playerChosen = "Player1";
            playerSpawn ();
        }
        if (DificultySelect.easyLevel == true) {
            hazardCount = 100;
        }
        if (DificultySelect.medLevel == true) {
            hazardCount = 150;			
        }
        if (DificultySelect.HardLevel == true) {
            hazardCount = 200;
        }
        obj = GameObject.FindGameObjectsWithTag ("Player1");
        if (obj.Length == 0) {
            Debug.Log ("Player not found. Creating player");
            playerSpawn ();
        }
        if (respawns == null) {
            respawns = GameObject.FindWithTag ("Player1");
        }

			
        if (isDead == true) {
            deathTimer += 1 * Time.deltaTime; //start death timer.
            Debug.Log ("timer started");
            Debug.Log ("timer going on + " + deathTimer.ToString ());
        }
        if (isDead == true && deathTimer > spawnDelay) {
            Debug.Log ("respawing");
            Respawn (); 
				
        }

        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;

			

    }
	#region Spawning Actors
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        Debug.Log ("Entered in spawn waves");
        while (true) {
            for (int i=0; i < hazardCount; i++) {
                Debug.Log ("in for loop");
                GameObject hazard = enemy1 [Random.Range (0, enemy1.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); 
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);

            }
            yield return new WaitForSeconds (waveWait);

        }
    }
    IEnumerator SpawnPowers ()
    {
        yield return new WaitForSeconds (powerWait);
        Debug.Log ("Entered in spawn waves");
        while (true) {
            for (int i=0; i < powerUPCount; i++) {
                Debug.Log ("in for loop");
                GameObject pow = powerUP;
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); 
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (pow, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (powerSpawnWait);
					
            }
            yield return new WaitForSeconds (powerWaveWait);
				
        }
    }

	#endregion
    public void Respawn ()
    {

        if (PlayerLive > 0) {
            GameObject varObj = new GameObject ();
            varObj = Instantiate (Resources.Load (playerChosen, typeof(GameObject)), (new Vector3 (0.25f, 0.13f, -2.50f)), Quaternion.identity)as GameObject;
            Debug.Log ("Player Respawn Success!" + varObj.ToString ());
            deathTimer = 0; //reset death timer after spawning.
            isDead = false;
            HealthBar.playerHealth = 100;
            Handheld.Vibrate ();
            Debug.Log ("var set to zero");
        } else {
            gameOver = true;

            Debug.Log ("Player Respawn Failed!");
        }
    }
	#region OnGUI
    void OnGUI ()
    {
			
        GUI.skin = skins;
        //Scaling GUI MATRIX FOR ALL RESOLUTION
        scale.x = Screen.width / 320.0f;
        scale.z = Screen.height / 480.0f;
        scale.y = 1f;
        var svMat = GUI.matrix;
        Debug.Log (Screen.width.ToString ());
        Debug.Log (Screen.height.ToString ());
        Debug.Log (scale.x.ToString ());
        Debug.Log (scale.z.ToString ());
        GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

        GUI.Box (new Rect (0, Screen.height - 70, Screen.width, 70), "", noGUIStyle);
        GUI.Label (new Rect (5, Screen.height - 60, 400, 100), " Score  " + score.ToString ());
        GUI.Label (new Rect (5, Screen.height - 40, 400, 100), " HighScore   " + high);
        GUI.Box (new Rect (170, Screen.height - 70, Screen.width, 70), "", noGUIStyle);
        GUI.Label (new Rect (180, Screen.height - 60, 100, 100), " Lives  x" + " " + PlayerLive);
        //GUI.DrawTexture(new Rect(270,Screen.height - 60,50,25),lives[PlayerLive]);

			
        if (finishedLevel) {
            if (scrChecker >= 1) {
                finishedLevel = false;
            } else {
                finishedLevel = false;
                Time.timeScale = 0;
                //BridgeJTOC.Bridge.setScore(score);
                //BridgeJTOC.Bridge.setKill(killCounter);
                Instantiate (HighScore, transform.position, transform.rotation);
                Destroy (pauseButton);
                scrChecker++;		
                LaserMove.Save ();

            }	
        }
        if (gameOver == true) {
            LaserMove.Save ();
            AutoFade.LoadLevel ("GameOver", 1, 1, Color.red);
            fbFeed ();
        }
        if (Application.platform == RuntimePlatform.Android) {
				
            if (Input.GetKeyUp (KeyCode.Escape)) {
					
                publicService.SubmitScoreToLeaderBoards ();
                fbCheck ();
                // FB.Logout ();
                LaserMove.Save ();	
               

                Instantiate (AlertBoxPrefeb, transform.position, transform.rotation);
                //return;
				
            }


        }
        GUI.matrix = svMat;


    }
		#endregion

		#endregion

}

