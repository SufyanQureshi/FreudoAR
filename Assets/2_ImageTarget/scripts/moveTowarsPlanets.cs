using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveTowarsPlanets : MonoBehaviour
{
    public GameObject[] planetsName;
    public int randomNumber;
     
    public bool check =false;
    private bool landingCheck=false;

   
    public AnimationCurve learpCurve;

    public Vector3 lerpOffSet;
    public float learpTime = 12f;
    private float timer = 0f;
    private float learpRatio;

    public GameObject ButtonGroup;
    public static moveTowarsPlanets instance;

    private void Awake()
    {
        

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        if (check)
        {
            timer += Time.deltaTime;

            if (timer > learpTime)
            {
                timer = learpTime;
            }

            learpRatio = timer / learpTime;
            Vector3 positionOffset = learpCurve.Evaluate(learpRatio) * lerpOffSet;
           
            transform.position = Vector3.Lerp(transform.position, planetsName[randomNumber].transform.position, learpRatio) + positionOffset;
            //transform.position.Normalize();

            if (landingCheck == false)
            {
                transform.up = planetsName[randomNumber].transform.position - transform.position;
            }

        }
       

    }

    public void moveRocket()
    {
        randomNumber = Random.Range(1, 8);
        Debug.Log(randomNumber);
        check = true;

        //for (int i = 0; i <= 7; i++)
        //{
        //    planetsName[i].GetComponent<CapsuleCollider>().enabled=true;
        //}
        ButtonGroup.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

  

}
  

