using Unity.VisualScripting;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float speed = 3;

    public void Start()
    {
        InvokeRepeating("ZombieMove", 1, 1);
    }

    public void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
