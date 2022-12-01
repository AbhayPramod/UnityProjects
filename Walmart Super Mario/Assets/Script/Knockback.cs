using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    [SerializeField] public float knockBackStrength;
    public static Rigidbody player;

    public void Update()
    {
        player = Player.RigidbodyComponent;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if( !collision.rigidbody)
        {
            return;
        }
        
        Debug.Log("pushed back");
        Vector3 playerDirection = collision.transform.position - transform.position;
        float x = playerDirection.x * knockBackStrength;
        player.velocity = Vector3.zero;

        player.transform.DOLocalMove(new Vector3(playerDirection.x  , 5f , 0f) , 0.25f);
        //player.AddForce(x, 5, 0, ForceMode.Impulse);
    }
}
