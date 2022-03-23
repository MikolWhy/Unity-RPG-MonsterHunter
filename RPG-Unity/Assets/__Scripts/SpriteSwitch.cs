using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer spriteRenderer;

    public Sprite[] newPlayerSprite;

    void Start(){
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (Input.GetKeyDown("f")){
            if (Input.GetKeyDown("1")){
                ChangeSprite(0);
            }
            else if (Input.GetKeyDown("2")){
                ChangeSprite(1);
            }
        }
    }

    // Start is called before the first frame update
    void ChangeSprite(int type){
        spriteRenderer.sprite = newPlayerSprite[type];
    }
}
