using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tile right;
    [SerializeField] private Tile left;
    [SerializeField] private Tile up;
    [SerializeField] private Tile down;

    [SerializeField] private bool isChest;

    public bool IsChest { get => isChest; }

    public Tile GetTileByDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return up;

            case Direction.Right:
                return right;

            case Direction.Down:
                return down;

            case Direction.Left:
                return left;

            default:
                return null;
        }
    }  

    public Direction GetNeighboorDirection(Tile neighboor)
    {
        if (neighboor == up) return Direction.Up;
        else if (neighboor == right) return Direction.Right;
        else if (neighboor == down) return Direction.Down;
        else if (neighboor == left) return Direction.Left;

        return default(Direction);
    }
    
    public bool IsTileNeighboor(Tile neighboor)
    {
        return neighboor == right || neighboor == left || neighboor == up || neighboor == down;
    }
}