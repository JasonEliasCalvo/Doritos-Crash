using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    bool activated = false;
    [SerializeField]
    UnityEvent unityEventTouchCheckpoint;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip getPointClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;
            unityEventTouchCheckpoint?.Invoke();
            audioSource.PlayOneShot(getPointClip);
            CheckPointController.instance.GetCheckPoint(this);
        }
    }
}
