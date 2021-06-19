using System;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] protected Tile startingTile;
    [SerializeField] protected Tile[] route;

    public event Action<Tile[]> RouteUpdated;
    public virtual Tile LastTile { get; set; }

    public void SubsribeOnRouteUpdates(Action<Tile[]> action)
    {
        RouteUpdated += action;
    }

    public virtual Tile[] GetRoute()
    {
        return null;
    }

    protected void CallUpdateRoute()
    {
        if (RouteUpdated != null) RouteUpdated(GetRoute());
    }
}