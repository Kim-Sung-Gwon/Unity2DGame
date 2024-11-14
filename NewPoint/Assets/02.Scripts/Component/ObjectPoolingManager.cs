using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance;

    [SerializeField] private GameObject Thorn;
    [SerializeField] private List<GameObject> GameObjList = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        Thorn = Resources.Load<GameObject>("Thorn");

        CreateThornPool(Thorn, 4, GameObjList);
    }

    void Start()
    {
        StartCoroutine(CreatePool(2, 4));
    }

    void CreateThornPool(GameObject g_obj, int maxPool, List<GameObject> g_objList)
    {
        GameObject obj = new GameObject($"{g_obj.name}");
        for (int i = 0; i < maxPool; i++)
        {
            var objPool = Instantiate(g_obj, obj.transform);
            objPool.name = $"{(i + 1).ToString()} °³";
            objPool.SetActive(false);
            g_objList.Add(objPool);
        }
    }

    IEnumerator CreatePool(float minTime, float maxTime)
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        //GameManager.Instance.ReCreateObject("CreatePoints-1", Thorn);
    }
}
