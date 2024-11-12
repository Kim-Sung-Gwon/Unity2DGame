using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private PlayerAnimator playerAni;
    [SerializeField] private SpriteRenderer S_Renderer;
    [SerializeField] private PlayerDamage playerDamage;
    public Rigidbody2D rb;

    Vector2 moveDir = Vector2.zero;
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] private float jumpPower = 5;

    public int JumpCount;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<PlayerAnimator>();
        S_Renderer = GetComponent<SpriteRenderer>();
        playerDamage = GetComponent<PlayerDamage>();
    }

    void FixedUpdate()
    {
        Vector2 speed = rb.velocity;
        speed.x = moveDir.x;
        rb.velocity = speed;

        if (rb.velocity.y < 0)
        {
            Debug.DrawRay(rb.position, Vector3.down, Color.red);
            RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("Floor", "Box"));
            if (ray.collider != null && ray.distance < 1f)
            {
                playerAni.JumpAni(false);
                JumpCount = 0;
            }

            if (!ray && JumpCount == 0)
            {
                playerAni.JumpAni(true);
                JumpCount++;
            }
        }

        if (playerDamage.isLadder == true)
        {
            speed.y = moveDir.y;
            rb.velocity = speed;
            rb.gravityScale = 0f;
        }
        else if (playerDamage.isLadder == false)
            rb.gravityScale = 1f;
    }

    public void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        moveDir = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
        if (dir.x != 0)
            S_Renderer.flipX = dir.x < 0;
        playerAni.MoveAni(dir);
    }

    public void OnJump()
    {
        if (JumpCount < 2)
        {
            playerAni.JumpAni(true);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            JumpCount++;
            if (JumpCount == 2)
            {
                playerAni.DoubleJumpAni();
            }
        }
    }

    public void CameraOutLine(float min, float max)
    {
        tr.position = new Vector2(Mathf.Clamp(tr.position.x, min, max), tr.position.y);
    }
}
