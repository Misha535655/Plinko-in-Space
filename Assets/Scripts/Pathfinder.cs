using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{   
    public PlanetConfigSO planetConfig;
    List<Transform> waypoints;
    int waypointIndex;

    void Awake()
    {
    }

    void Start()
    {
        waypoints = planetConfig.GetWaypoint();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FolowPath();
    }

    void FolowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = planetConfig.GetMovieSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition){
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }

    }
}
