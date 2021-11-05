using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public Transform sun;

    public Transform[] planets;
    public Animator[] anim;
    
    public float rotaionSpeed;
    public bool check = false;
  


    public static IncreaseSpeed instance;

    void Awake()
    {
        sun = GameObject.FindGameObjectWithTag("sun").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //new Vector3(0, 0, 1)
        if (check==true)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                planets[i].RotateAround(sun.position, sun.up, rotaionSpeed * Time.deltaTime);
            }
        }
    }

    public void WalkAnim()
    {
        anim[0].SetTrigger("mercury_walk");
        anim[1].SetTrigger("venus_walk");
        anim[2].SetTrigger("earth_walk");
        anim[3].SetTrigger("mars_walk");
        anim[4].SetTrigger("jupiter_walk");
        anim[5].SetTrigger("saturn_walk");
        anim[6].SetTrigger("uranus_walk");
        anim[7].SetTrigger("neptune_walk");
    }


    public void StartPlanetstoWalk()
    {
        check = true;
        for (int i = 0; i < 1000; i++)
        {
            WalkAnim();
        }
    }

    public void StopPlanets()
    {
        check = false;
      
        for (int i = 0; i <=7; i++)
        {
            anim[i].GetComponent<Animator>().enabled = false;
        }
    }



}
