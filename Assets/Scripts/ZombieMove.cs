using Unity.VisualScripting;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float speed = 3f;
    public float moveDirection;

    public void Start()
    {
        float startX = Random.value < 0.5f ? -13f : 13f;
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);

        if (transform.position.x > 0.1f)
        {
            moveDirection = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x < -0.1f)
        {
            moveDirection = 1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Update()
    {
        transform.position += Vector3.right * moveDirection * speed * Time.deltaTime;
        if (transform.position.x > 14f || transform.position.x < -14f)
            Destroy(gameObject);
    }
}