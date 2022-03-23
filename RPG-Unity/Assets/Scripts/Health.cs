using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 3)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = true;
            hearts[2].enabled = true;
        }
        if (health == 2)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = true;
            hearts[2].enabled = false;
        }
        if (health == 1)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
        }
        if (health == 0)
        {
            hearts[0].enabled = false;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
    }
}
