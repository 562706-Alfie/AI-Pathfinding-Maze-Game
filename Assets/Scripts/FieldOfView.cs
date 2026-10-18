using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    public PlayerSO player1Data;
    public Transform aimTransform;
    public LayerMask obstacleMask;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate()
    {
        Vector3 origin = Vector3.zero;

        int rayCount = 50;
        float angle = aimTransform.eulerAngles.z - player1Data.fov / 2f;
        float angleIncrease = player1Data.fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 direction = UtilsClass.GetVectorFromAngle(angle);

            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                direction,
                player1Data.viewDistance,
                obstacleMask
            );

            Vector3 vertex;

            if (hit.collider != null)
            {
                vertex = hit.point - (Vector2)transform.position;
            }
            else
            {
                vertex = direction * player1Data.viewDistance;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex;
                triangles[triangleIndex + 2] = vertexIndex - 1;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle += angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
    }
}
