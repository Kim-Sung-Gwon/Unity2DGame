using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 플레이어 태그를 가진 오브젝트를 감지
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Enable());
        }
    }

    IEnumerator Enable()
    {
        // 2초 후에 오브젝트 비활성화
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);

        // Invoke를 사용하여 함수 자체에 대시기간을 부여
        Invoke("Disable", 3);
    }

    void Disable()
    {
        this.gameObject.SetActive(true);
    }
}
