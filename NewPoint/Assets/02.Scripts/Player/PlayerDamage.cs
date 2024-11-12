using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private Transform tr;

    public float TramJump;
    public float UpPower;

    public bool isLadder;

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

        if (col.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Blink") || col.gameObject.CompareTag("Thorn") || col.gameObject.CompareTag("DieZone"))
        {
            StartCoroutine(DiePlayer());
        }
    }

    IEnumerator DiePlayer()
    {
        animator.DieAni();
        GameManager.Instance.Diecount();
        yield return new WaitForSeconds(animator.clip.length);
        gameObject.SetActive(false);
        GameManager.Instance.ReCreateObject("SpawnPoint", tr);
        playerinput.JumpCount = 0;
    }
}
