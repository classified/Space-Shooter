using UnityEngine;
using System.Collections;

public class EnemyLaserFire : MonoBehaviour
{

    private float fireFreqEnemy;
    public GameObject enemyLaser;
    private float enemyLastShot;


    // Update is called once per frame
    void Update ()
    {
	
        if (DificultySelect.easyLevel) {
            fireFreqEnemy = 1f;
        }
        if (DificultySelect.medLevel) {
            fireFreqEnemy = 1.5f;		
        }
        if (DificultySelect.HardLevel) {
            fireFreqEnemy = 2f;
        }
        if (Time.time > enemyLastShot + fireFreqEnemy) {
            fireEnemy ();
        }
    }

    void fireEnemy ()
    {
        enemyLastShot = Time.time;
        Instantiate (enemyLaser, transform.position, transform.rotation);
    }
}
