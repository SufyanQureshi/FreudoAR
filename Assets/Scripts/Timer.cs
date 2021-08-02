using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public GameObject smoke;
    public GameObject Birds;
    public GameObject GoButton;
    public GameObject LaunchBack;
    public GameObject AnimalGroups;
    public GameObject TryAgainButton;
    public GameObject cat;
   

    public Text countDown;

    public UnityEvent showAnim;
    public UnityEvent showCat;
  

    public void WaitForSmoke()
    {
        StartCoroutine(WaitAndDo());


    }


    public void TimerCountDown()
    {
        StartCoroutine(CountDown());
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
        yield return new WaitForSeconds(16);
        
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
        
        GoButton.SetActive(false);

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

    // Wait for Go button
    public void EnableGoButton()
    {
        StartCoroutine(WaitEnableGoButton());
    }
    IEnumerator WaitEnableGoButton()
    {
        yield return new WaitForSeconds(8.0f);
        AnimalGroups.SetActive(false);
        GoButton.SetActive(true);
    }

    // Go  button Cat Move on moon
    public void EnableCat()
    {
        StartCoroutine(WaitEnablecat());
    }
    IEnumerator WaitEnablecat()
    {
        yield return new WaitForSeconds(15.0f);
        AnimalGroups.SetActive(true);
        cat.SetActive(true);
        showCat.Invoke();
    }

    /// Disable Cat
    ///
    public void DisableCat()
    {
        StartCoroutine(WaitDisablecat());
    }
    IEnumerator WaitDisablecat()
    {
        yield return new WaitForSeconds(24.0f);
        AnimalGroups.SetActive(false);
        LaunchBack.SetActive(true);


    }




}
