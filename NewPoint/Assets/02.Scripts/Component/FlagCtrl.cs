using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip AniClip;
    [SerializeField] private RectTransform ClearPanel;

    private readonly int check = Animator.StringToHash("CheckTrigger");

    void Start()
    {
        animator = GetComponent<Animator>();
        AniClip = Resources.Load<AnimationClip>("Animation/ChechpointStart Animation");
        ClearPanel = GameObject.Find("Canvas").transform.GetChild(5).GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger(check);
            StartCoroutine(AniClick());
        }
    }

    IEnumerator AniClick()
    {
        // 애니메이션 클립의 시간 만큼 대기
        yield return new WaitForSeconds(AniClip.length);
        ClearPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
