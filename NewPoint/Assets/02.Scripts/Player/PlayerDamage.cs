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
            // 자신의 y값을 변환 하기 위해
            // 자기자신.y 값 - 감지한 콜라이더의 y값 > 0 ? (int)점프 : -(int)점프;
            // (int)점프를 한 이유는 선언한 점프는 float값이기 때문에 float값을 int로 변환하기 위해 선언
            int dirY = transform.position.y - col.transform.position.y > 0 ? (int)TramJump : -(int)TramJump;

            // ForceMode2D.Impulse : 리디지 바디에 주어지는 충격량과 힘의 크기, 주는 시간을 곱한 수치
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
        // simulated를 비활성화 함으로서 리디지 바디로 움직이는 값을 비활성화함
        playerinput.rb.simulated = false;
        animator.DieAni();
        //GameManager.Instance.Diecount();
        yield return new WaitForSeconds(animator.clip.length);
        gameObject.SetActive(false);

        // 지정 위치에서 자신을 활성화함
        //GameManager.Instance.ReCreateObject("SpawnPoint", tr);
        ReCreateObject("SpawnPoint", tr);
        playerinput.JumpCount = 0;
        // 리디지 바디를 다시 활성화
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
