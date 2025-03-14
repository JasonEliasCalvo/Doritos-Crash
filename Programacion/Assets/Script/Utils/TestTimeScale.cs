using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeScale : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            Time.timeScale = 1;
        }
    }
}
