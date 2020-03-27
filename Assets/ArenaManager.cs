using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArenaManager : MonoBehaviour
{
    public GameObject cellPrefab;

    private Dictionary<Vector3, CellManager> cells;
    private float cellSizeX;
    private float cellSizeZ;
    private readonly float cellXFactor = 0.75f;
    private readonly float cellZFactor = 1f;
    private Vector3 worldCoordinates;

    private void OnEnable()
    {
        this.worldCoordinates = this.gameObject.transform.position;
        //this.cells = new Dictionary<Vector3, CellManager>();
    }

    public Vector3 getWorldCoordinates()
    {
        return this.worldCoordinates;
    }

    public void Start()
    {
        this.SpawnFirstCell();
        this.SpawnAllCells();
    }

    private void SpawnFirstCell()
    {
        /*
        Vector3 originCoordinates = new Vector3();
        this.cells.Add(originCoordinates, new CellManager());
        this.cells[originCoordinates].m_Instance = Instantiate(this.cellPrefab, this.worldCoordinates, new Quaternion());
        this.cellSizeX = this.cells[originCoordinates].m_Instance.GetComponent<Renderer>().bounds.size.x * this.cellXFactor;
        this.cellSizeZ = this.cells[originCoordinates].m_Instance.GetComponent<Renderer>().bounds.size.z * this.cellZFactor;
        */
        GameObject cell = Instantiate(this.cellPrefab, this.worldCoordinates, new Quaternion());
        Renderer cellRenderer = cell.GetComponentInChildren<Renderer>();
        this.cellSizeX = cellRenderer.bounds.size.x * this.cellXFactor;
        this.cellSizeZ = cellRenderer.bounds.size.z * this.cellZFactor;
    }

    private void SpawnCell(Vector3 coordinates, Quaternion basicQuaternion, bool pair)
    {
        Vector3 realCoordinates;
        if (pair)
        {
            realCoordinates = this.worldCoordinates + new Vector3(this.cellSizeX * coordinates.x, 0, this.cellSizeZ * coordinates.z);
        } else
        {
            realCoordinates = this.worldCoordinates + new Vector3(this.cellSizeX * coordinates.x, 0, this.cellSizeZ * (coordinates.z + 0.5f));
        }
        GameObject cell = Instantiate(this.cellPrefab, realCoordinates, basicQuaternion);
        cell.transform.SetParent(this.gameObject.transform);
    }

    private void SpawnAllCells()
    {
        Quaternion basicQuaternion = new Quaternion();
        bool pair = true;
        for(int x = -4; x <= 4; x++)
        {
            for(int z = -5; z <= 4; z++)
            {
                if (!(x == 0 && z == 0))
                {
                    if (pair)
                    {
                        if (z > -5)
                        {
                            this.SpawnCell(new Vector3(x, 0, z), basicQuaternion, pair);
                        }
                    } else
                    {
                        this.SpawnCell(new Vector3(x, 0, z), basicQuaternion, pair);
                    }
                }
            }
            pair = !pair;
        }
    }
}
