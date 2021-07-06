using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject smoke;
    public Text countDown;
    



    public void WaitForSmoke()
    {
        StartCoroutine(WaitAndDo());


    }


    public void TimerCountDown()
    {
        StartCoroutine(CountDown());
    }


    IEnumerator WaitAndDo()
    {

        yield return new WaitForSeconds(7);
        smoke.SetActive(false);

    }

    IEnumerator CountDown()
    {
        countDown.text = "3";
        yield return new WaitForSeconds(1.0f);
        countDown.text = "2";
        yield return new WaitForSeconds(1.0f);
        countDown.text = "1";
        yield return new WaitForSeconds(1.0f);
        countDown.text = "Go!";
        yield return new WaitForSeconds(1.0f);
        countDown.text = "";

        WaitForSmoke();
    }
    


}
