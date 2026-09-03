using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedallionPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (MedallionManager.Instance != null)
        {
            MedallionManager.Instance.AddMedallion();

            Destroy(gameObject);
        }
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
