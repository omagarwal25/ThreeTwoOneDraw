using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer rendr;

    private float count = 0;
    public float speed =10;
    //editable in Unity Engine
    void Start(){
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = sprites[0];
    }
    // Update is called once per frame
    void Move(double x,double y, int animNumber)
    {   
        //create unit vector
        double x_and_y_Squared = Math.Pow(x, 2.0) + Math.Pow(y, 2.0);
        double a = x / Math.Sqrt(x_and_y_Squared);
        double b = y / Math.Sqrt(x_and_y_Squared);
        float i = (float)a;
        float j = (float)b;
        Vector3 unitVector = new Vector3(i, j);
        //move bill in direction of unit vector * distance
        gameObject.transform.position += unitVector* (speed * Time.deltaTime);
        //speed * time is distance! 
        rendr.sprite = sprites[animNumber]; //use sprite
        walkingSound();
    }
    void Update()
    {
        // I want to create a movement script that takes less space

        double horizontal = Input.GetAxisRaw("Horizontal"); //returns value from -1 to 1
        double vertical = Input.GetAxisRaw("Vertical"); //returns value from -1 to 1
        // getting x and y coordinates of direction
          
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(horizontal, vertical, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(horizontal, vertical, 2);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(horizontal, vertical, 3);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(horizontal, vertical, 1);

        }
        

    }

    private void walkingSound(){
        if(!SoundManager.audioSource.isPlaying){
            SoundManager.playSound(SoundType.WildWestWalking);
            count = 10f;
        }
        else{
            count -= 0.01f;
        }
    }
}
