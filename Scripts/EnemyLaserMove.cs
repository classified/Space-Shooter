using UnityEngine;
using System.Collections;

public class EnemyLaserMove : MonoBehaviour
{
	public float laserSpeed = -5f;

		// Update is called once per frame
		void Update ()
		{
			
			transform.Translate (0f,0f,laserSpeed * Time.smoothDeltaTime);
			if (transform.position.z < -7 ) {
				Destroy(gameObject);
			}
		}
}

