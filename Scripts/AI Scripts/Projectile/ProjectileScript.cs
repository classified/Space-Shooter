using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	
	/*
	 * Cache of the transform for optimization
	 * */
	Transform _transform;
	float speed = 3;
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
	 * Detect collision with the outer boundary and destroy the projectile
	 */
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "ProjectileDeath")Destroy(gameObject);
	}
		void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Rocks")Destroy(gameObject);
	}
}
