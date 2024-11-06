using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger G_Instance;

    [SerializeField] private UIManager uiManager;
    public bool IsGameOver;

    float sec;
    int min;
    int hor;

    public int Count { get; private set; }

    void Start()
    {
        if (G_Instance == null) G_Instance = this;
        else if (G_Instance != this) Destroy(gameObject);

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //CountUpDate();
    }

    void PlayTime()
    {
        sec += Time.deltaTime;
        if (sec > 59f)
        {
            sec = 0;
            min++;
            if (min > 59f)
            {
                min = 0;
                hor++;
            }
        }
        uiManager.playTime.text = $"<color=#ffff00>{hor:D2} : {min:D2} : {(int)sec:D2}</color>";
    }

    void Update()
    {
        if (!IsGameOver)
        {
            PlayTime();
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        uiManager.JoyStickUI.gameObject.SetActive(false);
        uiManager.P_gameOver.gameObject.SetActive(true);
    }

    public void ColCount()
    {
        Count++;
        CountUpDate();
    }

    void CountUpDate()
    {
        uiManager.AppleCount.text = $": <color=#0000ff>{Count}</color>";
    }
}
