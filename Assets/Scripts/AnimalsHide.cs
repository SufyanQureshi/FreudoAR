using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalsHide : MonoBehaviour
{
   


    public GameObject Animals;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(StopCoroutine());
    }

    IEnumerator StopCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        Animals.SetActive(true);
    }
}
