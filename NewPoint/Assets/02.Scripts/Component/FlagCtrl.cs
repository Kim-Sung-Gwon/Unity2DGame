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
        ClearPanel = GameObject.Find("Canvas_JoyStick").transform.GetChild(5).GetComponent<RectTransform>();
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
        yield return new WaitForSeconds(AniClip.length);
        ClearPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
