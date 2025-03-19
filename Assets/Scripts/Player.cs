using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int health;
    [SerializeField] private int bullets = 50;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -10f; // maximum left position
    [SerializeField] private float maxX = 10f;  // maximum right position

    [Header("Shooting")]
    [SerializeField] private float shootDelay = 0.2f; // delay between shots in seconds
    private float nextShootTime = 0f;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnTransform;

    void Update()
    {
        #region MOVEMENT
            // Get horizontal input (-1 for left, 1 for right)
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate new X position and clamp it between minX and maxX
            float newX = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;
            newX = Mathf.Clamp(newX, minX, maxX);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // Update animator's "direction" parameter based on input
            if (horizontalInput > 0.1f)
            {
                animator.SetFloat("direction", 10f);
            }
            else if (horizontalInput < -0.1f)
            {
                animator.SetFloat("direction", -10f);
            }
            else
            {
                animator.SetFloat("direction", 0f);
            }
        #endregion MOVEMENT

        #region SHOOTING
            // Allow holding down the fire button, but only shoot after a delay
            if (Input.GetButton("Fire") && Time.time >= nextShootTime)
            {
                Shoot();
                nextShootTime = Time.time + shootDelay;
            }
        #endregion SHOOTING
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
    }

    void TakeDamage()
    {
        health--;

        if (health <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over!");
    }
}
