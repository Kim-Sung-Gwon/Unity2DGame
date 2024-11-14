using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Camera cam;
    private Transform player;
    private PlayerInput input;

    private float speed = 5;

    // public을 선언한 이유는 맵 마다 캐릭터의 위치와 좌우로 움직일 거리
    // 위 아래로 움직일 거리가 다르기 때문
    [Header("카메라 좌우 이동")]
    public float minX;
    public float maxX;

    [Header("카메라 상하 이동")]
    public float minY;
    public float maxY;

    [Header("플레이어 좌우 움직임 거리")]
    public float left;
    public float right;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        input = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    void Update()
    {
        // 기준이될 오브젝트의 위치에서 최소값과 최대 값을 반환
        // x 값은 플레이어 캐릭터가 x축 기준으로 좌 우로 움직일 때 따라가는 거리
        // y 값은 츨레이어 캐릭터가 y축 기준으로 위 아래로 움직일 때 따라가는 거리
        Vector3 dirPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY), -10);

        // 카메라가 플레이어의 움직임에 따라 움직일때 부드럽게 움직이게 하기위해
        cam.transform.position = Vector3.Lerp(cam.transform.position, dirPos, speed * Time.deltaTime);

        // 맵마다 좌우의 위치가 다르기 때문에
        input.CameraOutLine(left, right);
    }
}
