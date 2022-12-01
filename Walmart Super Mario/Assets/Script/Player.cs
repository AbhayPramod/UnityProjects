using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform groundCheck;
    private bool JumpKeyWasPressed;
    public static Rigidbody RigidbodyComponent;
    private float HorizontalInput;
    private int SuperJumpCheck;
    public float Speed = 2f;
    public bool Boosting;

    public HealthBar healthbar;
    public int maxHealth = 100;
    public static int currentHealth;
    public float JumpPower;



    // Start is called before the first frame update
    void Start()
    {
        RigidbodyComponent = GetComponent<Rigidbody>();
        
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyWasPressed = true;
            //TakeDamage(20);
        }
        HorizontalInput = Input.GetAxis("Horizontal");



    }

    private void FixedUpdate()
    {
        if (RigidbodyComponent.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }


        //MOVEMENT HERE
        RigidbodyComponent.velocity = new Vector3(HorizontalInput * Speed, RigidbodyComponent.velocity.y, 0);

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Physics.OverlapSphere(groundCheck.position , 0.1f).Length == 1)
        {
            return;
        }


        if (JumpKeyWasPressed)
        {

            JumpPower = 5f;

            if (SuperJumpCheck > 0)
            {
                JumpPower *= 2;
                SuperJumpCheck--;
                
            }
            RigidbodyComponent.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
            JumpKeyWasPressed = false;

        }

    }

    public void Jump()
    {
       
        RigidbodyComponent.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
        //RigidbodyComponent.velocity = new Vector3(0, JumpPower, 0);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.Sethealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
            SuperJumpCheck++;
            
            

        }

        if (other.gameObject.layer == 6)
        {
            Speed = 10f;
            StartCoroutine(BoostTimer());
            Destroy(other.gameObject);

        }

        if (other.gameObject.layer == 7)
        {
            FindObjectOfType<GameManager>().LevelClear();
        }

        if (other.CompareTag("Portal"))
        {
            SceneManager.LoadScene("SecretLevel");
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            Debug.Log("taking damage");
            FindObjectOfType<Player>().TakeDamage(20);
            
        }

        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(1f);
        Speed = 2f;
    }
}
