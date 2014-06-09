using UnityEngine;
using System.Collections;

public class BoltCollision : MonoBehaviour {

	public GameObject partical;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy" ) 
		{
			
			GameController.score += 10; 
			//Destroying Both Objects
			Instantiate (partical,transform.position,transform.rotation);
			Destroy(col.gameObject);
			Destroy(gameObject);

			//game.Respawn();
		}
		if(col.gameObject.tag == "EnemyLaser")
		{
			Destroy(col.gameObject);
			Destroy(gameObject);

		}
		if(col.gameObject.tag =="Stone1")
		{
			Instantiate (partical,transform.position,transform.rotation);
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
