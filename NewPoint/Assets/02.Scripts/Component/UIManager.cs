using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager U_Instance;

    public RectTransform JoyStickUI;

    [SerializeField] private RectTransform GameUI;
    public Text playTime;
    public RectTransform P_gameOver;
    public Text AppleCount;

    void Start()
    {
        JoyStickUI = GameObject.Find("Canvas_JoyStick").GetComponent<RectTransform>();
        GameUI = GameObject.Find("Canvas_GameUI").GetComponent<RectTransform>();
        playTime = GameUI.transform.GetChild(0).GetComponent<Text>();
        P_gameOver = GameUI.transform.GetChild(1).GetComponent<RectTransform>();
        AppleCount = GameUI.transform.GetChild(3).GetComponent<Text>();
    }
}
