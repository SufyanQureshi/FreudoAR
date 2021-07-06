using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDestination : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Rocket")
        {
            Destroy(gameObject);
        }
    }
}
