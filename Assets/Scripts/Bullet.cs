using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed at which the bullet moves upward
    public float speed = 5f;
    // Time in seconds before the bullet is automatically destroyed
    public float lifeTime = 3f;

    void Start()
    {
        // Schedule the bullet to be destroyed after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet upward each frame
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
