using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private Transform PlayerTr;
    [SerializeField] private Transform SpawnPoint;

    public bool IsGameOver;

    float sec;
    int min;
    int hor;

    public int Count { get; private set; }
    public int DieCount { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        uiManager = GameObject.Find("Canvas_JoyStick").GetComponent<UIManager>();
        SpawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        PlayerTr = Resources.Load<Transform>("Player");

        CreatePlayer();
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
        PlayTime();
    }

    public void Counter()
    {
        Count++;
    }

    public void ColCount()
    {
        Counter();
        uiManager.ItemCount.text = $": <color=#0000ff>{Count}</color>";
    }

    public void Diecount()
    {
        DieCount++;
        uiManager.DieCountText.text = $"<color=#ff0000>Die Count : {DieCount}</color>";
    }

    public void CreatePlayer()
    {
        Instantiate(PlayerTr, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void ReCreatePlayer(string objName, Transform obj)
    {
        Transform objPoint = GameObject.Find(objName).transform;
        if (obj.gameObject.activeSelf == false)
        {
            obj.transform.position = objPoint.position;
            obj.transform.rotation = objPoint.rotation;
            obj.gameObject.SetActive(true);
        }
    }
}
