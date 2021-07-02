using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public Animator animFly;

    void Start()
    {
        animFly = gameObject.GetComponent<Animator>();
    }
    
    public void PlayAnim()
    {
        animFly.SetTrigger("Active");
    }

}
