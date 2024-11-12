using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtrl : MonoBehaviour
{
    [SerializeField] private RectTransform Panel_1;
    [SerializeField] private RectTransform Panel_2;
    [SerializeField] private RectTransform Panel_3;

    bool Panel;

    void Start()
    {
        Panel_1 = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<RectTransform>();
        Panel_2 = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<RectTransform>();
        Panel_3 = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<RectTransform>();
    }


    public void OnPanle_1(bool isOpen)
    {
        Panel_1.gameObject.SetActive(isOpen);
        Panel_2.gameObject.SetActive(!isOpen);
    }

    public void OnPanle_2(bool isOpen)
    {
        Panel_2.gameObject.SetActive(isOpen);
        Panel_3.gameObject.SetActive(!isOpen);
    }
}
