using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

//Script básico para cálcular campo de "visão" do jogador
//A ideia principal desse script será utilizar em conjunto com o campo de visão de inimigos para criar combate mais avançado para certos inimigos.
public class FieldOfView : MonoBehaviour
{
    public float viewRadius;

    public LayerMask obstacleMask;

    public List<Vector3Int> visibleCells = new List<Vector3Int>();

    public Tilemap tilemap;
    public Grid grid;

    void Update()
    {
        FindVisibleCells();
    }

    void FindVisibleCells()
    {
        visibleCells.Clear();

        int startX = Mathf.FloorToInt(transform.position.x - viewRadius);
        int endX = Mathf.CeilToInt(transform.position.x + viewRadius);
        int startY = Mathf.FloorToInt(transform.position.y - viewRadius);
        int endY = Mathf.CeilToInt(transform.position.y + viewRadius);

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                Vector3 cellWorldPosition = grid.CellToWorld(cellPosition) + grid.cellSize / 2;

                if (IsWithinViewRadius(cellWorldPosition) && IsVisible(cellWorldPosition))
                {
                    visibleCells.Add(cellPosition);
                }
            }
        }
    }

    bool IsWithinViewRadius(Vector3 point)
    {
        return Vector3.Distance(transform.position, point) <= viewRadius;
    }

    bool IsVisible(Vector3 point)
    {
        Vector3 direction = (point - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, point);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);
        return !hit;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Gizmos.color = Color.green;
        foreach (Vector3Int cell in visibleCells)
        {
            Vector3 cellWorldPosition = grid.CellToWorld(cell) + grid.cellSize / 2;
            Gizmos.DrawSphere(cellWorldPosition, 0.2f);
        }
    }
}
