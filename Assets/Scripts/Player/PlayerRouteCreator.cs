using System;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
public class PlayerRouteCreator : MonoBehaviour
{ 
    private PlayerTilesFinder finder;
    private PlayerData data;

    private void Awake()
    {
        finder = GetComponent<PlayerTilesFinder>();
        data = GetComponent<PlayerData>();
        finder.TileFound += AddTileToRoute;
    }

    private void AddTileToRoute(Tile tile)
    {
        if(CanAddTile(tile))
        {
            data.PlayerRoute.AddTile(tile);
        }
    }

    public void ResetRoute()
    {
        data.PlayerRoute.ResetRoute();
    }

    private bool CanAddTile(Tile tile)
    {
        return data.PlayerRoute.Empty || (data.PlayerRoute.LastTile.IsTileNeighboor(tile) && !data.PlayerRoute.LastTile.IsChest);
    }
}