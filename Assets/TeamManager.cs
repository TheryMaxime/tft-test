using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    
    public Vector3[] coordinates;
    public GameObject[] mobsArray;
    public int teamNumber;

    private Dictionary<Vector3, GameObject> mobs;
    private List<GameObject> mobsList;

    private void Start()
    {
        this.mobs = new Dictionary<Vector3, GameObject>();
        this.mobsList = new List<GameObject>();
        for (int i = 0; i < this.mobsArray.Length; i++)
        {
            this.mobs.Add(coordinates[i], mobsArray[i]);
            this.mobsList.Add(mobsArray[i]);
        }
    }
    public List<GameObject> getMobs()
    {
        return this.mobsList;
    }

    public void setMobsPosition(Vector3 duelPosition, bool isFirstTeam)
    {
        foreach (KeyValuePair<Vector3, GameObject> mob in this.mobs)
        {
            Vector3 mobCoordinates = isFirstTeam ? duelPosition + mob.Key : duelPosition - mob.Key;
            mobCoordinates += new Vector3(0, 1, 0);
            mob.Value.GetComponent<MobIA>().MoveMob(mobCoordinates);
        }
    }

    public void setEnnemyToEachMobs(List<GameObject> ennemies)
    {
        foreach (GameObject mob in this.mobsList)
        {
            mob.GetComponent<MobIA>().setEnnemies(ennemies);
        }
    }

    public void SwitchStateEachMobs()
    {
        foreach (GameObject mob in this.mobsList)
        {
            mob.GetComponent<MobIA>().switchState();
        }
    }

    
}
