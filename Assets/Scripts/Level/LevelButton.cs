using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private TextMeshProUGUI levelPassedText;
    [SerializeField] private TextMeshProUGUI levelTimeText;

    private void Awake()
    {
        if(levelData.LevelPassed)
        {
            ShowLevelPassed();
        }
        else
        {
            ShowLevelNotPassed();
        }

        ShowLevelTime();
    }

    public void LoadLevel()
    {
        LevelsLoader.Instance.LoadLevel(levelData);
    }

    private void ShowLevelPassed()
    {
        levelPassedText.text = "�������";
    }
    
    private void ShowLevelNotPassed()
    {
        levelPassedText.text = "�� �������";
    }
    
    private void ShowLevelTime()
    {
        levelTimeText.text = levelData.PassTime.ToString();
    }
}
