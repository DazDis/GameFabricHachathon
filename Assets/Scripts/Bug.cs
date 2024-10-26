using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bug : MonoBehaviour
{
    public UnityEvent GetBug;
    private void OnCollisionEnter(Collision collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            if (!bird.Comebacking)
            {
                GetBug.Invoke();
            }
        }
    }
}
