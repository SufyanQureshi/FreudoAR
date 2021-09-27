using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetect : MonoBehaviour
{
    
    //public AudioSource myAudioSource;
    public Animator[] anim;
    string btnName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;

                switch (btnName)
                {
                    case "mercury":
                        anim[0].SetTrigger("mercury");
                        break;
                    case "venus": 
                        anim[1].SetTrigger("venus");
                        break;
                    case "earth":
                        anim[2].SetTrigger("earth");
                        break;
                    case "mars":
                        anim[3].SetTrigger("mars");
                        break;
                    case "jupiter":
                        anim[4].SetTrigger("jupiter");
                        break;
                    case "saturn":
                        anim[5].SetTrigger("saturn");
                        break;
                    case "uranus":
                        anim[6].SetTrigger("uranus");
                        break;
                    case "neptune":
                        anim[7].SetTrigger("neptune");
                        break;

                    default:
                        break;

                }
            }
        }

    }
}
