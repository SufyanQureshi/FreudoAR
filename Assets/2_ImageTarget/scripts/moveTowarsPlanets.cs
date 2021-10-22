using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowarsPlanets : MonoBehaviour
{
    public GameObject[] planetsName;
    int randomNumber;
   Vector3  CurentPosission;
    private bool check =false;

    public void Start()
    {
        randomNumber = Random.Range(1, 8);
    }
    public void MoveTowardPlantets()
    {
      
        check = true;
        if (check == true)
        {
            CurentPosission = planetsName[randomNumber].transform.position;
            transform.position = Vector3.MoveTowards(CurentPosission, CurentPosission, 0.1f * Time.deltaTime);
            transform.up = planetsName[randomNumber].transform.position = transform.position;

        }


    }
    public void Update()
    {
       


    }
}
   
