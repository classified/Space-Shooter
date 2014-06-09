using UnityEngine;

public class CloneFire : MonoBehaviour
{

    public GameObject Laser;

    private float fireFreq;
    private float lastShot;

	
    // Update is called once per frame
    void Update ()
    {
        
        if (Time.time > fireFreq + lastShot) {
            Fire ();
        }

    }
    void Fire ()
    {
        this.lastShot = Time.time;
        Instantiate (Laser, transform.position, transform.rotation);
    }
}
