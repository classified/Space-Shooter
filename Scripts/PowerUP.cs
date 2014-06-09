using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour
{

    public float PowerSpeed = -2f;
    FollowTouch power = new FollowTouch ();


    // Update is called once per frame
    void Update ()
    {
        transform.Translate (0f, 0f, PowerSpeed * Time.smoothDeltaTime);
        if (transform.position.z > 6.7) {
            Destroy (gameObject);
        }
	
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player1") {

            gameObject.audio.Play ();
            gameObject.audio.pitch = 3;
            Destroy (gameObject);
            power.PowerUpLaser ();

					
        }
		
    }
}
