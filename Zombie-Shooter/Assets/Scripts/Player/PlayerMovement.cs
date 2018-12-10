﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;
    public float gravity = -9.8f;

    private CharacterController _charCont;

     void Start()
    {
        _charCont = GetComponent<CharacterController>();
    }

     void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //limits the max speed of the player

        movement.y = gravity;
        

        movement *= Time.deltaTime; // time.deltaTime Ensures the speed the player moves does not change based on frame rate
        movement = transform.InverseTransformDirection(movement);
        _charCont.Move(movement);
    }
}
