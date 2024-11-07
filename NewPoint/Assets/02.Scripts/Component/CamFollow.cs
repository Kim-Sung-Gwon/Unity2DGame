using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;

    [SerializeField] private float speed = 5;
    [SerializeField] private Vector2 offset;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float camHalfwidth;
    public float camHalfheight;

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
