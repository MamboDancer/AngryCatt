using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float forceValue = 1500f;
    private float minSpeedToDrag = 0.1f;
    private Rigidbody2D rb2d;
    private Camera mainCamera;
    private Vector2 startPosition;
    private bool canDrag = true;

    void Start()
    {
      mainCamera = Camera.main;
      rb2d = GetComponent<Rigidbody2D>();
      rb2d.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
      float playerSpeed = rb2d.velocity.magnitude;
      if(playerSpeed < minSpeedToDrag)
      {
        canDrag = true;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector2.zero;
        startPosition = rb2d.position;
      }
    }


    private void OnMouseUp()
    {
      if(canDrag == true)
      {
        Vector2 currentPosition = rb2d.position;
        Vector2 direction = startPosition - currentPosition;
        rb2d.isKinematic = false;
        rb2d.AddForce(direction * forceValue);
        canDrag = false;
      }
    }

    private void OnMouseDrag()
    {
      if(canDrag)
      {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
      }
    }



}
