using UnityEngine;
using System.Collections;

public class BasicEnemy : Enemy {

	public override void Start () {
		base.Start();
		PrimaryShoot = transform.Find ("SpawnLeft").transform;
		SecondaryShoot = transform.Find ("SpawnRight").transform;	
        InvokeRepeating("Shoot",Random.Range(2.0f,4.0f),Random.Range(2.0f,4.0f));
	}
	
	public override void Update () {
		base.Update ();
	}
}
