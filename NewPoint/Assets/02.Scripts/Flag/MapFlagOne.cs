using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFlagOne : MonoBehaviour
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
        if (col.gameObject.CompareTag("Player") && GameManager.Instance.Count >= 4)
        {
            Animator.SetTrigger(collect);
            StartCoroutine(CountCOl());
            GameManager.Instance.ColCount();
        }
    }

    IEnumerator CountCOl()
    {
        yield return new WaitForSeconds(AnimationClip.length);
        Destroy(this.gameObject);
    }
}
