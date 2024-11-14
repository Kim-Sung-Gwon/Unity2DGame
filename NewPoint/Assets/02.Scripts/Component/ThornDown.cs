using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDown : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private float speed;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.DrawRay(tr.position, Vector3.down * 5, Color.red);
        RaycastHit2D ray = Physics2D.Raycast(tr.position, Vector3.down, 5, LayerMask.GetMask("Player"));
        if (ray.collider != null)
        {
            tr.Translate(Vector3.down * speed * Time.deltaTime);
            Debug.Log("°¨Áö");
        }
    }
}
