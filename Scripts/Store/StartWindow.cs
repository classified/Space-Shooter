using UnityEngine;
using System.Collections;
using Soomla;

public class StartWindow : MonoBehaviour
{
    void Start ()
    {
        OpenStore ();
    }

    void OpenStore ()
    {
        StorefrontController.OpenStore ();
    }
}
