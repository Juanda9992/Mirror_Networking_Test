using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown_UI : MonoBehaviour
{
    [SerializeField] private GameObject finishObj;

    void Start()
    {
        finishObj.SetActive(false);        
    }
    private void DisplayFinishUI()
    {
        finishObj.SetActive(true);
    }
    void OnEnable()
    {
        Crown.OnCrownGrabbed += DisplayFinishUI;        
    }

    void OnDisable()
    {
        Crown.OnCrownGrabbed -= DisplayFinishUI;        
    }
}
