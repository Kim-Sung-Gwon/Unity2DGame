using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager U_Instance;

    [SerializeField] private RectTransform JoyStickUI;

    public Text playTime;
    public RectTransform ItemPanel;
    public Text ItemCount;
    public Image ItemImage;
    public Text DieCountText;

    void Start()
    {
        JoyStickUI = GameObject.Find("Canvas_JoyStick").GetComponent<RectTransform>();
        playTime = JoyStickUI.transform.GetChild(2).GetComponent<Text>();
        ItemPanel = JoyStickUI.transform.GetChild(3).GetComponent <RectTransform>();
        ItemCount = ItemPanel.GetChild(1).GetComponent<Text>();
        ItemImage = ItemPanel.GetChild(0).GetComponent<Image>();
        DieCountText = JoyStickUI.transform.GetChild(4).GetComponent<Text>();
    }
}
