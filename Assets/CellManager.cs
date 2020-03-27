using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public Transform m_SpawnPoint;
    [HideInInspector] public GameObject m_Instance;

    public float getRendererSizeX()
    {
        return this.gameObject.GetComponentInChildren<Renderer>().bounds.size.x;
    }

    public float getRendererSizeZ()
    {
        return this.gameObject.GetComponentInChildren<Renderer>().bounds.size.z;
    }
}
