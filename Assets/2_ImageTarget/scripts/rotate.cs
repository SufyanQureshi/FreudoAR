using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public  float rotationSpeed;
    public Animator[] anim;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            WalkAnim();
        }
        
    }

    // Update is called once per frame
    void Update()
    {    
        transform.Rotate(new Vector3(0, rotationSpeed, 0)*Time.deltaTime);

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
}
