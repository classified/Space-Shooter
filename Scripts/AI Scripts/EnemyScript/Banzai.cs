using UnityEngine;
using System.Collections;

public class Banzai : Enemy {

	Transform _target;
	public override void Start () {
		base.Start ();
		PrimaryShoot = transform.Find ("SpawnLeft").GetComponent<Transform>();
		SecondaryShoot = transform.Find ("SpawnRight").GetComponent<Transform>();
		_target = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
		InvokeRepeating("Shoot",0.01f,Random.Range(2.0f,4.0f));
	}
	
	public override void Update () {
		if(Transform.position.x > _target.position.x)
			Transform.Target(_target);
		else 
			base.Update();
	}
}
