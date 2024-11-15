using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance;

    [SerializeField] private GameObject Thorn;
    [SerializeField] private List<GameObject> ListObj = new List<GameObject>();
    [SerializeField] private List<Transform> ListTr = new List<Transform>();

    void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Thorn = Resources.Load<GameObject>("Thorn");

        CreateThornPool(Thorn, 8, ListObj);

        var patrolpoint = GameObject.Find("CreatePoint");
        if (patrolpoint != null)
            patrolpoint.GetComponentsInChildren<Transform>(ListTr);
        ListTr.RemoveAt(0);
        if (ListTr.Count > 0)
        StartCoroutine(CreatePool(ListObj, ListTr, 1));
    }

    public void CreateThornPool(GameObject Obj, int maxPool, List<GameObject> listObj)
    {
        GameObject objGroup = new GameObject($"{Obj.name}");
        for (int i = 0; i < maxPool; i++)
        {
            var objPool = Instantiate(Obj, objGroup.transform);
            objPool.name = $"{(i + 1).ToString()} °³";
            objPool.SetActive(false);
            listObj.Add(objPool);
        }
    }

    IEnumerator CreatePool(List<GameObject> listObj, List<Transform> listTr, int a)
    {
        while (!GameManager.Instance.IsGameOver)
        {
            if (GameManager.Instance.IsGameOver) break;
            yield return new WaitForSeconds(a);
            foreach (GameObject obj in listObj)
            {
                if (obj.activeSelf == false)
                {
                    int idx = Random.Range(0, listObj.Count - 1);
                    obj.transform.position = listTr[idx].position;
                    obj.transform.rotation = listTr[idx].rotation;
                    obj.gameObject.SetActive(true);
                    break;
                }
                else
                    yield return null;
            }

        }
    }
}
