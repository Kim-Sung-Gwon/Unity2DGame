using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;

    [SerializeField] private float speed = 5;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float minX = 0;
    [SerializeField] private float maxX = 18;
    [SerializeField] private float minY = 0;
    [SerializeField] private float maxY = 20;
    [SerializeField] private float camHalfwidth = 0;
    [SerializeField] private float camHalfheight = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 dirPos = new Vector3(Mathf.Clamp(player.position.x + offset.x, minX + camHalfwidth, maxX - camHalfwidth),
            Mathf.Clamp(player.position.y + offset.y, minY + camHalfheight, maxY - camHalfheight), -10);

        cam.transform.position = Vector3.Lerp(cam.transform.position, dirPos, speed * Time.deltaTime);
    }
}
