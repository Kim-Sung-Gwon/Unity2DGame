using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuneCtrl : MonoBehaviour
{
    [SerializeField] private RectTransform Canvas;
    [SerializeField] private RectTransform MunePanel;
    [SerializeField] private RectTransform MuneImage;
    [SerializeField] private RectTransform SoundMune;

    bool isPause;

    void Start()
    {
        isPause = false;
        Canvas = GameObject.Find("Canvas_JoyStick").GetComponent<RectTransform>();
        MunePanel = Canvas.transform.GetChild(1).GetComponent<RectTransform>();
        MuneImage = MunePanel.transform.GetChild(0).GetComponent<RectTransform>();
        SoundMune = MunePanel.transform.GetChild(1).GetComponent<RectTransform>();
    }

    public void Pause()
    {
        isPause = !isPause;
        if (Canvas.gameObject.activeSelf)
        {
            MunePanel.gameObject.SetActive(true);
            MuneImage.gameObject.SetActive(true);
            SoundMune.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Sound(bool isOpen)
    {
        SoundMune.gameObject.SetActive(isOpen);
        MuneImage.gameObject.SetActive(!isOpen);
    }

    public void Resume()
    {
        MunePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
