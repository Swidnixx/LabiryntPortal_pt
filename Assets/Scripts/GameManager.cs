using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Time
    public int time = 60;
    bool paused;

    // Pickups
    int diamonds;
    int keys_red, keys_green, keys_gold;

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

    // Time
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

    // Pickups
    public void PickDiamond()
    {
        diamonds++;
    }
    public void PickKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                keys_red++;
                break;
            case KeyColor.Green:
                keys_green++;
                break;
            case KeyColor.Gold:
                keys_gold++;
                break;
        }
    }
    public void AddTime(int timeToAdd)
    {
        time += timeToAdd;
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), time, 1);
    }
}
