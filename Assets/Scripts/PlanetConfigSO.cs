using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Planet Config", fileName = "New Planet Config")]
public class PlanetConfigSO : ScriptableObject 
{
    [SerializeField] public Transform pathPrefab; 
    [SerializeField] public GameObject planet;
    public float movieSpeedPlanet = 10;
    //public float timeBetweenEnemySpawns = 1f;
    //public float spawnTimeVariants = 0f;
    //public float minimumSpawnTime = 0.2f;



    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoint()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMovieSpeed()
    {
        return movieSpeedPlanet;
    }

    public GameObject GetPlanetPrefab()
    {
        return planet;
    }

   /* public float GetRandomSpawnTime()
    {
         float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariants, 
                                        timeBetweenEnemySpawns + spawnTimeVariants);
        
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }*/
}
