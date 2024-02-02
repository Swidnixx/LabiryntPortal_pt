using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int time = 60;
    bool paused;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            paused = !paused;
        }
    }
    void Pause()
    {
        Time.timeScale = 0;
    }
    void Resume()
    {
        Time.timeScale = 1;
    }

    void Stopper()
    {
        time--;
        if(time <= 0)
        {
            //game over
            CancelInvoke();
        }
    }
}
