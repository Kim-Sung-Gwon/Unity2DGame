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
        // �ٸ� �������� ����ϱ� ���� ������Ʈ�� ���� ��Ű�� ����
        DontDestroyOnLoad(gameObject);
    }

    public void Diecount()
    {
        DieCount++;
        UIManager.Instance.DieCountText.text = $"<color=#ff0000>Die Count : {DieCount}</color>";
    }

    // ���� ������ �ڵ� ����� ���̱� ���� string�� GameObject�� �߰�
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
