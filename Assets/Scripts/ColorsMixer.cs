using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsMixer : MonoBehaviour
{
    public GameObject juiceCylinder;

    private List<Color> colors;
    private Color resultColor;
    private Animation anim;

    public void StartMixer()
    {
        LoadColors();

        if (colors.Count != 0)
        {
            MixColors();

            juiceCylinder.GetComponent<Renderer>().material.color = resultColor;
            juiceCylinder.GetComponent<Renderer>().GetComponent<MeshRenderer>().enabled = true;
        }
        
        
    }

    public void ClearMixer()
    {
        resultColor = new Color(0, 0, 0, 0);
        colors.Clear();
    }

    private void MixColors()
    {
        
        foreach (Color c in colors)
        {
            resultColor += c;
        }

        resultColor /= colors.Count;
 //       gameObject.GetComponent<FruitAdder>().ClearColors();
        Debug.Log("Result color:" + resultColor);
    }

    private void LoadColors()
    {
        colors = gameObject.GetComponent<FruitAdder>().GetColorsForMix();
        gameObject.GetComponent<FruitAdder>().ClearJug();
        anim.Play("Mixing");    
    }

    public Color GetResultColor()
    {
        return resultColor;
    }
    void Start()
    {
        resultColor = new Color(0, 0, 0, 0);
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
