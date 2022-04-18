using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{

    public Color fruitMainColor;

    public void DisableAnimatoion()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponentInParent<FruitAdder>().lid.GetComponent<LidBehavior>().CloseLid();
        gameObject.GetComponentInParent<FruitAdder>().BlenderSwing();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
