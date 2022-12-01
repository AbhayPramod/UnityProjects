using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private LineRenderer LineRenderer;
    [SerializeField]
    private Transform Startpoint;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame

    [System.Obsolete]
    void Update()
    {
        LineRenderer.SetColors(Color.red, Color.red);
        LineRenderer.SetPosition(0, Startpoint.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position , -transform.right , out hit))
        {
            if (hit.collider)
            {
                LineRenderer.SetPosition(1, hit.point);
                if (hit.transform.tag == "Player")
                {
                    FindObjectOfType<GameManager>().EndGame();
                }

            }

            
            else LineRenderer.SetPosition(1, -transform.right * 500);
        }
    }
}
