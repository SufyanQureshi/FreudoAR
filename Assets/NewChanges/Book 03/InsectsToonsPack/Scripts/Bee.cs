using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {
    public Animator bee;
    private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            bee.SetBool("idle2", true);
            bee.SetBool("takeoff", false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            bee.SetBool("takeoff", true);
            bee.SetBool("idle2", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            bee.SetBool("gotoflyfast", true);
            bee.SetBool("idle", false);
            StartCoroutine("fly");
            fly();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            bee.SetBool("gotoflyslow", true);
            bee.SetBool("flyingfast", false);
            bee.SetBool("gotoflyfast", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            bee.SetBool("landing", true);
            bee.SetBool("idle", false);
            StartCoroutine("idle2");
            idle2();
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            bee.SetBool("idle", false);
            bee.SetBool("hited", true);
            bee.SetBool("attack", false);
            StartCoroutine("idle");
            idle();
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            bee.SetBool("attack", true);
            bee.SetBool("idle", false);
            bee.SetBool("hited", false);
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            bee.SetBool("idle", false);
            bee.SetBool("attack", false);
            bee.SetBool("death", true);
        }
    }
    IEnumerator fly()
    {
        yield return new WaitForSeconds(0.5f);
        bee.SetBool("gotoflyfast", false);
        bee.SetBool("flyingfast", true);
    }

    IEnumerator idle()
    {
        yield return new WaitForSeconds(0.5f);
        bee.SetBool("gotoflyslow", false);
        bee.SetBool("idle", true);
        bee.SetBool("takeoff", false);
        bee.SetBool("hited", false);
    }
    IEnumerator idle2()
    {
        yield return new WaitForSeconds(1.0f);
        bee.SetBool("landing", false);
        bee.SetBool("idle2", true);
    }
}
