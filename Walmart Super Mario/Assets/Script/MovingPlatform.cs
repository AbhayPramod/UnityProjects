using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    int i = 0;
    public GameObject Player;
    public float objectSpeed = 2f;

    private void Update()
    {
        if (transform.position == points[1].position) i = 0;

        else if(transform.position == points[0].position) i = 1;

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, objectSpeed * Time.deltaTime);

        //else transform.position = Vector3.MoveTowards(transform.position, points[0].position, 2f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
