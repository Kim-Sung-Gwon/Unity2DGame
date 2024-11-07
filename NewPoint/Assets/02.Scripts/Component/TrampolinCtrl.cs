using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinCtrl : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Animator animator;

    private readonly int T_jump = Animator.StringToHash("TramTrigger");

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger(T_jump);
        }
    }
}
