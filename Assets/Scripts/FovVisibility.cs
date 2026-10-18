
using UnityEngine;

public class VisionVisibility : MonoBehaviour
{
    public Transform player;
    public Transform aimTransform;
    public PlayerSO player1Data;

    public LayerMask obstacleMask;

    private SpriteRenderer[] spriteRenderers;
    private Collider2D enemyCollider;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
        enemyCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (player == null || aimTransform == null || player1Data == null)
            return;

        // Find the point on the enemy we want to see.
        Vector2 origin = player.position;
        Vector2 target = enemyCollider != null
            ? enemyCollider.bounds.center
            : (Vector2)transform.position;

        Vector2 direction = target - origin;
        float distance = direction.magnitude;

        // Check viewing distance.
        bool inRange = distance <= player1Data.viewDistance;

        // Check whether the enemy is inside the viewing angle.
        float angle = Vector2.Angle(aimTransform.right, direction);
        bool inFOV = angle <= player1Data.fov / 2f;

        // Check whether a wall blocks the view.
        bool hasLineOfSight = false;

        if (inRange && inFOV)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                direction.normalized,
                distance,
                obstacleMask
            );

            hasLineOfSight = hit.collider == null;
        }

        // Show or hide all sprites belonging to this enemy.
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            sprite.enabled = hasLineOfSight;
        }
    }
}
