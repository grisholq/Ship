using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerData))]
public class PlayerUIActivator : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button resetButton;

    private PlayerData data;

    private void Awake()
    {
        data = GetComponent<PlayerData>();
    }

    private void Update()
    {
        SetPlayButtonActivity();
        SetResetButtonActivity();
    }

    private void SetPlayButtonActivity()
    {
        if (playButton == null) return;

        if (!data.PlayerRoute.Empty && data.PlayerRoute.LastTile.IsChest)
        {
            playButton.enabled = true;
        }
        else
        {
            playButton.enabled = false;
        }
    }
    
    private void SetResetButtonActivity()
    {
        if (resetButton == null) return;

        if (!data.PlayerRoute.Empty)
        {
            resetButton.enabled = true;
        }
        else
        {
            resetButton.enabled = false;
        }
    }
}