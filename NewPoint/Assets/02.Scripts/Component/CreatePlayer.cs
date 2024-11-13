using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] private Transform PlayerTr;
    [SerializeField] private Transform SpawnPoint;

    private void Awake()
    {
        SpawnPoint = transform;
        PlayerTr = Resources.Load<Transform>("Player");

        Createplayer();
    }

    public void Createplayer()
    {
        Instantiate(PlayerTr, SpawnPoint.position, SpawnPoint.rotation);
    }

}
