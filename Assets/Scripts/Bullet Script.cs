
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;

    private Vector2 moveDirection;
    private void Start()
    {
        // The bullet travels along its local right axis.
        moveDirection = transform.right;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position +=
            (Vector3)(moveDirection * speed * Time.deltaTime);
    }
}
