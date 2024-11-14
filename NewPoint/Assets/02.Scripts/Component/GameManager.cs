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
        // 다른 씬에서도 사용하기 위해 오브젝트를 삭제 시키지 않음
        DontDestroyOnLoad(gameObject);
    }

    public void Diecount()
    {
        DieCount++;
        UIManager.Instance.DieCountText.text = $"<color=#ff0000>Die Count : {DieCount}</color>";
    }

    // 같은 종류의 코드 사용을 줄이기 위해 string과 GameObject를 추가
    public void ReCreateObject(string objName, GameObject obj)
    {
        Transform objPoint = GameObject.Find(objName).transform;
        if (obj.gameObject.activeSelf == false)
        {
            obj.transform.position = objPoint.position;
            obj.transform.rotation = objPoint.rotation;
            obj.gameObject.SetActive(true);
        }
    }

    public void ListPoint(string name, List<Transform> points)
    {
        var patrolpoint = GameObject.Find(name);
        if (patrolpoint != null)
            patrolpoint.GetComponentsInChildren<Transform>(points);
        points.RemoveAt(0);
    }
}
