using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MedallionUI : MonoBehaviour
{
    public TextMeshProUGUI medallionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MedallionManager.Instance == null)
        {
            return;
        }

        medallionText.text =
            "x " + MedallionManager.Instance.medallionCount;
    }
}
