using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private RectTransform GameUI;

    public Text playTime;
    public RectTransform ItemPanel;
    public Text ItemCount;
    public Image ItemImage;
    public Text DieCountText;

    void Start()
    {
        GameUI = GameObject.Find("Canvas_JoyStick").GetComponent<RectTransform>();
        playTime = GameUI.transform.GetChild(3).GetComponent<Text>();
        ItemPanel = GameUI.transform.GetChild(4).GetComponent <RectTransform>();
        ItemImage = ItemPanel.GetChild(0).GetComponent<Image>();
        ItemCount = ItemPanel.GetChild(1).GetComponent<Text>();
        DieCountText = ItemPanel.GetChild(2).GetComponent<Text>();
    }
}
