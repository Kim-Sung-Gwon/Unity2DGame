using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilnkDown : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float DownSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.DrawRay(rb.position, Vector3.down * 20, Color.red);
        RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector3.down, 20, LayerMask.GetMask("Player"));
        if (ray.collider != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 1500;
        }
    }
}
