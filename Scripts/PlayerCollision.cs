using UnityEngine;
using System.Collections;


public class PlayerCollision : MonoBehaviour {

	public GameObject Fire;
	public float invisPlayer ;
	private float spawnTimer;





	void Awake()
	{
		spawnTimer = Time.time;
	}

	//Enemy Laser Colliding with player Trigger
	void OnTriggerEnter(Collider col)
	{
		if( col.gameObject.tag == "EnemyLaser" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Stone1"   &&	(Time.time > spawnTimer + invisPlayer) )
		{
			//life of player is gone


			//Destroying Both Objects
			Destroy(col.gameObject);
			//Destroy(gameObject);
			HealthBar.playerHealth += HealthBar.enemyHit;
			Handheld.Vibrate();
			if(HealthBar.playerHealth <=0 )
			{
				GameController.PlayerLive -=1;
				GameController.isDead = true ;
				Instantiate(Fire,transform.position,transform.rotation);
				Destroy(gameObject);
				Handheld.Vibrate();
			}

		}
		/*if(col.gameObject.tag == "Left")
		{
			transform.position = new Vector3(Mathf.Clamp(Time.time,-3.9f,-3.9f),0f,0f);

		}
		if(col.gameObject.tag == "Bottom")
		{

			transform.position = new Vector3(0f,0f,Mathf.Clamp(Time.time,-4.0f,-4.0f));
		}
		if(col.gameObject.tag == "Right")
		{
			transform.position = new Vector3(Mathf.Clamp(Time.time,3.9f,3.9f),0f,0f);
			
		}
		if(col.gameObject.tag == "Top")
		{
			
			transform.position = new Vector3(0f,0f,Mathf.Clamp(Time.time,6.05f,6.05f));
		}*/
		
	}
}
