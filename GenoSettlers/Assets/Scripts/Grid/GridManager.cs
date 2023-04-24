using Assets.Scripts.DataModels;
using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour, IGridManager
{
    [SerializeField] GridCell _CellPrefab;

    [SerializeField] Transform _CellsContainer;

    [SerializeField] CameraController _CameraController;

    private Dictionary<GridPosition, GridCellData> _gridCells = new Dictionary<GridPosition, GridCellData>();

    public void Setup(int width, int height)
    {
        int widthOffset = width / 2;
        int heightOffset = height / 2 - width / 4;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GridPosition position = GridPosition.FromOffsetCoordinates(i - widthOffset, j - heightOffset);
                GridCellData cellData = new GridCellData(position);
                _gridCells.Add(position, cellData);

                if (position.DistanceTo(0, 0, 0) > 2 && Random.Range(0, 1f) < 0.9f)
                {
                    AddCellObject(position, new CellObjectData("Forest"));
                }
            }
        }

        ResourcesStackData resourcesStack = new ResourcesStackData();
        resourcesStack.ChangeResourceAmount(1, 16);
        _gridCells[new GridPosition(0,0)].AddCellObject(resourcesStack);

        foreach (GridCellData gridCellData in _gridCells.Values)
        {
            GridCell cell = Instantiate(_CellPrefab, _CellsContainer);
            cell.Setup(gridCellData,this);
        }
    }

    public void MoveCameraTo(Vector3 targetPostion)
    {
        _CameraController.MoveCameraTo(targetPostion);
    }

    public void AddCellObject(GridPosition position, CellObjectData cellObjectData)
    {
        _gridCells[position].AddCellObject(cellObjectData);
    }
}
