using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{
    [Range(0.01f, 10f)] 
    public float speed = 10.0f;
    
    // Update is called once per frame
    void Update() {
        Vector2 movement = new Vector2(Input.acceleration.x, Input.acceleration.y);
        // clamp acceleration vector to the unit sphere
        if(movement.sqrMagnitude > 1)movement.Normalize();
        // Make it move 10 meters per second instead of 10 meters per frame...
        movement *= Time.deltaTime * speed;// Move object
        transform.Translate(movement);
    }
}
