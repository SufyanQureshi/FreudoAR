using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowarsPlanets : MonoBehaviour
{
    public GameObject[] planetsName;
    int randomNumber;
    Vector3 CurentPosission;
    private bool check =false;

    public void Start()
    {
        randomNumber = Random.Range(1, 8);
    }
    public void MoveTowardPlantets()
    {
        Time.timeScale = 1;
        check = true;
    }
    public void Update()
    {
        if (check == true)
        {
            CurentPosission = planetsName[randomNumber].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, CurentPosission, 1f * Time.deltaTime);
            transform.up = planetsName[randomNumber].transform.position = transform.position;
        }
        
    }
}
   
