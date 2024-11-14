using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    private Transform PlayerTr;
    private Transform SpawnPoint;

    private void Awake()
    {
        SpawnPoint = transform;
        PlayerTr = Resources.Load<Transform>("Player");

        Createplayer();
    }

    public void Createplayer()
    {
        // ���۽� �÷��̾� ĳ���Ͱ� ������ ��ġ
        Instantiate(PlayerTr, SpawnPoint.position, SpawnPoint.rotation);
    }

}
