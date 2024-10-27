using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private HUD _hud;
    [SerializeField] private Bird _bird;
    [SerializeField] private Nest _nest;
    [SerializeField] private Bug _bug;
    [SerializeField] private Tip _tip;

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
        if (_bird.CountOfBugs == 0) _tip.CloseTips();
        _hud.ChangeBug(++_bird.CountOfBugs);

        if (_bird.CountOfBugs == 20)
        {
            SceneManager.LoadScene("Ending");
        }

        _bird.BugSprite.gameObject.SetActive(false);
        _bird.Comebacking = false;
        _bug.gameObject.SetActive(true);
        _bug.transform.position = BugSpawnPoints[UnityEngine.Random.Range(0, BugSpawnPoints.Count)].transform.position;
        ChangeHealth();

    }
    private void GetBug()
    {

        _bird.Comebacking = true;
        _bird.BugSprite.sprite = _bird.BugSprites[_bug.CurrentSprite];
        _bird.BugSprite.gameObject.SetActive(true);


        _bug.gameObject.SetActive(false);
        _bug.ChangeColor();

        
        SpawnNest();
    }
    private void SpawnNest()
    {
        if (_bird.CountOfBugs == 0) _tip.Maketip3();

        CurrentNestPosition = _nest.transform.position;
        while (CurrentNestPosition == _nest.transform.position)
            _nest.transform.position = NestSpawnPoints[UnityEngine.Random.Range(0, NestSpawnPoints.Count)].transform.position;


    }
    public void ChangeHealth()
    {
       
        _hud.ChangeHealth(60);
        if (_hud.HealthSlider.value <= 0) { EndOfGame(); }
    }

    private void EndOfGame()
    {
        throw new NotImplementedException();
    }

}
