using UnityEngine;
using System.Collections;

public class PlayerCircle : MonoBehaviour
{
    
    public GameObject Ship;
    protected int Amount;
    protected int RandomSpawn;
    protected int RandomPosition;
    protected float RandomStart;
    // protected float speedEnemy = -3f;
    protected string playerChosen = "ClonePrefeb";
    
    void Start ()
    {

        if (DificultySelect.done_player) {
            Debug.Log ("done_player true");
            playerChosen = "ClonePrefeb1";
           
        }
        if (DificultySelect.player1) {
            Debug.Log ("player true");
            playerChosen = "ClonePrefeb";

        }

        Ship = Instantiate (Resources.Load (playerChosen, typeof(GameObject)), transform.localPosition, Quaternion.identity)as GameObject;

        RandomSpawn = Random.Range (0, 2);
        StartCoroutine ("EnemySpawnPhase");
          
           

    }
    
    void PlaceShip (GameObject obj, int i, int amount)
    {
        float u = ((float)i / (float)(amount)) * (Mathf.PI * 2);
        float x = (float)Mathf.Cos (u);
        float z = (float)Mathf.Sin (u);
        
        obj.transform.localPosition = new Vector3 (x - 3, 0, z) * 2;
    }
    
    IEnumerator EnemySpawnPhase ()
    {
        
        RandomStart = Random.Range (-3.4f, 3.4f);  
        Amount = Random.Range (1, 5);
        yield return new WaitForSeconds (1f);
        for (int i = 0; i< Amount; i++) {
            Debug.Log (" Random Spawn :" + RandomSpawn);
            GameObject obj = (GameObject)Instantiate (Ship, transform.position, transform.rotation);    
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
   
}
