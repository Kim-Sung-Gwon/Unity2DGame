using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private Transform tr;

    [SerializeField] float TramJump;
    [SerializeField] float UpPower;

    private void Start()
    {
        animator = GetComponent<PlayerAnimator>();
        playerinput = GetComponent<PlayerInput>();
        tr = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Trampolin"))
        {
            int dirY = transform.position.y - col.transform.position.y > 0 ? (int)TramJump : -(int)TramJump;
            playerinput.rb.AddForce(new Vector2(0, dirY * TramJump * UpPower), ForceMode2D.Impulse);
            animator.JumpAni(true);
            if (playerinput.JumpCount == 0)
            {
                playerinput.JumpCount++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Blink"))
        {
            StartCoroutine(DiePlayer());
        }

        if (col.gameObject.CompareTag("Thorn"))
        {
            StartCoroutine(DiePlayer());
        }
    }

    IEnumerator DiePlayer()
    {
        animator.DieAni();
        GameManager.Instance.Diecount();
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        GameManager.Instance.ReCreatePlayer("SpawnPoint", tr);
        playerinput.JumpCount = 0;
    }
}
