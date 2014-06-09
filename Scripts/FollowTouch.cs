using UnityEngine;
using System.Collections;

public class FollowTouch : MonoBehaviour
{
    private float speed = 4f;
    private Vector3 finger;
    //  private Transform myTrans, myCamera;
    public GameObject Player;
    public GameObject Laser;
    private float fireFreq;
    private float lastShot;

    public GameObject LiveSound;
    //Boolean var for lasers

    public static bool LaserPrefeb = false;
    public GameObject LaserNew;

    //laser type define

    public  static int LaserType = 0;
    public  static float LaserTimer;

    public static int CurrTouch = 0;

    //Movement
    public float Tilt = 5f;

    // Private Members
    public static int spawn = 1;
   
    void Update ()
    {
        if (DificultySelect.easyLevel) {
            fireFreq = 0.3f;
        }
        if (DificultySelect.medLevel) {
            fireFreq = 0.3f;		
        }
        if (DificultySelect.HardLevel) {
            fireFreq = 0.5f;
        }

        /* //THE GOLDEN TOUCH
        if (Input.touches [0].phase == TouchPhase.Moved) {

            var y = Input.touches [0].deltaPosition.y * Time.smoothDeltaTime * speed; //removed deltapostion on x and y + time.time instead of time.smoothdeltatime
            var x = Input.touches [0].deltaPosition.x * Time.smoothDeltaTime * speed;

            myTrans.Translate (new Vector3 (x, 0, y), Space.Self);

            if (Time.time > fireFreq + lastShot) {
                Fire ();
            }


        }
        if (Input.touches [0].phase == TouchPhase.Stationary) {
						
            //myTrans.position = new Vector3(Mathf.Clamp(Time.time,-3.9f,3.9f),0f,Mathf.Clamp(Time.time,-4.0f,6.05f));
            if (Time.time > fireFreq + lastShot) {
                Fire ();
            }
			
        }*/

        if (Input.touchCount > 0) {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch (0);
            
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10)); //10         
                transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime * speed);

                if (Time.time > fireFreq + lastShot) {
                    Fire ();
                }
                		
            }
        } 
       
        LaserTimer -= 1 * Time.deltaTime;
        if (LaserTimer < 0) {
            LaserType = 0;
			
        } 
            
            

    }


    void Fire ()
    {
        this.lastShot = Time.time;
        Debug.Log ("Shots are gonna choose");
        if (LaserType == 0) {
            Instantiate (Laser, transform.position, transform.rotation);
			
        } else if (LaserType == 1) {
            if (LaserPrefeb) {
                Debug.Log ("From 1");
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -20f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -15f, 0f)));
                Instantiate (LaserNew, transform.position, transform.rotation);
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +15f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +20f, 0f)));
            }
			
        } else if (LaserType == 2) {
            Debug.Log ("From 2");
            GameController.PlayerLive += 1;
            Instantiate (LiveSound, transform.position, transform.rotation);
            LaserType = 0;
        } else if (LaserType == 3) {
            Debug.Log ("From 3");
            HealthBar.playerHealth = 100;
            LaserType = 0;
        } else if (LaserType == 4) {
            Debug.Log ("From 4");
            GameController.score += 1000;
            LaserType = 0;
        } else if (LaserType == 5) {
            if (LaserPrefeb) {
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -20f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -15f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -10f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, -5f, 0f)));
                Instantiate (LaserNew, transform.position, transform.rotation);
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +5f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +10f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +15f, 0f)));
                Instantiate (LaserNew, transform.position, Quaternion.Euler (new Vector3 (0f, +20f, 0f)));
				
            }
        }



    }

    public void PowerUpLaser ()
    {
        //laserType +=1;
        spawn = 0;
        LaserType = Random.Range (1, 5);
        Debug.Log ("laser type = " + LaserType);
        LaserTimer = 3; // counting seconds for powerup time
        Debug.Log (LaserType + "After if");
        LaserType = Mathf.Clamp (LaserType, 0, 5); // clamping value*/
        Debug.Log (LaserType + "After CLAMPING");
        LaserPrefeb = true;


    }
}
