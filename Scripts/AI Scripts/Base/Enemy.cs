using UnityEngine;
using System.Collections;

public class Enemy:MonoBehaviour
{

    protected Vector3 Velocity;	
    public Transform Transform;	

    public GameObject Proj;
    protected Transform PrimaryShoot = null;
    protected Transform SecondaryShoot = null;
    bool side = true; 
    protected int Health;

    public virtual void Start ()
    {
        Velocity = new Vector3 (0, 0, Random.Range (0.5f, 1.5f));
        Transform = GetComponent<Transform> ();
        //InvokeRepeating("ChangeZ",2.0f,1.0f);
    }
    public virtual void Update ()
    {
        /* _transform.Translate( -velocity.x*Time.deltaTime,
         	0,velocity.z*Time.deltaTime,Space.World); */
        //-velocity.x * Time.deltaTime = X VALUE
        Transform.Translate (0, 0, -Velocity.z * Time.deltaTime, Space.World);
        //  transform.Translate (0f, 0f, 3 * Time.smoothDeltaTime);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player1") {
            Destroy (gameObject);
        }
        if (other.gameObject.tag == "Laser") {
            Destroy (gameObject);
            Destroy (other.gameObject);
        }
    }
    protected void Shoot ()
    {
        if (PrimaryShoot) {
            if (SecondaryShoot) {
                if (side)
                    Instantiate (Proj, PrimaryShoot.position, Quaternion.identity);
                else
                    Instantiate (Proj, SecondaryShoot.position, Quaternion.identity);
                side = !side;
            } else
                Instantiate (Proj, PrimaryShoot.position, Quaternion.identity);
        }
    }
    public virtual void  OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Laser") {
            Destroy (other.gameObject);
            Destroy (gameObject);
            //print ("Base");
        } else if (other.gameObject.tag == "Player1")
            Destroy (gameObject);
    }
    void ChangeZ ()
    {
        Velocity.z = Random.Range (-1.0f, 1.0f);
    }
}
	


