using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDown : MonoBehaviour
{
    public Collider2D Col;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // 감지된 오브젝트
        {
            // 감지된 오브젝트가 아래에서 위로 올라갈 때 특정 오브젝트의 콜라이더를 무시
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), Col, true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), Col, false);
        }
    }
}
