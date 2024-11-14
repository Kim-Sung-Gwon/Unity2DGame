using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTime : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    float sec;
    int min;
    int hor;

    void Start()
    {
        uiManager = GetComponent<UIManager>();
    }

    void Playtime()
    {
        // 시작 후 경과한 플레이 타임
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
        Playtime();
    }
}
