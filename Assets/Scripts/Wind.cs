using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float MaxSpeed = 5f;
    public float MinSpeed = 1f;

    void Update()
    {

        GameObject bug = GameObject.FindGameObjectWithTag("Bug");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (bug != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, bug.transform.position, MaxSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MinSpeed * Time.deltaTime);
        }
    }
}
