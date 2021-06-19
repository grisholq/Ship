using UnityEngine;
using UnityEngine.Events;

public class ShipCollisionEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent enemyShipHit;
    [SerializeField] private UnityEvent chestHit;
    
    private void OnCollisionEnter(Collision collision)
    {
        CheckChestHit(collision);
        CheckEnemyShipHit(collision);
    }

    private void CheckChestHit(Collision collision)
    {
        if(collision.gameObject.GetComponent<Chest>() != null)
        {
            if(chestHit != null)
            {
                chestHit.Invoke();
            }
        }
    }

    private void CheckEnemyShipHit(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyShip>() != null)
        {
            if (enemyShipHit != null)
            {
                enemyShipHit.Invoke();
            }
        }
    }
}