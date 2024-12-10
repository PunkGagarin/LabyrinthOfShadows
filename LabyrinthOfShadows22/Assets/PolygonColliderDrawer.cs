using UnityEngine;

[ExecuteAlways] // Чтобы отрисовывать и в режиме редактирования
public class PolygonColliderDrawer : MonoBehaviour
{
    public Color gizmoColor = Color.green;
    private PolygonCollider2D polygonCollider;

    void OnDrawGizmos()
    {
        if (polygonCollider == null)
            polygonCollider = GetComponent<PolygonCollider2D>();
        
        if (polygonCollider == null) return;

        Gizmos.color = gizmoColor;

        // PolygonCollider2D может содержать несколько контуров (Path)
        // Например, если есть "дыры" в коллайдере
        for (int i = 0; i < polygonCollider.pathCount; i++)
        {
            Vector2[] points = polygonCollider.GetPath(i);
            int len = points.Length;

            for (int j = 0; j < len; j++)
            {
                Vector2 current = transform.TransformPoint(points[j]);
                Vector2 next = transform.TransformPoint(points[(j + 1) % len]);
                Gizmos.DrawLine(current, next);
            }
        }
    }
}