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
                        anim[0].SetTrigger("happy_wave");
                        break;
                    //case "venus":
                    //    myAudioSource.clip = aClips[1];
                    //    myAudioSource.Play();
                    //    break;
                    //case "earth":
                    //    myAudioSource.clip = aClips[2];
                    //    myAudioSource.Play();
                    //    break;
                    //case "mars":
                    //    myAudioSource.clip = aClips[3];
                    //    myAudioSource.Play();
                    //    break;
                    //case "jupiter":
                    //    myAudioSource.clip = aClips[4];
                    //    myAudioSource.Play();
                    //    break;
                    //case "saturn":
                    //    myAudioSource.clip = aClips[5];
                    //    myAudioSource.Play();
                    //    break;
                    //case "uranus":
                    //    myAudioSource.clip = aClips[5];
                    //    myAudioSource.Play();
                    //    break;
                    //case "neptune":
                    //    myAudioSource.clip = aClips[5];
                    //    myAudioSource.Play();
                    //    break;
                    default:
                        break;

                }
            }
        }

    }
}
