using System.Collections.Generic;
using UnityEngine;


public class Bug : MonoBehaviour
{
    public List<SpriteRenderer> bugList;
    private int _currentSprite;
    private void Awake()
    {
        _currentSprite = Random.Range(0, bugList.Count);
        bugList[_currentSprite].gameObject.SetActive(true);
    }


    public void ChangeColor()
    {
        bugList[_currentSprite].gameObject.SetActive(false);
        _currentSprite = Random.Range(0, bugList.Count);
        bugList[_currentSprite].gameObject.SetActive(true);

    }
}
