using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public GameObject myKey;
    public bool canJump = false;

    private Vector3 myScale;
    private bool hasKey = false;
    

    // Start is called before the first frame update
    void Start()
    {
        myScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("canJump", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            MovementRight();
        }else if(Input.GetAxis("Horizontal") < 0)
        {
            MovementLeft();
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("canRun", false);
        }
    }

    public void Jump()
    {
        gameObject.GetComponent<Animator>().SetBool("canJump", true);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

    }

    public void MovementRight()
    {
        myScale.x = 1;
        gameObject.transform.localScale = myScale;
        gameObject.GetComponent<Animator>().SetBool("canRun", true);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    public void MovementLeft()
    {
        myScale.x = -1;
        gameObject.transform.localScale = myScale;
        gameObject.GetComponent<Animator>().SetBool("canRun", true);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BlackHole")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(col.tag == "Key")
        {
            hasKey = true;
            Debug.Log("Has Key");
            myKey.SetActive(false);
            
        }

        if(col.tag == "WhiteHole")
        {
            if (hasKey) {
                
                if(SceneManager.GetActiveScene().name == "SampleScene 1") {
                    SceneManager.LoadScene(0);
                }
                else { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
                }
        }

        if (col.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
