using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 2.0f, dashSpeed = 7.0f;
    public Rigidbody2D rb;
    public Camera cam;


    public Joystick joystick;

    public Joystick joystick2; 

    public Shooting shooting;

    //Vector2 movement;
    Vector2 mousePosition;


    public float startMoveSpeed = 5.0f;
    public static Vector2 Position;
    public float moveSmooth = .3f;
    Vector2 movement = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    private Scene scene;
    //Vector2 mousePos = Vector2.zero;



    // Use this for initialization
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        if (scene.name == "Medium")
        {
            moveSpeed = moveSpeed * 1.25f;
        }
        else if (scene.name == "Hard")
        {
            moveSpeed = moveSpeed * 1.5f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");


        movement.x = joystick.Horizontal * moveSpeed;
        movement.y = joystick.Vertical * moveSpeed;
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        //===================PLAYER MOVEMENT===================

        Vector2 desiredVelocity = movement * moveSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);
        Position = rb.position;

        //===================ROTATION WITH MOUSE===================

        //Vector2 facingDirection = mousePosition - rb.position
        //float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        var x = joystick2.Horizontal; 
        var y = joystick2.Vertical;

        if (x != 0.0 || y != 0.0)
        {
            float angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg - 90f;
            //transform.rotation = Quaternion.AngleAxis(90.0f - angle, Vector3.up);
            rb.rotation = angle;

            //float nextTimeToFire = 0.5f;
            //if (Time.time >= nextTimeToFire) { 
                shooting.Shoot();
                //nextTimeToFire = Time.time + 1f / 1;
            //}

        }




    }





}
