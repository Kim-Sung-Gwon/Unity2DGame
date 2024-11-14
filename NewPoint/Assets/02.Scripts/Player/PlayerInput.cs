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
            // ���̸� �Ʒ� �������� ��Ƽ� ���̾ �¾Ҵ��� �Ǵ�
            RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("Floor", "Box"));

            // ���̿� �¾Ұ� �Ÿ��� 1�����϶�
            if (ray.collider != null && ray.distance < 1f)
            {
                playerAni.JumpAni(false);
                JumpCount = 0;
            }

            // ���̿� ���� �ʾҰ� ���� ī��Ʈ�� 0�϶�
            if (!ray && JumpCount == 0)
            {
                playerAni.JumpAni(true);
                JumpCount++;
            }
        }

        // �÷��̾� ������� �ִ� bool ���� ȣ���� ������ �������� �Ǵ�
        if (playerDamage.isLadder == true)
        {
            // bool ���� ���̶�� y���� ����
            speed.y = moveDir.y;
            rb.velocity = speed;

            // isLadder���� ���� �� �߷��� �ۿ�Ǵ� ���� ����
            rb.gravityScale = 0f;
        }
        else if (playerDamage.isLadder == false)
        {
            // �����̶�� �ٽ� �߷��� ����
            rb.gravityScale = 1f;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();

        // �Էµ� x, y���� ���� �̵��� ���� moveSpeed ���� ����
        moveDir = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);

        // dir.x ���� �������� 0�� �ƴϰų� 0�� ���� �Ǵ�
        // 0���� ������ �̹����� �¿� ������ �־���
        if (dir.x != 0) S_Renderer.flipX = dir.x < 0;

        playerAni.MoveAni(dir);
    }

    void OnJump()
    {
        // ���� ī��Ʈ�� 2���� ���� �ʰ� ����
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

    // �ʿ� ���� �÷��̾ �¿�� ������ �ִ� �Ÿ��� �ٸ��� ������ �ٸ� ��ũ��Ʈ���� ȣ�� �ϵ���
    // ���� �������� ����
    public void CameraOutLine(float min, float max)
    {
        tr.position = new Vector2(Mathf.Clamp(tr.position.x, min, max), tr.position.y);
    }
}
