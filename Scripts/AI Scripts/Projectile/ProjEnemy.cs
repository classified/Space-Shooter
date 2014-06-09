using UnityEngine;
using System.Collections;

public class ProjEnemy : MonoBehaviour {
	/*
	 * Cache the transform for optimization
	 * */
	Transform _transform;
	float speed = -3;
	void Start () {
		_transform = GetComponent<Transform>();
	}
	
	/*
	 * Move the projectile
	 * */
	void Update () {
		_transform.Translate ( speed*Time.deltaTime,0,0,Space.World);
	}
	
	/*
	 * Detect collision with the player ship. Send a message to the ship with 10 damage
	 * */
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ship"){
			other.gameObject.GetComponent<ShipControl>().DecreaseHealth(10);
			Destroy(gameObject);
		}else if(other.gameObject.tag == "Rocks") Destroy(gameObject);
	}
	/*
	 * Detect collision with the outer boundary and destroy the projectile.
	 * */
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "EnemyDeath")Destroy(gameObject);
	}
}
