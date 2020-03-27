using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour
{
    public TeamManager[] teams;
    public ArenaManager arena;

    private bool isOn;

    private void OnEnable()
    {
        this.isOn = false;
    }

    private void EnableEnnemies()
    {
        teams[0].setEnnemyToEachMobs(teams[1].getMobs());
        teams[1].setEnnemyToEachMobs(teams[0].getMobs());
    }

    private void PlaceMobs()
    {
        bool isFirstTeam = true;
        foreach (TeamManager team in this.teams)
        {
            team.setMobsPosition(this.arena.getWorldCoordinates(), isFirstTeam);
            isFirstTeam = false;
        }
    }

    private void EnableMobs()
    {
        foreach (TeamManager team in this.teams)
        {
            team.SwitchStateEachMobs();
        }
    }

    private void Start()
    {
        this.PlaceMobs();
        this.EnableEnnemies();
        this.EnableMobs();
    }
}
