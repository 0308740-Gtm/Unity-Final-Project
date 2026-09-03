using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedallionManager : MonoBehaviour
{

    public static MedallionManager Instance;

    public int medallionCount = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMedallion()
    {
        medallionCount++;

        Debug.Log("Medallions: " + medallionCount);
    }

    public bool UseMedallion()
    {
        if (medallionCount <= 0)
        {
            return false;
        }

        medallionCount--;

        Debug.Log("Medallion used. Remaining: " + medallionCount);

        return true;
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
