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
    public float moveSpeed = 4;
    public float jumpPower = 5;

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
            // 레이를 아래 방향으로 쏘아서 레이어에 맞았는지 판단
            RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("Floor", "Box"));

            // 레이에 맞았고 거리가 1이하일때
            if (ray.collider != null && ray.distance < 1f)
            {
                playerAni.JumpAni(false);
                JumpCount = 0;
            }

            // 레이에 맞지 않았고 점프 카운트가 0일때
            if (!ray && JumpCount == 0)
            {
                playerAni.JumpAni(true);
                JumpCount++;
            }
        }

        // 플레이어 대미지에 있는 bool 값을 호출해 참인지 거짓인지 판단
        if (playerDamage.isLadder == true)
        {
            // bool 값이 참이라면 y값을 적용
            speed.y = moveDir.y;
            rb.velocity = speed;

            // isLadder값이 참일 때 중력이 작용되는 것을 방지
            rb.gravityScale = 0f;
        }
        else if (playerDamage.isLadder == false)
        {
            // 거짓이라면 다시 중력을 적용
            rb.gravityScale = 1f;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();

        // 입력된 x, y축의 값에 이동을 위해 moveSpeed 값을 곱함
        moveDir = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);

        // dir.x 축을 기준으로 0이 아니거나 0일 때를 판단
        // 0보다 작으면 이미지의 좌우 반전을 넣어줌
        if (dir.x != 0) S_Renderer.flipX = dir.x < 0;

        playerAni.MoveAni(dir);
    }

    void OnJump()
    {
        // 점프 카운트를 2보다 많지 않게 제한
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

    // 맵에 따라서 플레이어가 좌우로 움직일 최대 거리가 다르기 때문에 다른 스크립트에서 호출 하도록
    // 값을 지정하지 않음
    public void CameraOutLine(float min, float max)
    {
        tr.position = new Vector2(Mathf.Clamp(tr.position.x, min, max), tr.position.y);
    }
}
