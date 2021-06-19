using UnityEngine;

[RequireComponent(typeof(ShipMover), typeof(ShipSinker))]
public class ShipAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string moveName;
    [SerializeField] private string sinkName;

    private ShipMover mover;
    private ShipSinker sinker;

    private void Awake()
    {
        mover = GetComponent<ShipMover>();
        sinker = GetComponent<ShipSinker>();
    }

    private void Update()
    {
        animator.SetBool(sinkName, sinker.IsSinking); 
        animator.SetBool(moveName, mover.IsMoving);
    }
}