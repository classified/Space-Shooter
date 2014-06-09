using UnityEngine;
using System.Collections;

public class Enemy1Movement : MonoBehaviour
{

    private float speed;

        
    // Update is called once per frame
    void Update ()
    {
        if (DificultySelect.easyLevel) {
            speed = -3f;
        }
        if (DificultySelect.medLevel) {
            speed = -3.5f;      
        }
        if (DificultySelect.HardLevel) {
            speed = -4.1f;
        }
        transform.Translate (0f, 0f, speed * Time.smoothDeltaTime);

        
    }
}

