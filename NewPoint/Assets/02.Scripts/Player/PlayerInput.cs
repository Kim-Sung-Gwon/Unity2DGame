using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private PlayerAnimator playerAni;
    [SerializeField] private SpriteRenderer S_Renderer;
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

        CameraOutLine();
    }

    public void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        moveDir = new Vector2(dir.x * moveSpeed, 0);
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

    void CameraOutLine()
    {
        tr.position = new Vector2(Mathf.Clamp(tr.position.x, -8.5f, 26.5f), tr.position.y);
    }
}
