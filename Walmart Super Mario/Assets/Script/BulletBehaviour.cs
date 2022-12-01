using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Transform[] points;
    int i = 0;
    public float bulletSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position == points[0].position) 
            i = 1;

        else if (transform.position == points[1].position)
            transform.position = points[0].position;
        

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, bulletSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("shot hit");
            transform.position = points[0].position;
            FindObjectOfType<Player>().TakeDamage(20);
        }
        
    }
}
