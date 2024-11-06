using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int Check = Animator.StringToHash("CheckBool");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetBool(Check, true);
        }
    }
}
