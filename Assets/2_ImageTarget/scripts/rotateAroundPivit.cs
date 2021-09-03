using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundPivit : MonoBehaviour
{
    public float rotaionSpeed;
    public Transform pivitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(pivitObject.transform.position, pivitObject.transform.up, rotaionSpeed*Time.deltaTime);
        transform.RotateAround(pivitObject.position , -Vector3.up, rotaionSpeed * Time.deltaTime);
    }
}
