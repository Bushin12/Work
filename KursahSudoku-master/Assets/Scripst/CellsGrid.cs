using UnityEngine;

public class CellsGrid : MonoBehaviour
{
    public static CellsGrid Instance { private set; get; }
    private Cell[,] _grid;

    private void Awake()
    {
        Instance = this;
    }

    public void Inittialize(Cell[,] grid)
    {
        _grid = grid;
    }

    public Cell GetCellByPosition(int x, int y)
    {
        if (_grid.GetLength(0) < x || _grid.GetLength(1) < y)
        {
            throw new System.Exception();
        }
        else
        {
            return _grid[x, y];
        }
    }
}
