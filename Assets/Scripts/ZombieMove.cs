using Unity.VisualScripting;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float speed = 3f;
    public float moveDirection;
    public float wobbleTimer = 0.5f;

    public void Start() // Only do this when the spawning happens
    {
        float startX = Random.value < 0.5f ? -13f : 13f; // Set random start position
        transform.position = new Vector3(startX, transform.position.y, transform.position.z); // Define as random start position

        if (transform.position.x > 0.1f)
        {
            moveDirection = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
        } // Check for where they start and then flip their sprite and move direction if they're on the right
        else
        {
            moveDirection = 1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Update()
    {
        transform.position += Vector3.right * moveDirection * speed * Time.deltaTime; // Move the guy based on their move direction at a constant rate
        if (transform.position.x > 14f || transform.position.x < -14f)
            Destroy(gameObject); // Destroy the guy if they go too far

        wobbleTimer -= Time.deltaTime;
        if (wobbleTimer <= 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-15f, 15f));
            wobbleTimer = 0.5f;
        }
    }
}