using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    
    Color levelColor;
    
    
    private List<GameObject> levelButtons;

    public Level()
    {
        levelButtons = new List<GameObject>();
        levelColor = new Color();
    }
    public void AddButton(GameObject button)
    {
        levelButtons.Add(button);
    }

    public void SetLevelColor(Color color)
    {
        levelColor = color;
    }

    public Color GetLevelColor()
    {
        return levelColor;
    }

    public void DestoyLevel()
    {
        foreach (GameObject button in levelButtons)
        {
            button.SetActive(false);
        }
    }
    public void LoadLevel()
    {
        foreach (GameObject button in levelButtons)
        {
            button.SetActive(true);
        }
    }
}
