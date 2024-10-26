using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Nest _nest;
    [SerializeField] private Bug _bug;

    List<BugSpawnPoint> BugSpawnPoints;
    List<NestSpawnPoint> NestSpawnPoints;
    private void OnEnable()
    {
        _nest.NeedBug.AddListener(SpawnBug);
        _bird.GetBug.AddListener(GetBug);
    }
    private void OnDisable()
    {
        _nest.NeedBug.RemoveListener(SpawnBug);
        _bird.GetBug.RemoveListener(GetBug);

    }

    private void SpawnBug()
    {
       _bird.Comebacking = false;
        _bug.gameObject.SetActive(true);
        _bug.transform.position = BugSpawnPoints[UnityEngine.Random.Range(0, BugSpawnPoints.Count)].transform.position; 
    }
    private void GetBug()
    {
        _bird.Comebacking = true;
        _bug.gameObject.SetActive(false);
        SpawnNest();
    }
    private void SpawnNest()
    {
        _nest.transform.position = NestSpawnPoints[UnityEngine.Random.Range(0, NestSpawnPoints.Count)].transform.position;


    }
}
