using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip goalClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.SetWinPanel(true);
            audioSource.PlayOneShot(goalClip);
            GameManager.instance.GameEnd();
        }
    }
}
