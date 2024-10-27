using System.Collections.Generic;
using UnityEngine;


public class Bug : MonoBehaviour
{
    public List<SpriteRenderer> bugList;
    public int CurrentSprite;
    private void Awake()
    {
        CurrentSprite = Random.Range(0, bugList.Count);
        bugList[CurrentSprite].gameObject.SetActive(true);
    }


    public void ChangeColor()
    {
        bugList[CurrentSprite].gameObject.SetActive(false);
        CurrentSprite = Random.Range(0, bugList.Count);
        bugList[CurrentSprite].gameObject.SetActive(true);

    }
}
