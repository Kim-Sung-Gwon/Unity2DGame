using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private RectTransform GameUI;

    public Text playTime;
    public Text DieCountText;

    void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        GameUI = GameObject.Find("Canvas").GetComponent<RectTransform>();
        playTime = GameUI.transform.GetChild(2).GetComponent<Text>();
        DieCountText = GameUI.transform.GetChild(3).GetComponent<Text>();
    }
}
