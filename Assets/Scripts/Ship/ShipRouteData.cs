using System.Collections.Generic;

public class ShipRouteData : Route
{
    public List<Tile> Route { get; set; }

    public override Tile LastTile { get => Route[Route.Count - 1]; }
    public bool Empty { get => Route.Count == 0; }

    private void Awake()
    {
        Route = new List<Tile>(route);
    }

    private void Start()
    {
        CallUpdateRoute();
    }

    public void AddTile(Tile tile)
    {
        Route.Add(tile);
        CallUpdateRoute();
    }

    public void ResetRoute()
    {
        Route.Clear();
        CallUpdateRoute();
    }

    public override Tile[] GetRoute()
    {
        return Route.ToArray();
    }
}