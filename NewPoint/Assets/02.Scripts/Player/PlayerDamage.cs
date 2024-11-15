using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private Transform tr;

    public float TramJump = 2;
    public float UpPower = 3;

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
            // �ڽ��� y���� ��ȯ �ϱ� ����
            // �ڱ��ڽ�.y �� - ������ �ݶ��̴��� y�� > 0 ? (int)���� : -(int)����;
            // (int)������ �� ������ ������ ������ float���̱� ������ float���� int�� ��ȯ�ϱ� ���� ����
            int dirY = transform.position.y - col.transform.position.y > 0 ? (int)TramJump : -(int)TramJump;

            // ForceMode2D.Impulse : ������ �ٵ� �־����� ��ݷ��� ���� ũ��, �ִ� �ð��� ���� ��ġ
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
        if (col.gameObject.CompareTag("Blink") || col.gameObject.CompareTag("Thorn")
            || col.gameObject.CompareTag("DieZone") || col.gameObject.CompareTag("On"))
        {
            StartCoroutine(DiePlayer());
        }
    }

    IEnumerator DiePlayer()
    {
        // simulated�� ��Ȱ��ȭ �����μ� ������ �ٵ�� �����̴� ���� ��Ȱ��ȭ��
        playerinput.rb.simulated = false;
        animator.DieAni();
        //GameManager.Instance.Diecount();
        yield return new WaitForSeconds(animator.clip.length);
        gameObject.SetActive(false);

        // ���� ��ġ���� �ڽ��� Ȱ��ȭ��
        //GameManager.Instance.ReCreateObject("SpawnPoint", tr);
        ReCreateObject("SpawnPoint", tr);
        playerinput.JumpCount = 0;
        // ������ �ٵ� �ٽ� Ȱ��ȭ
        playerinput.rb.simulated = true;
    }

    public void ReCreateObject(string objName, Transform obj)
    {
        Transform objPoint = GameObject.Find(objName).transform;
        if (obj.gameObject.activeSelf == false)
        {
            obj.transform.position = objPoint.position;
            obj.transform.rotation = objPoint.rotation;
            obj.gameObject.SetActive(true);
        }
    }
}
