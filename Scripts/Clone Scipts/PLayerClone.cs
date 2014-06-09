using UnityEngine;
using System.Collections;

public class PLayerClone : MonoBehaviour
{

    private GameObject myObJ;
    // Update is called once per frame
    void Start ()
    {
        myObJ = this.gameObject;
    }
    void Update ()
    {
        myObJ.transform.position = this.gameObject.transform.position;
    }
}
