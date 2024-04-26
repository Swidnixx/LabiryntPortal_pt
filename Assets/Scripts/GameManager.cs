using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool over;

    // Pickups
    int diamonds;
    int keys_red, keys_green, keys_gold;
    public int Diamonds => diamonds;
    public int RedKeys => keys_red;
    public int GreenKeys => keys_green;
    public int GoldKeys => keys_gold;

    public DisplayUI displayUI;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }
    private void Update()
    {
        if(over || paused)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }

            if (!paused)
                return;
        }

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
        displayUI.DisplayPause(true);
    }
    void Resume()
    {
        Time.timeScale = 1;
        displayUI.DisplayPause(false);
    }
    void Stopper()
    {
        displayUI.DisplayFreeze(false);
        time--;
        if(time <= 0)
        {
            //game over
            CancelInvoke();
            Time.timeScale = 0;
            over = true;
            displayUI.DisplayGameOver(false);
        }
    }
    public void Win()
    {
        CancelInvoke();
        Time.timeScale = 0;
        over = true;
        displayUI.DisplayGameOver(true);
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
        displayUI.DisplayFreeze(true);
    }

    public bool HasKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                return keys_red > 0;
            case KeyColor.Green:
                return keys_green > 0;
            case KeyColor.Gold:
                return keys_gold > 0;
        }
        return false;
    }
    public void UseKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                keys_red--;
                break;
            case KeyColor.Green:
                keys_green--;
                break;
            case KeyColor.Gold:
                keys_gold--;
                break;
        }
    }
}
