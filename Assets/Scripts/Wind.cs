using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {

        GameObject bug = GameObject.FindGameObjectWithTag("Bug");
        if (bug != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, bug.transform.position, speed * Time.deltaTime);
        }
    }
}
