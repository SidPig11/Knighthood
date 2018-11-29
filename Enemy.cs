using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody2D enemy2D;
    public float UnitsToMove = 5;
    public float EnemySpeed = 1;
    Transform enemy;
    public bool m_isFacingRight;
    private float m_startPos;
    private float m_endPos;
    


    // Use this for initialization
    void Start()
    {
        enemy = this.transform;
        enemy2D = GetComponent<Rigidbody2D>();
        m_startPos = transform.position.x;
        m_endPos = m_startPos + UnitsToMove;
        m_isFacingRight = transform.localScale.x > 0;
    }
 
    void FixedUpdate()
    {
        Vector2 Speed = enemy2D.velocity;
        Speed.x = -enemy.right.x * EnemySpeed;
        enemy2D.velocity = Speed;
    }

    public int health = 100;
  
    public GameObject Death;


    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject ps = (GameObject)Instantiate(Death, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(ps, 0.6f);
    }
}
