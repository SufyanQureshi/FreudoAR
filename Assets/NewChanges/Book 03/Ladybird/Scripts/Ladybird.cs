using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladybird : MonoBehaviour
{
    private Animator ladybird;
    public GameObject MainCamera;
    public GameObject ladybirdMaterial;
    public Material LadybirdSad;
    public Material LadybirdHappy;
    public Material LadybirdDeath;
    void Start()
    {
        ladybird = GetComponent<Animator>();
    }

    void Update()
    {
        if (ladybird.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            ladybird.SetBool("fly", false);
            ladybird.SetBool("takeoff", false);
            ladybird.SetBool("landing", false);
        }
        if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.D))||(Input.GetKeyUp(KeyCode.F))||(Input.GetKeyUp(KeyCode.Keypad1)))
        {
            ladybird.SetBool("idle", true);
            ladybird.SetBool("walk", false);
            ladybird.SetBool("turnleft", false);
            ladybird.SetBool("turnright", false);
            ladybird.SetBool("flyleft", false);
            ladybird.SetBool("flyright", false);
            ladybird.SetBool("fly", true);
            ladybird.SetBool("attack", false);
            ladybird.SetBool("hit", false);
            ladybirdMaterial.GetComponent<SkinnedMeshRenderer>().material = LadybirdHappy;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ladybird.SetBool("walk", true);
            ladybird.SetBool("idle", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ladybird.SetBool("takeoff", true);
            ladybird.SetBool("idle", false);
            ladybird.SetBool("landing", true);
            ladybird.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ladybird.SetBool("turnleft", true);
            ladybird.SetBool("idle", false);
            ladybird.SetBool("flyleft", true);
            ladybird.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ladybird.SetBool("turnright", true);
            ladybird.SetBool("idle", false);
            ladybird.SetBool("flyright", true);
            ladybird.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ladybird.SetBool("attack", true);
            ladybird.SetBool("idle", false);
            ladybirdMaterial.GetComponent<SkinnedMeshRenderer>().material = LadybirdSad;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ladybird.SetBool("hit", true);
            ladybird.SetBool("idle", false);
            ladybirdMaterial.GetComponent<SkinnedMeshRenderer>().material = LadybirdSad;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ladybird.SetBool("die", true);
            ladybird.SetBool("idle", false);
            ladybirdMaterial.GetComponent<SkinnedMeshRenderer>().material = LadybirdDeath;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            MainCamera.GetComponent<CameraFollow>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            MainCamera.GetComponent<CameraFollow>().enabled = true;
        }
    }
}
