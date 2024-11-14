using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Camera cam;
    private Transform player;
    private PlayerInput input;

    private float speed = 5;

    // public�� ������ ������ �� ���� ĳ������ ��ġ�� �¿�� ������ �Ÿ�
    // �� �Ʒ��� ������ �Ÿ��� �ٸ��� ����
    [Header("ī�޶� �¿� �̵�")]
    public float minX;
    public float maxX;

    [Header("ī�޶� ���� �̵�")]
    public float minY;
    public float maxY;

    [Header("�÷��̾� �¿� ������ �Ÿ�")]
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
        // �����̵� ������Ʈ�� ��ġ���� �ּҰ��� �ִ� ���� ��ȯ
        // x ���� �÷��̾� ĳ���Ͱ� x�� �������� �� ��� ������ �� ���󰡴� �Ÿ�
        // y ���� �����̾� ĳ���Ͱ� y�� �������� �� �Ʒ��� ������ �� ���󰡴� �Ÿ�
        Vector3 dirPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY), -10);

        // ī�޶� �÷��̾��� �����ӿ� ���� �����϶� �ε巴�� �����̰� �ϱ�����
        cam.transform.position = Vector3.Lerp(cam.transform.position, dirPos, speed * Time.deltaTime);

        // �ʸ��� �¿��� ��ġ�� �ٸ��� ������
        input.CameraOutLine(left, right);
    }
}
