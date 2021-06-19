using System.Collections.Generic;

public class Waypoints
{
    private List<Waypoint> waypoints;

    public Waypoints()
    {
        waypoints = new List<Waypoint>();
    }
    
    public int Count { get => waypoints.Count; }   

    public Waypoint GetWaypointAt(int index)
    {
        return waypoints[index];
    }

    public void AddWaypoint(Waypoint waypoint)
    {
        Waypoint current = GetExistingWaypoint(waypoint); 
        Waypoint previous = GetLastWaypoint();

        
        if(previous != null)
        {
            current.AddDirection(current.Tile.GetNeighboorDirection(previous.Tile));
            previous.AddDirection(previous.Tile.GetNeighboorDirection(current.Tile));
        }

        waypoints.Add(current);
    }

    private Waypoint GetExistingWaypoint(Waypoint waypoint)
    {
        Waypoint result = waypoints.Find((i) => i.Tile == waypoint.Tile);

        if (result != null) return result;

        return waypoint;
    }

    private Waypoint GetLastWaypoint()
    {
        if(waypoints.Count != 0)
        {
            return waypoints[waypoints.Count - 1];
        }

        return null;
    }
}