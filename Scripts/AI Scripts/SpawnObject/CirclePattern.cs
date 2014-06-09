using UnityEngine;
using System.Collections;

public class CirclePattern : MonoBehaviour
{

    public GameObject[] Ship;
    protected int Amount;
    protected int RandomSpawn;
    protected int RandomPosition;
    protected float RandomStart;
    // protected float speedEnemy = -3f;
  

    void Start ()
    {
        RandomStart = Random.Range (-3.4f, 3.4f);
        if (DificultySelect.easyLevel) {
            Amount = Random.Range (1, 5);
        }
        if (DificultySelect.medLevel) {
            Amount = Random.Range (1, 9);
        }
        if (DificultySelect.HardLevel) {
            Amount = Random.Range (1, 12);
        }
    }

    void Update ()
    {

        StartCoroutine ("StartTransform"); 
        if (transform.position.z <= -19f) {
            transform.position = new Vector3 (RandomStart, 1.3f, 8.15f);
            RandomSpawn = Random.Range (0, 2);
            StartCoroutine ("StartTransform");
            StartCoroutine ("EnemySpawnPhase");
        }
        if (transform.position.x <= -10f) {
            transform.position = new Vector3 (RandomStart, 1.3f, 8.15f);
            RandomSpawn = Random.Range (0, 2);
            StartCoroutine ("StartTransform");
            StartCoroutine ("EnemySpawnPhase");
        }
    }
   
    void PlaceShip (GameObject obj, int i, int amount)
    {
        float u = ((float)i / (float)(amount)) * (Mathf.PI * 2);
        float x = (float)Mathf.Cos (u);
        float z = (float)Mathf.Sin (u);

        obj.transform.localPosition = new Vector3 (x, 0, z) * 2;
    }

    IEnumerator EnemySpawnPhase ()
    {

        RandomStart = Random.Range (-3.4f, 3.4f);  
        if (DificultySelect.easyLevel) {
            Amount = Random.Range (1, 5);
        }
        if (DificultySelect.medLevel) {
            Amount = Random.Range (1, 9);
        }
        if (DificultySelect.HardLevel) {
            Amount = Random.Range (1, 12);
        }
        yield return new WaitForSeconds (1f);
        for (int i = 0; i< Amount; i++) {
            Debug.Log (" Random Spawn :" + RandomSpawn);
            GameObject obj = (GameObject)Instantiate (Ship [RandomSpawn], transform.position, transform.rotation);    
            obj.transform.parent = transform;
            PlaceShip (obj, i, Amount);
            CircleMove sc = obj.GetComponent<CircleMove> ();
            float angle = Vector3.Angle (obj.transform.localPosition, transform.forward);
            Vector3 cross = Vector3.Cross (obj.transform.localPosition, transform.forward);
            if (cross.y < 0)
                angle = -angle;
            sc.phase = angle * Mathf.Deg2Rad;
        }
    }
    IEnumerator StartTransform ()
    {
        yield return new WaitForSeconds (3f);
        transform.Translate (0, 0, -Time.deltaTime, Space.World);

    }
}
