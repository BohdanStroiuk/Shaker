using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [SerializeField]
    private List<Color> levelColors;

    private int levelCounter;

    private List<Level> levels;

    [SerializeField]
    public List<GameObject> buttons;

    [SerializeField]
    private GameObject nextLvlButton;

    public Text levelText;
    public Text completeText;

    public GameObject targetJuice;
    public GameObject resultJuice;

    
    private int completePercent;

    void Start()
    {
        levels = new List<Level>();
        levelCounter = 0;
        LoadUI();
        
 //       Debug.Log("Target Color " + levelColor);
    }

    void LoadUI()
    {
        completePercent = 0;
        completeText.text = "Complete: " + completePercent + " %";
        levelText.text = "Level " + (levelCounter + 1);
        InitLevels();
        levels[levelCounter].LoadLevel();
        
        targetJuice.GetComponent<Renderer>().material.color = levels[levelCounter].GetLevelColor();
        resultJuice.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        resultJuice.GetComponent<Renderer>().GetComponent<MeshRenderer>().enabled = false;
    }

    void InitLevels()
    {

        levels.Add(new Level());
        levels.Add(new Level());
        levels.Add(new Level()); 

        levels[0].SetLevelColor(levelColors[0]);
        levels[0].AddButton(buttons[0]);
        levels[0].AddButton(buttons[1]);

        
        levels[1].SetLevelColor(levelColors[1]);
        levels[1].AddButton(buttons[0]);
        levels[1].AddButton(buttons[2]);
        levels[1].AddButton(buttons[3]);

        
        levels[2].SetLevelColor(levelColors[2]);
        levels[2].AddButton(buttons[4]);
        levels[2].AddButton(buttons[5]);
        levels[2].AddButton(buttons[6]);
    }

    public float CompareColors()
    {
        float rDelta, gDelta, bDelta, aDelta;

        Color resultColor = resultJuice.GetComponent<Renderer>().material.color;
        float resultPer = 0;

        rDelta = Mathf.Abs(resultColor.r - levels[levelCounter].GetLevelColor().r) / levels[levelCounter].GetLevelColor().r * 100;
        gDelta = Mathf.Abs(resultColor.g - levels[levelCounter].GetLevelColor().g) / levels[levelCounter].GetLevelColor().r * 100; 
        bDelta = Mathf.Abs(resultColor.b - levels[levelCounter].GetLevelColor().b) / levels[levelCounter].GetLevelColor().r * 100; 
        aDelta = Mathf.Abs(resultColor.a - levels[levelCounter].GetLevelColor().a) / levels[levelCounter].GetLevelColor().r * 100; 

        resultPer = 100 - (rDelta + gDelta + bDelta + aDelta) / 4;
        if (resultPer < 0) resultPer = 0;

        return 100 - (rDelta + gDelta + bDelta + aDelta) / 4;
    }

    public void UpdateComplete()
    {
        completePercent = System.Convert.ToInt32(CompareColors());
        completeText.text = "Complete: " + completePercent + " %";

        if (completePercent >= 90) NextLevel();

    }

    void NextLevel()
    {
        levels[levelCounter].DestoyLevel();
        if (levelCounter <2 ) nextLvlButton.SetActive(true);
        
    }

    public void UpdateLevel()
    {
       
        levelCounter++;
        LoadUI();
        nextLvlButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
