using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCtrl : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private AnimationClip AnimationClip;

    private readonly int collect = Animator.StringToHash("ColTrigger");

    private void Start()
    {
        Animator = GetComponent<Animator>();
        AnimationClip = Resources.Load<AnimationClip>("Animation/Collected Animation");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Animator.SetTrigger(collect);
            GameManger.G_Instance.ColCount();
            StartCoroutine(CountCOl());
        }
    }

    IEnumerator CountCOl()
    {
        yield return new WaitForSeconds(AnimationClip.length);
        Destroy(this.gameObject);
    }
}
