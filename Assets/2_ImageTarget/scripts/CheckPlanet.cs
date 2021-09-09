using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlanet : MonoBehaviour
{
    private int check;
    public Animator anim;
    public GameObject rightPlanet;
    public GameObject[] planetsName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Mercury")
        {
            check = 0;
            planetsName[0].SetActive(true);
            Debug.Log("Mercury");
        }
        else if (other.tag == "Venus")
        {
            check = 1;
            planetsName[1].SetActive(true);
            Debug.Log("Venus");
        }
        else if (other.tag == "Earth")
        {
            check = 2;
            planetsName[2].SetActive(true);
            Debug.Log("Earth");
        }
        else if (other.tag == "Mars")
        {
            check = 3;
            planetsName[3].SetActive(true);
            Debug.Log("Mars");
        }
        else if (other.tag == "Jupiter")
        {
            check = 4;
            planetsName[4].SetActive(true);
            Debug.Log("Jupiter");
        }
        else if (other.tag == "Saturn")
        {
            check = 5;
            planetsName[5].SetActive(true);
            Debug.Log("Saturn");
        }
        else if (other.tag == "Uranus")
        {
            check = 6;
            planetsName[6].SetActive(true);
            Debug.Log("Uranus");
        }
        else if (other.tag == "Neptune")
        {
            check = 7;
            planetsName[7].SetActive(true);
            Debug.Log("Neptune");
        }
    }

    public void findPlanet(int presedIndex)
    {
        if (presedIndex==check)
        {
            rightPlanet.SetActive(true);
            Debug.Log("Right Button Pressed");
        }
        else
        {
            Debug.Log("Wrong Button pressed");
        }
    }

    //public void Attack()
    //{
    //    Time.timeScale = 1;
    //    int randomNumber = Random.Range(1, 8);
    //    anim.SetTrigger("anim" + randomNumber);
    //}

    public void MoveTowardPlantets()
    {
        Time.timeScale = 1;

        int randomNumber = Random.Range(1, 8);
        // planetsName[randomNumber]     
        transform.position = Vector3.MoveTowards(transform.position, planetsName[randomNumber].transform.position, 10f * Time.deltaTime);
    }
}
