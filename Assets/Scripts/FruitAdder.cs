using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitAdder : MonoBehaviour
{
    
    private Vector3 fruitSpawnPoint = new Vector3(0.335f, 0.03f, 0.316f);
 //   private Animator anim;
    private List<GameObject> createdFruits;
    private Animation anim;
    private List<Color> fruitsColors;
    public GameObject lid;


    public void CreateFruit(GameObject fruitType)
    {
        if (lid.GetComponent<LidBehavior>().isOpen != true)
        {
            GameObject newFruit = Instantiate(fruitType, fruitSpawnPoint, new Quaternion(0, 0, 0, 0));

            newFruit.GetComponent<Animator>().enabled = true;
            newFruit.GetComponent<Transform>().parent = gameObject.transform;
            lid.GetComponent<LidBehavior>().OpenLid();

            createdFruits.Add(newFruit);
            fruitsColors.Add(newFruit.GetComponent<FruitBehavior>().fruitMainColor);
            
        }
           
    }


    public List<Color> GetColorsForMix()
    {
        return fruitsColors;
    }

    public void ClearJug()
    {

        foreach (GameObject obj in createdFruits)
        {
            Destroy(obj);
        }
        
    }

    public void ClearColors()
    {
        fruitsColors.Clear();
    }
    public void BlenderSwing()
    {
        anim.Play("BlenderSwing");
  //      anim.speed = 1;
 //      anim.Play("BlenderSwing",0);
    }
    void Start()
    {
        createdFruits = new List<GameObject>();
        fruitsColors = new List<Color>();
        anim = gameObject.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
