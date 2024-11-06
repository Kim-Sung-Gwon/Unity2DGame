using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private PlayerInput playerinput;

    [SerializeField] float TramJump;
    [SerializeField] float UpPower;

    private void Start()
    {
        animator = GetComponent<PlayerAnimator>();
        playerinput = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Thorn"))
        {
            animator.DieAni();
            GameManger.G_Instance.IsGameOver = true;
        }

        if (col.gameObject.CompareTag("Trampolin"))
        {
            int dirY = transform.position.y - col.transform.position.y > 0 ?
                (int)TramJump : -(int)TramJump;
            playerinput.rb.AddForce(new Vector2(0, dirY * TramJump * UpPower), ForceMode2D.Impulse);
            animator.JumpAni(true);
            if (playerinput.JumpCount == 0)
            {
                playerinput.JumpCount++;
            }
        }

        if (col.gameObject.CompareTag("Blink"))
        {
            DiePlayer();
        }
    }

    IEnumerator DiePlayer()
    {
        animator.DieAni();
        yield return new WaitForSeconds(1);
        GameManger.G_Instance.GameOver();
    }
}
