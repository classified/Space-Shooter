using UnityEngine;
using System.Collections;

public class CircleMove : Enemy
{

    public float phase;
    //float phaseA;

    public override void Start ()
    {
        base.Start ();
        //   _primaryShoot = transform.Find ("SpawnLeft").transform;
        //   _secondaryShoot = transform.Find ("SpawnRight").transform;	
        //phaseA =phase +30f;
        InvokeRepeating ("Shoot", Random.Range (2.0f, 4.0f), Random.Range (2.0f, 4.0f));
    }
	
    public override void Update ()
    {
        /*transform.localPosition= new Vector3((Mathf.Cos (Time.time)+2)*Mathf.Cos (Time.time + phase),0,
			(Mathf.Cos (Time.time)+2)*Mathf.Sin (Time.time+phaseA));*/
        //2 * Mathf.Cos (Time.time + phase) = X VALUE
        transform.localPosition = new Vector3 (2 * Mathf.Cos (Time.time + phase), 0,
			2 * Mathf.Sin (Time.time + phase));
    }
}
