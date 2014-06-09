using UnityEngine;
using System.Collections;


public class ProtectScript :Enemy {
	
 	enum State{
		forward,hiding,moving
	};
	State current;
	Transform _cover;
	Transform [] _wayout = new Transform[2];
	public int way;
	public bool hit;
	public override void Start () {
		base.Start ();
		Health = 3;

		_cover = GameObject.Find ("Cover").GetComponent<Transform>();
		GameObject[] obj = GameObject.FindGameObjectsWithTag("Wayout");
		for(int i = 0;i<obj.Length;i++)_wayout[i] = obj[i].GetComponent<Transform>();
		current = State.forward;
		way = -1;
		hit =false;
		PrimaryShoot = transform.Find ("SpawnLeft").GetComponent<Transform>();
		SecondaryShoot = transform.Find ("SpawnRight").GetComponent<Transform>();
		InvokeRepeating("Shoot",0.01f,Random.Range(2.0f,4.0f));
	}
	
	public override void Update () {
		switch(current){
			case State.forward:
				Transform.Translate ( -Velocity.x*Time.deltaTime,0,Velocity.z*Time.deltaTime,Space.World);
				break;
			case State.hiding: 
				ToTarget (_cover);
				if(Vector3.Distance (_cover.position,Transform.position) <= 0.5f &&way<0 ) {		
					StartCoroutine(ChangeSwitch(Random.Range (1.0f,3.0f)));	
					way = Random.Range (0,2);
				}
				break;
			case State.moving:
				ToTarget (_wayout[way]);
				if(Vector3.Distance (_wayout[way].position,Transform.position) < 0.2f) current = State.forward;	
				break;
		}
	}
	
	
	IEnumerator ChangeSwitch(float time) {
		yield return new WaitForSeconds(time);
		current = State.moving;
	}
	
	public override void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "ProjectileShip"){
			Destroy(other.gameObject);
			print ("Script");
			Health-=1;
			if(Health<=0)Destroy(gameObject);
			if(current ==State.forward &&Transform.position.x >_cover.position.x ){
				current =State.hiding;
			}
		}
	}
	void ToTarget(Transform tr){
		Vector3 direction = tr.position - Transform.position;
		direction.Normalize();
		Transform.Translate ( direction.x*Time.deltaTime,0,direction.z*Time.deltaTime,Space.World);
	}
}
