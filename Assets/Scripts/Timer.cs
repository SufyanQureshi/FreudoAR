using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public GameObject smoke;
    public GameObject Birds;
    public GameObject LaunchButton;
    public GameObject LaunchBack;
    public GameObject AnimalGroups;
    public GameObject TryAgainButton;

    public Text countDown;

    public UnityEvent showAnim;

    public void WaitForSmoke()
    {
        StartCoroutine(WaitAndDo());


    }


    public void TimerCountDown()
    {
        StartCoroutine(CountDown());
    }

    /// <summary>
    /// /
    /// </summary>
    public void LaunchBackFun()
    {
        StartCoroutine(WaitLaunchBack());
       
    }


    IEnumerator WaitLaunchBack()
    {
        yield return new WaitForSeconds(12);
        LaunchBack.SetActive(true);
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void ShowAnimalsFun()
    {
        StartCoroutine(ShowAnimals());

    }


    IEnumerator ShowAnimals()
    {
        yield return new WaitForSeconds(14);
        
        Birds.SetActive(true);
        
        AnimalGroups.SetActive(true);
        showAnim.Invoke();

        yield return new WaitForSeconds(8);
        TryAgainButton.SetActive(true);

    }
    /// <summary>
    /// /
    /// </summary>
    /// <returns></returns>

   
    /// <summary>
    /// /
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitAndDo()
    {

        yield return new WaitForSeconds(5);
        smoke.SetActive(false);
        Birds.SetActive(false);
        LaunchButton.SetActive(false);

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
        LaunchBackFun();
    }
    


}
