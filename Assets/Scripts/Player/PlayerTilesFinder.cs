using System;
using UnityEngine;

public class PlayerTilesFinder : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private int tilesLayer;

    public event Action<Tile> TileFound;

    private PlayerInputer inputer;

    private void Awake()
    {
        inputer = GetComponent<PlayerInputer>();
        inputer.InputRecieved += FindNextTile;
    }

    private void FindNextTile(Vector3 screenPosition)
    {
        Ray ray = camera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, tilesLayer, QueryTriggerInteraction.Ignore))
        {
            if (TileFound != null) TileFound(hit.transform.GetComponent<Tile>());
        }
    }
}