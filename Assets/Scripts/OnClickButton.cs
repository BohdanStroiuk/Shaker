using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickButton : MonoBehaviour
{
    [SerializeField]
    UnityEvent anEvent;

    private void OnMouseDown()
    {
        anEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
