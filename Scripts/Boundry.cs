using UnityEngine;
using System.Collections;

public class Boundry : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag =="Laser" || col.gameObject.tag=="Enemy" || col.gameObject.tag=="Stone1" || col.gameObject.tag=="Bolt" || col.gameObject.tag == "EnemyLaser" || col.gameObject.tag =="Power")
		{
			Debug.Log("Destroying Objects");
			Destroy(col.gameObject);
		}
	}
}
