using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformMovementHorizontal : MonoBehaviour
{
    public float speed = 1; 

    public List<Transform> wayPoints;

    public int indexNextWaypoint;

    public float minDistance;

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[indexNextWaypoint].position, step);

        if (Vector3.Distance(transform.position, wayPoints[indexNextWaypoint].position) < minDistance)
        {
            indexNextWaypoint++;
            if (indexNextWaypoint >= wayPoints.Count)
            {
                indexNextWaypoint = 0;
            }
        }
    }
}
