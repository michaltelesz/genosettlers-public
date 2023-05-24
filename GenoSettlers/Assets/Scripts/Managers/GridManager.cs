using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour, IGridManager
{
    [SerializeField] GridCell _CellPrefab;

    [SerializeField] Transform _CellsContainer;

    [SerializeField] CameraController _CameraController;

    private Dictionary<GridPosition, GridCellData> _gridCells = new Dictionary<GridPosition, GridCellData>();
    private int _width, _height;
    private int _widthOffset => Mathf.FloorToInt(_width / 2f);
    private int _heightOffset => Mathf.FloorToInt(_height / 2f);

    public void Init(int width, int height)
    {
        _width = width;
        _height = height;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GridPosition position = GridPosition.FromOffsetCoordinates(i - _widthOffset, j - _heightOffset);
                GridCellData cellData = new GridCellData(position);
                _gridCells.Add(position, cellData);
            }
        }

        foreach (GridCellData gridCellData in _gridCells.Values)
        {
            GridCell cell = Instantiate(_CellPrefab, _CellsContainer);
            cell.Setup(gridCellData, this);
        }

        Populate();
    }

    private void Populate()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                GridPosition position = GridPosition.FromOffsetCoordinates(i - _widthOffset, j - _heightOffset);
                if (position.DistanceTo(0, 0, 0) > 3 && Random.Range(0, 1f) < 0.9f)
                {
                    AddCellObject(new CellObjectData(position, "Forest"));
                }
            }
        }
    }

    public void MoveCameraTo(Vector3 targetPostion)
    {
        _CameraController.MoveCameraTo(targetPostion);
    }

    public void AddCellObject(CellObjectData cellObjectData)
    {
        _gridCells[cellObjectData.Position].AddCellObject(cellObjectData);
    }

    public void RemoveCellObject(GridPosition position)
    {
        _gridCells[position].RemoveCellObject();
    }

    public bool HasGridObject(GridPosition gridPosition)
    {
        _gridCells.TryGetValue(gridPosition, out GridCellData cellObject);
        if(cellObject == null || cellObject.ObjectData == null)
            return false;

        return true;
    }
}
