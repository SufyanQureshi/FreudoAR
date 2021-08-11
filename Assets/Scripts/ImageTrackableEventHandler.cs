using UnityEngine;
using Vuforia;
using System.Collections;
using UnityEngine.Networking;
using static Vuforia.TrackableBehaviour;

public class ImageTrackableEventHandler : MonoBehaviour
{
    private TrackableBehaviour mTrackableBehaviour;

    public AudioSource audioSource;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            
            mTrackableBehaviour.RegisterOnTrackableStatusChanged(OnTrackableStateChanged);
        }
    }

   
    public void OnTrackableStateChanged(StatusChangeResult obj)
    {
        if (obj.NewStatus == Status.DETECTED || obj.NewStatus == Status.TRACKED || obj.NewStatus == Status.EXTENDED_TRACKED)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

    


}
