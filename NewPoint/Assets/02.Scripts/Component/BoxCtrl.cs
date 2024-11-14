using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // �÷��̾� �±׸� ���� ������Ʈ�� ����
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Enable());
        }
    }

    IEnumerator Enable()
    {
        // 2�� �Ŀ� ������Ʈ ��Ȱ��ȭ
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);

        // Invoke�� ����Ͽ� �Լ� ��ü�� ��ñⰣ�� �ο�
        Invoke("Disable", 3);
    }

    void Disable()
    {
        this.gameObject.SetActive(true);
    }
}
