using UnityEngine;
using System.Collections;

public class ShipOsc : Enemy {

	float amplitude = 2;
 	float omega = 2f;
	float index;
	
	public override void Start(){
		base.Start ();
		Transform.position = new Vector3(22f,0f,-5f);	
		PrimaryShoot = transform.Find ("SpawnLeft").transform;
		SecondaryShoot = transform.Find ("SpawnRight").transform;
		Velocity.x = 1;
        InvokeRepeating("Shoot",Random.Range(2.0f,4.0f),Random.Range(2.0f,4.0f));
	}

	public override void Update(){
		index += Time.deltaTime;
		float zPos=amplitude*(Mathf.Cos(omega*index))*Time.deltaTime;
		Transform.Translate ( -Velocity.x*Time.deltaTime,0,zPos,Space.World);
	}
}
