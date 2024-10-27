using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRotation : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
