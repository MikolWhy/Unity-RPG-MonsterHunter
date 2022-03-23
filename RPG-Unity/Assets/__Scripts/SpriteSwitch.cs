using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{   
    public int sprite = 0;
    public GameObject player;

    private SpriteRenderer spriteRenderer;

    public Sprite[] newPlayerSprite;

    void Start(){
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (Input.GetKeyDown("f")){
            
            if (sprite == 0){
                ChangeSprite(1);
            }
            else if (sprite == 1){
                ChangeSprite(2);
            }
            else if (sprite == 2){
                ChangeSprite(0);
            }
        }
    }

    // Start is called before the first frame update
    void ChangeSprite(int type){
        print(type);
        spriteRenderer.sprite = newPlayerSprite[type];
        sprite = type;
    }
}
