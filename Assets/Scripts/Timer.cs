using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject smoke;

    public void WaitForSmoke()
    {
        StartCoroutine(WaitAndDo());
    }

    IEnumerator WaitAndDo()
        {

        yield return new  WaitForSeconds(7);
        smoke.SetActive(false);
        }
    


}
