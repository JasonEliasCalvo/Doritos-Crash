using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject winPanel;
    [SerializeField] TextMeshProUGUI scooreText;

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

    public void Start()
    {
        winPanel.SetActive(false);
    }

    public void SetWinPanel(bool state)
    {
        winPanel.SetActive(state);
    }

    public void SetScoore(float scoore)
    {
        scooreText.text = scoore.ToString() + "s";
    }
}

