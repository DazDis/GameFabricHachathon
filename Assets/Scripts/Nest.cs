using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nest : MonoBehaviour
{

    // [SerializeField] private GameController _gameController;
    public UnityEvent NeedBug;
    private void OnCollisionEnter(Collision collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null )
        {
            if (bird.Comebacking) 
            {
                
                NeedBug.Invoke();
            }
        }
    }
}
