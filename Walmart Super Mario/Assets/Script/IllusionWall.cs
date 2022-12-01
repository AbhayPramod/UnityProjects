using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionWall : MonoBehaviour
{
    public GameObject illusionWall;

    private void OnTriggerEnter(Collider other)
    {
        illusionWall.SetActive(false);
    }
}
