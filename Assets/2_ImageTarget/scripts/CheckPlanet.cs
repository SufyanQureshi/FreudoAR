using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlanet : MonoBehaviour
{
    private int check;
    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Mercury")
        {
            check = 0;
            Debug.Log("Mercury");
        }
        else if (other.tag == "Venus")
        {
            check = 1;
            Debug.Log("Venus");
        }
        else if (other.tag == "Earth")
        {
            check = 2;
            Debug.Log("Earth");
        }
        else if (other.tag == "Mars")
        {
            check = 3;
            Debug.Log("Mars");
        }
        else if (other.tag == "Jupiter")
        {
            check = 4;
            Debug.Log("Jupiter");
        }
        else if (other.tag == "Saturn")
        {
            check = 5;
            Debug.Log("Saturn");
        }
        else if (other.tag == "Uranus")
        {
            check = 6;
            Debug.Log("Uranus");
        }
        else if (other.tag == "Neptune")
        {
            check = 7;
            Debug.Log("Neptune");
        }
    }

    public void findPlanet(int presedIndex)
    {
        if (presedIndex==check)
        {
            Debug.Log("Right Button Pressed");
        }
        else
        {
            Debug.Log("Wrong Button pressed");
        }
    }

    public void Attack()
    {
        Time.timeScale = 1;
        int randomNumber = Random.Range(1, 8);
        anim.SetTrigger("anim" + randomNumber);
    }
}
