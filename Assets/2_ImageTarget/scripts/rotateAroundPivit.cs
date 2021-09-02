using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundPivit : MonoBehaviour
{
    public float rotaionSpeed;
    public GameObject pivitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivitObject.transform.position,new Vector3(0,1,0),rotaionSpeed*Time.deltaTime);
    }
}
