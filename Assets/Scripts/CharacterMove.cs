using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterMove : MonoBehaviour
{

    public float movementSpeed;

    public Animator animator;

    public Text text;

    public static int berryCount;

    public GameObject gameOverPanel;


    void Start ()
    {
        gameOverPanel.SetActive(false);
        animator = GetComponent<Animator>();
        berryCount = 0;
    }
	

	void Update ()
    {
        PlayerWalk();
        PlayerChangeDirection();
        text.text = "Berries: " + berryCount;

        if(berryCount == 10)
        {
            gameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    private void PlayerChangeDirection()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
    }

    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Walking", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 
                                               Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime ));
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "marja" && other.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
        {
            Destroy(other.gameObject);
            Counting();
        }  
    }


    private void Counting()
    {
        berryCount++;
    }
}
