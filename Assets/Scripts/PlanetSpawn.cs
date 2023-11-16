using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    [SerializeField] public PlanetConfigSO WaveConfigs;
    void Start()
    {
        SpawnPlanetWaves();
    }

    void SpawnPlanetWaves()
    {

        Instantiate(WaveConfigs.GetPlanetPrefab(),
                WaveConfigs.GetStartingWaypoint().position,
                Quaternion.identity,
                transform);
    }

}
