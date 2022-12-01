using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 1f);
            
        }

       
    }
    public void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
