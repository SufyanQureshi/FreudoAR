using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRotation : MonoBehaviour
{
    private Quaternion lockedRotation;

    void Start()
    {
        lockedRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = lockedRotation;
    }

}
