using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    public GameObject pausePanel, losePanel, winPanel;
    public Text time, diamonds, redKeys, greenKeys, goldKeys;
    public Image freezeImage;

    private void Start()
    {
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void Update()
    {
        time.text = GameManager.Instance.time.ToString();
        diamonds.text = GameManager.Instance.Diamonds.ToString();
        redKeys.text = GameManager.Instance.RedKeys.ToString();
        greenKeys.text = GameManager.Instance.GreenKeys.ToString();
        goldKeys.text = GameManager.Instance.GoldKeys.ToString();
    }

    public void DisplayFreeze(bool active)
    {
        freezeImage.enabled = active;
    }

    public void DisplayPause(bool pause)
    {
        pausePanel.SetActive(pause);
    }

    public void DisplayGameOver(bool win)
    {
        winPanel.SetActive(win);
        losePanel.SetActive(!win);
    }
}
