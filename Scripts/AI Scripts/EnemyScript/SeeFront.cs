using UnityEngine;
using System.Collections;

public class SeeFront : Enemy {
	
	float angle =45;
	public override void Start () {
		base.Start ();
	}
	
	public override void Update () {
		base.Update ();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "EnemyShip"){
			if(Vector3.Angle(other.gameObject.transform.position - Transform.position, transform.forward) <= angle){
				SeeFront sc = other.GetComponent<SeeFront>();
				Velocity = sc.Velocity;
			}
		}else if(other.gameObject.tag == "EnemyDeath")Destroy(gameObject);
	}
}
