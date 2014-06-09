using UnityEngine;
using System.Collections;

public class StoneCollision : MonoBehaviour {


	public GameObject Fire;

	void Update()
	{

	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Laser") 
		{

			Instantiate(Fire,transform.position,transform.rotation);
			//Destroying Both Objects
			Destroy(col.gameObject);
			Destroy(gameObject);
			//Instantiate (smokePlayer,transform.position,transform.rotation);
			//game.Respawn();
		}
	}
}
