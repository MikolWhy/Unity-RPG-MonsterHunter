using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCombat : Health
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            return;
        }

        Destroy(collision.gameObject);
        health += 1;
    }
}
