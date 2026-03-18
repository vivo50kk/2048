using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour
{
    public Vector2Int coordingates { get; set; }
    public Tile tile { get; set; }
    public bool empty => tile == null;
    public bool occupied => tile != null;

    public static float cellSize { get; private set; }

    private void Awake()
    {
        cellSize = GetComponent<RectTransform>().rect.width;
    }
}
