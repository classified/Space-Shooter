using UnityEngine;
using System.Collections;
using PreviewLabs;
using BridgeJTOC;



public class LaserMove : MonoBehaviour
{

    public float laserSpeed = 4f;
    public GameObject enemy1;
    public Transform particals;
    public Transform smoke;
    public static int points = 10;
    public GameObject pointsGUI;
    public GameObject explosion;
    public GameObject Stone_Explosion;

    [HideInInspector]
    public static int
        EnemyHealth = 100;
    public int playerHit = -30;
    public static int newScore = 0;
    public static int oldScore = 0;


    // Update is called once per frame
    void Update ()
    {
	
        transform.Translate (0f, 0f, laserSpeed * Time.smoothDeltaTime);
        if (transform.position.z > 6.7) {
            Destroy (gameObject);
        }

        NotificationCenter.DefaultCenter ().AddObserver (this, "Save");

    }
    public static void Save ()
    {
        Debug.Log ("Saving.....");
        SqliteDatabase sqlDB = new SqliteDatabase ("table.db");
        string query = "INSERT INTO user VALUES('Santigo')";
        sqlDB.ExecuteNonQuery (query);
        newScore = GameController.score;
        for (int i=0; i<100; i++) {
            if (PreviewLabs.PlayerPrefs.HasKey (i + "Score")) {
                if (PreviewLabs.PlayerPrefs.GetInt (i + "Score") < newScore) {
                    //new score is higher than stored score
                    oldScore = PreviewLabs.PlayerPrefs.GetInt (i + "Score");
                    PreviewLabs.PlayerPrefs.SetInt (i + "Score", newScore);
                    PreviewLabs.PlayerPrefs.SetInt (i + "Kills", GameController.killCounter);
                    newScore = oldScore;
                    PreviewLabs.PlayerPrefs.Flush ();
                }
            } else {
                PreviewLabs.PlayerPrefs.SetInt (i + "Score", newScore);
                PreviewLabs.PlayerPrefs.SetInt (i + "Kills", GameController.killCounter);
                newScore = 0;
                PreviewLabs.PlayerPrefs.Flush ();
            }
        }
        /*Debug.Log("From save");
		PreviewLabs.PlayerPrefs.SetInt(i + "Score",GameController.score);
		PreviewLabs.PlayerPrefs.SetInt ("kills",GameController.killCounter);
		if(GameController.score > GameController.newHighScore){

		}
		PreviewLabs.PlayerPrefs.Flush();*/

    }
    void OnTriggerEnter (Collider col)
    {

        if (col.gameObject.tag == "Enemy") {

		
            Vector3 viewportPOS = Camera.main.WorldToViewportPoint (transform.position);

            //Destroying Both Objects
            EnemyHealth += playerHit;
            Destroy (gameObject);
            Destroy (col.gameObject);
            Instantiate (explosion, transform.position, transform.rotation);
            Instantiate (pointsGUI, new Vector3 (viewportPOS.x, viewportPOS.y, 0f), transform.rotation);
            GameController.score += points;
            GameController.killCounter += 1;
            col.gameObject.audio.Play ();


        }
        if (col.gameObject.tag == "Stone1") {

            col.gameObject.audio.Play ();
            Instantiate (Stone_Explosion, transform.position, transform.rotation);

            //Destroying Both Objects
            Destroy (col.gameObject);
            Destroy (gameObject);

			
        }
        if (col.gameObject.tag == "EnemyLaser") {
            col.gameObject.audio.Play ();
            Instantiate (Stone_Explosion, transform.position, transform.rotation);
            //Destroying Both Objects
            Destroy (col.gameObject);
            Destroy (gameObject);
        }
		
    }


}
