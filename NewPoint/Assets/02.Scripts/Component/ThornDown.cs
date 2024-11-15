using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDown : MonoBehaviour
{
    [SerializeField] private Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("DieZone") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(""))
        {
            this.gameObject.SetActive(false);
        }
    }
}
