using System.Collections.Generic;

public class Waypoint
{
    public Tile Tile { get; set; }
    public List<Direction> Directions;

    public Waypoint(Tile tile)
    {
        Tile = tile;
        Directions = new List<Direction>(4);
    }

    public void AddDirection(Direction direction)
    {
        if (Directions.Contains(direction)) return;
        Directions.Add(direction);
    }
}