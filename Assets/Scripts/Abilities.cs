using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] List<PlanetConfigSO> configSOs;
    [SerializeField] GameObject ButtonLock;
    private float[] oldSpeed;
    private void Start()
    {
        oldSpeed = new float[configSOs.Count];
    }


    public void StopPlanen()
    {
        ButtonLock.SetActive(false);
        for (int i = 0; i < configSOs.Count; i++)
        {
            oldSpeed[i] = configSOs[i].GetMovieSpeed();
            configSOs[i].movieSpeedPlanet = 0;
        }
        StartCoroutine(ResetMovePlanet());
        
    }

    IEnumerator ResetMovePlanet()
    {
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < configSOs.Count; i++)
        {
            configSOs[i].movieSpeedPlanet = oldSpeed[i];
        }
    }
}
