using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameOver;

    int Count;
    int DieCount;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void Diecount()
    {
        DieCount++;
        UIManager.Instance.DieCountText.text = $"<color=#ff0000>Die Count : {DieCount}</color>";
    }

    public void ReCreateObject(string objName, Transform obj)
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
