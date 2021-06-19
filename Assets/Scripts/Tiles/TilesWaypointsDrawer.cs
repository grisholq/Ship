using UnityEngine;

public class TilesWaypointsDrawer : MonoBehaviour
{
    private TilesWayshowersFactory factory;

    private const int directionsSum = 7;

    private void Awake()
    {
        factory = GetComponent<TilesWayshowersFactory>();
    }

    public Transform DrawWaypointShower(Waypoint waypoint)
    {
        if (waypoint.Directions.Count == 1)
        {
            return DrawOneDirection(waypoint.Tile, waypoint.Directions[0]);
        }
        else if (waypoint.Directions.Count == 2)
        {
            return DrawTwoDirections(waypoint.Tile, waypoint.Directions.ToArray());
        }
        else if (waypoint.Directions.Count == 3)
        {
            return DrawThreeDirections(waypoint.Tile, waypoint.Directions.ToArray());
        }
        else if (waypoint.Directions.Count == 4)
        {
            return DrawFourDirections(waypoint.Tile);
        }

        return null;
    }

    private Transform DrawOneDirection(Tile tile, Direction direction)
    {
        Transform shower = factory.GetRoute(direction);

        shower.SetParent(tile.transform);
        shower.localPosition = Vector3.zero;

        return shower;
    }

    private Transform DrawTwoDirections(Tile tile, Direction[] directions)
    {
        int first = (int)directions[0];
        int second = (int)directions[1];

        if (Mathf.Abs(first - second) == 2)
        {
            return DrawOneDirection(tile, (Direction)first);
        }

        int min = Mathf.Min(first, second);
        int max = Mathf.Max(first, second);

        Transform shower;

        if (min == 0 && max == 3)
        {
            shower = factory.GetCorner((Direction)max);
        }
        else
        {
            shower = factory.GetCorner((Direction)min);
        }

        shower.SetParent(tile.transform);
        shower.localPosition = Vector3.zero;

        return shower;
    }

    private Transform DrawThreeDirections(Tile tile, Direction[] directions)
    {
        int dir = directionsSum;

        for (int i = 0; i < directions.Length; i++)
        {
            dir -= (int)directions[i];
        }

        Transform shower = factory.GetCross3((Direction)dir);

        shower.SetParent(tile.transform);
        shower.localPosition = Vector3.zero;

        return shower;
    }

    private Transform DrawFourDirections(Tile tile)
    {
        Transform shower = factory.GetCross();

        shower.SetParent(tile.transform);
        shower.localPosition = Vector3.zero;

        return shower;
    }
}
