using Assets.Scripts.DataModels;
using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Grid;
using Assets.Scripts.Helpers;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MeshFilter _MeshFilter;
    [SerializeField] private TMP_Text _Text;
    [SerializeField] private Color _Color;
    [SerializeField] private Transform _ObjectContainer;

    private GridManager _grid;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;
    private MeshRenderer _renderer;
    private GridCellData _cellData;

    public void Setup(GridCellData cellData, GridManager grid)
    {
        _grid = grid;
        _cellData = cellData;
        _cellData.CellDataChanged += CellDataChanged;

        _MeshFilter.mesh = _mesh = new Mesh();

        Vector3 position = new()
        {
            x = _cellData.Position.Q * (HexMetrics.outerRadius * 1.5f),
            y = 0f,
            z = (_cellData.Position.R + _cellData.Position.Q * .5f) * (HexMetrics.innerRadius * 2f)
        };

        _renderer = _MeshFilter.GetComponent<MeshRenderer>();
        Color.RGBToHSV(_Color, out float h, out float s, out float v);
        Color newColor = Color.HSVToRGB(h, s + Random.Range(-.1f, .1f), v + Random.Range(-.1f, .1f));
        _renderer.material.color = newColor;

        MeshCollider collider = _MeshFilter.GetComponent<MeshCollider>();
        collider.sharedMesh = _mesh;

        Trianglulate();

        transform.position = position;
        _Text.text = _cellData.Position.ToString();

        if(_cellData.ObjectData != null)
        {
            CellObjectConfig cellObjectConfig = Context.GameConfig.CellObjects.SingleOrDefault(o => o.ObjectName == _cellData.ObjectData.ObjectName);
            if(cellObjectConfig != null)
            {
                CellObject cellObject = Instantiate(cellObjectConfig.ObjectPrefab, _ObjectContainer);
                cellObject.Setup(_cellData.ObjectData);
            }
        }
    }

    private void OnEnable()
    {
        if(_cellData != null)
            _cellData.CellDataChanged += CellDataChanged;
    }

    private void OnDisable()
    {
        if (_cellData != null)
            _cellData.CellDataChanged -= CellDataChanged;
    }

    private void Trianglulate()
    {
        _vertices = new Vector3[18];
        _triangles = new int[18];

        for(int i=0; i<6; i++)
        {
            _vertices[3 * i] = new Vector3(0f, 0f, 0f);
            _vertices[3 * i + 1] = new Vector3(HexMetrics.corners[i].x, 0f, HexMetrics.corners[i].z);
            _vertices[3 * i + 2] = new Vector3(HexMetrics.corners[(i + 1) % 6].x, 0f, HexMetrics.corners[(i + 1) % 6].z);
            _triangles[3 * i] = 3 * i;
            _triangles[3 * i + 1] = 3 * i + 1;
            _triangles[3 * i + 2] = 3 * i + 2;
        }
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _grid.MoveCameraTo(transform.position);
        //TODO Move somewhere to GameManager
        {
            BuildingData buildingData = new BuildingData(Context.GameConfig.Buildings[0]);
            _grid.AddCellObject(_cellData.Position, buildingData);
        }
    }

    private void CellDataChanged(object sender, CellDataChangedEventArgs e)
    {
        if (_cellData.ObjectData != null && _ObjectContainer.childCount == 0)
        {
            CellObjectConfig cellObjectConfig = Context.GameConfig.CellObjects.SingleOrDefault(o => o.ObjectName == _cellData.ObjectData.ObjectName);
            if (cellObjectConfig != null)
            {
                CellObject cellObject = Instantiate(cellObjectConfig.ObjectPrefab, _ObjectContainer);
                cellObject.Setup(_cellData.ObjectData);
            }
        }
    }
}
