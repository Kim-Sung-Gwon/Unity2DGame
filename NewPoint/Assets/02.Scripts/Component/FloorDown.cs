using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDown : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // 플레이어 태그를 가진 오브젝트를 검사
        if (col.gameObject.CompareTag("Player"))
        {
            // 리디지 바디의 타입 변경 후 무게 추가
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 2500f;
        }
    }
}
