using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjects : MonoBehaviour
{
    private int health = 10;
    private Transform spawnPoint;
    private Rigidbody2D rb2d;


    void Start()
    {
      spawnPoint = GameObject.Find("SpawnPoint").transform;
      rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }


    private void Damage(int value)
    {
      rb2d.velocity = Vector2.zero;
      rb2d.angularVelocity = 0;
      rb2d.isKinematic = true;
      transform.position = spawnPoint.position;
      health -= value;
      if(health <= 0)
      {
        Debug.Log("Game Over!");
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Obstacle"))
      {
        Damage(other.GetComponent<ObstacleSettings>().damageValue);
      }
    }


}
