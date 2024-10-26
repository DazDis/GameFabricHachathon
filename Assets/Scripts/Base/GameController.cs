using System;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] private HUD _hud;
    [SerializeField] private Bird _bird;
    [SerializeField] private Nest _nest;
    [SerializeField] private Bug _bug;

    public List<BugSpawnPoint> BugSpawnPoints;
    public List<NestSpawnPoint> NestSpawnPoints;

    public Vector3 offset = new Vector3(0, 0, -5);
    public Vector3 CurrentNestPosition;
    private void OnEnable()
    {
        _bird.NeedBug.AddListener(SpawnBug);
        _bird.GetBug.AddListener(GetBug);
    }
    private void OnDisable()
    {
        _bird.NeedBug.RemoveListener(SpawnBug);
        _bird.GetBug.RemoveListener(GetBug);

    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _bird.transform.position + offset, Time.deltaTime * 5f);
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
        _bug.ChangeColor();
        SpawnNest();
    }
    private void SpawnNest()
    {
       
        CurrentNestPosition = _nest.transform.position;
        while (CurrentNestPosition == _nest.transform.position)
            _nest.transform.position = NestSpawnPoints[UnityEngine.Random.Range(0, NestSpawnPoints.Count)].transform.position;


    }
    public void ChangeHealth()
    {
        _hud.ChangeHealth(--_bird.Health);
        if (_bird.Health <= 0) { EndOfGame(); }
    }

    private void EndOfGame()
    {
        throw new NotImplementedException();
    }

}
