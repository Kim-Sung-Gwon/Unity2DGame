using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCtrl : MonoBehaviour
{
    private Transform tr;
    [SerializeField] private float speed = 10;
    [SerializeField] private List<Transform> patrolpoints = new List<Transform>();

    public int wayPointcount = 0;

    void Start()
    {
        tr = transform;
        //GameManager.Instance.ListPoint("WayPoint-1", patrolpoints);
        ListPoint("WayPoint-1", patrolpoints);
    }

    public void ListPoint(string name, List<Transform> points)
    {
        var patrolpoint = GameObject.Find(name);
        if (patrolpoint != null)
            patrolpoint.GetComponentsInChildren<Transform>(points);
        points.RemoveAt(0);
    }

    void Update()
    {
        if (patrolpoints.Count == 0) return;

        // 목표 지점
        Vector3 targetPos = patrolpoints[wayPointcount].position;

        // 목표 지점의 위치
        Vector3 point = new Vector3(targetPos.x, targetPos.y);
        Vector3 pointdir = point - tr.position;

        // 이동 방향
        Vector3 moveDir = new Vector3(pointdir.x, pointdir.y).normalized;
        tr.Translate(moveDir * speed * Time.deltaTime, Space.World);

        // 목표 지점 까지의 거리 계산
        float dir = Vector3.Distance(new Vector3(tr.position.x, tr.position.y), new Vector3(targetPos.x, targetPos.y));
        
        // 목표 지점에 도달 했을 경우 다음 목표지점으로 이동하기 위한 조건
        if (dir <= 0.1f)
            wayPointcount = (wayPointcount + 1) % patrolpoints.Count;  // 순환 구조

        #region 코드 최적화로 줄이기 전
        //Vector3 Pointdir = Vector3.zero;
        //float dir = 0;
        //if (wayPointcount == 0)
        //{
        //    Vector3 point2D = new Vector3(patrolpoints[0].position.x, patrolpoints[0].position.y, tr.position.z);
        //    Pointdir = point2D - tr.position;
        //    Vector3 moveDir = new Vector3(Pointdir.x, Pointdir.y).normalized;
        //    tr.Translate(moveDir * speed * Time.deltaTime, Space.World);
        //    dir = Vector3.Distance(new Vector3(tr.position.x, tr.position.y),
        //        new Vector3(patrolpoints[0].position.x, patrolpoints[0].position.y));
        //    if (dir <= 0.1f)
        //        wayPointcount = 1;
        //}
        //else if (wayPointcount == 1)
        //{
        //    Vector3 point2D = new Vector3(patrolpoints[1].position.x, patrolpoints[1].position.y, tr.position.z);
        //    Pointdir = point2D - tr.position;
        //    Vector3 moveDir = new Vector3(Pointdir.x, Pointdir.y).normalized;
        //    tr.Translate(moveDir * speed * Time.deltaTime, Space.World);
        //    dir = Vector3.Distance(new Vector3(tr.position.x, tr.position.y),
        //        new Vector3(patrolpoints[1].position.x, patrolpoints[1].position.y));
        //    if (dir <= 0.1f)
        //        wayPointcount = 2;
        //}
        //else if (wayPointcount == 2)
        //{
        //    Vector3 point2D = new Vector3(patrolpoints[2].position.x, patrolpoints[2].position.y, tr.position.z);
        //    Pointdir = point2D - tr.position;
        //    Vector3 moveDir = new Vector3(Pointdir.x, Pointdir.y).normalized;
        //    tr.Translate(moveDir * speed * Time.deltaTime, Space.World);
        //    dir = Vector3.Distance(new Vector3(tr.position.x, tr.position.y),
        //        new Vector3(patrolpoints[2].position.x, patrolpoints[2].position.y));
        //    if (dir <= 0.1f)
        //        wayPointcount = 3;
        //}
        //else if (wayPointcount == 3)
        //{
        //    Vector3 point2D = new Vector3(patrolpoints[3].position.x, patrolpoints[3].position.y, tr.position.z);
        //    Pointdir = point2D - tr.position;
        //    Vector3 moveDir = new Vector3(Pointdir.x, Pointdir.y).normalized;
        //    tr.Translate(moveDir * speed * Time.deltaTime, Space.World);
        //    dir = Vector3.Distance(new Vector3(tr.position.x, tr.position.y),
        //        new Vector3(patrolpoints[3].position.x, patrolpoints[3].position.y));
        //    if (dir <= 0.1f)
        //        wayPointcount = 0;
        //}
        #endregion
    }
}
