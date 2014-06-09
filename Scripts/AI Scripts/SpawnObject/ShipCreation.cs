using UnityEngine;
using System.Collections;

public class ShipCreation:MonoBehaviour{
    public GameObject prefab;
	int index;
	Transform _transform;
    
    void Start(){
		_transform = GetComponent<Transform>();
            InvokeRepeating ("Create",0.01f,1.0f);
    }
	void Update(){
		if(index>5)CancelInvoke();
	}
	void Create(){
		Instantiate(prefab, _transform.position,_transform.rotation);
		index++;
	}
}
