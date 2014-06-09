using UnityEngine;
using System.Collections;

public static class GameManager{
	
	/*
	 * Extension function for th Transform. for full explanation, see the memory management article
	 * The object is clamped within the boundaries of the min-max vectors.
	 * */
	public static void ClampTransform(this Transform tr,Vector3 move, Vector3 min, Vector3 max){
		Vector3 pos = tr.position + move;
		if(pos.x< min.x )pos.x = min.x;
		else if(pos.x>max.x)pos.x=max.x;
		
		if(pos.y< min.y )pos.y = min.y;
		else if(pos.y>max.y)pos.y=max.y;
		
		if(pos.z<min.z)pos.z=min.z;
		else if(pos.z>max.z)pos.z=max.z;
		
		tr.position = pos;
	}
	public static void Target(this Transform _transform, Transform _target){
		Vector3 direction = _target.position - _transform.position;
		direction.Normalize();
		_transform.Translate ( direction.x*Time.deltaTime,0,direction.z*Time.deltaTime,Space.World);
	}
}


