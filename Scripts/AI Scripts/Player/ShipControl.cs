using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	
	/*
	 * Variable declarations
	 * _transform is a cache of the Transform for optimization
	 * _spawn is used for shooting 
	 * The projectile prefab needs to be dragged and dropped (it should be done already)
	 * */
	Transform _transform;
	Transform _spawn;
	public GameObject projectile;
	public int health;
	float horizontalSpeed = 5.0F;
    float verticalSpeed = 5.0F;
	
	/*
	 * Health gets a value of 100
	 * the Transform is passed to _transform
	 * _spawn is passed a reference to the Spawn object transform
	 * */
	void Start () {
		health = 100;
		_transform = GetComponent<Transform>();
		_spawn = _transform.Find ("Spawn").GetComponent <Transform>();
	}
	

    void Update() {
		/*
		 * Movement of the ship
		 * ClampTransform is an extension function. See the article on memory management for explanation
		 * The function is declared in the GameManager.cs script
		 * */
		Vector3 move = Vector3.zero;
        move.x = horizontalSpeed * Input.GetAxis("Horizontal")*Time.deltaTime;
        move.z = verticalSpeed * Input.GetAxis("Vertical")*Time.deltaTime;
		_transform.ClampTransform(move,new Vector3(2f,0f,-8.5f),new Vector3(17.5f,0f,-1.5f));
		
		/*
		 * Instantiation of the projectile which holds a script to move it. 
		 * */
		if(Input.GetKeyDown(KeyCode.Space)) Instantiate(projectile,_spawn.position,transform.rotation);
    }
	
	/*
	 * Printing the health on screen
	 * */
	void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), health.ToString());
    }
	
	/*
	 * Decreasing health by n. The function is called by the object colliding
	 */
	public void DecreaseHealth(int n){
		health-=n;
		if(health<=0)Destroy (gameObject);
	}
	
}
