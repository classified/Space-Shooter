using UnityEngine;
using System.Collections;

public class CreateRandom : MonoBehaviour
{
    public GameObject Ship;
    Transform _transform;
    void Start ()
    {
        _transform = GetComponent<Transform> ();
        InvokeRepeating ("CreateRandomShip", 0.01f, 1.0f);
    }
	
    void CreateRandomShip ()
    {
        Vector3 vec = new Vector3 (0, 1.3f, _transform.position.z);
        Random.Range (-1f, -9f);
        Instantiate (Ship, vec, transform.rotation);
    }
}
