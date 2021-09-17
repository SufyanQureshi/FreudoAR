using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public Transform sun;

    public Transform[] planets;
  

    public float rotaionSpeed;


    void Start()
    {
        sun = GameObject.FindGameObjectWithTag("sun").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < planets.Length; i++)
        //{
        //    planets[i].RotateAround(sun.position, new Vector3(0, 0, -1), rotaionSpeed * Time.deltaTime);
        //}

        


    }
}
