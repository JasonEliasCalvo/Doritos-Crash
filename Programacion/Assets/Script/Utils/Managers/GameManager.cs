using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void DelegatedGameStates();
    public DelegatedGameStates eventGameStart;
    public DelegatedGameStates eventGameEnd;
    public static GameManager instance;

    [SerializeField] Timer timer;
    [SerializeField] Chronometer chronometer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void GamePrepate()
    {
        timer.eventEndTime += GameStart;
        timer.Initiate(3);
    }

    public void GameStart()
    {
        eventGameStart?.Invoke();
        chronometer.Initiate(0);
    }

    public void GamePause()
    {

    }
    public void GameResume()
    {

    }
    public void GameEnd()
    {
        chronometer.Stop();
        chronometer.End();
        eventGameEnd?.Invoke();
    }

}
