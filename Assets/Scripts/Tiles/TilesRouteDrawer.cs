using UnityEngine;
using System.Collections.Generic;

public class TilesRouteDrawer : MonoBehaviour
{
    [SerializeField] private Route route;

    private TilesWaypointsDrawer drawer;

    private List<Transform> wayshowers;

    private void Awake()
    {
        drawer = GetComponent<TilesWaypointsDrawer>();
        route.SubsribeOnRouteUpdates(DrawRoute);
        wayshowers = new List<Transform>();
    }

    public void DrawRoute(Tile[] tiles)
    {
        if (tiles == null || tiles.Length == 0)
        {
            ClearWayshowers();
            return;
        }

        Waypoints waypoints = new Waypoints();

        for (int i = 0; i < tiles.Length; i++)
        {
            waypoints.AddWaypoint(new Waypoint(tiles[i]));
        }

        ClearWayshowers();

        for (int i = 0; i < waypoints.Count; i++)
        {
            Transform wayshower = drawer.DrawWaypointShower(waypoints.GetWaypointAt(i));
            wayshowers.Add(wayshower);
        }
    }

    private void ClearWayshowers()
    {
        if (wayshowers == null || wayshowers.Count == 0) return;

        for (int i = 0; i < wayshowers.Count; i++)
        {
            if(wayshowers[i] != null)
            {
                Destroy(wayshowers[i].gameObject);
            }   
        }

        wayshowers.Clear();
    }
}