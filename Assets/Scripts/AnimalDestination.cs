using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AnimalDestination : MonoBehaviour
{
    public GameObject AnimalGroups;
    public GameObject LaunchButton;

    public void AnimalsHidFun()
    {
        StartCoroutine(animalsHide());
    }

    IEnumerator animalsHide()
    {

        yield return new WaitForSeconds(10);
        AnimalGroups.SetActive(false);
        LaunchButton.SetActive(true);

    }

    public void loadScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// /
    /// </summary>
    /// 
   




    //public UnityEvent MyEvent;
    //public GameObject LaunchButton;

    // void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag=="Rocket")
    //    {
    //        gameObject.SetActive(false);

    //        MyEvent.Invoke();

    //    }
    //}
}
