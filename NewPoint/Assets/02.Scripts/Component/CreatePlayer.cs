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
        // 시작시 플레이어 캐릭터가 생성될 위치
        Instantiate(PlayerTr, SpawnPoint.position, SpawnPoint.rotation);
    }

}
