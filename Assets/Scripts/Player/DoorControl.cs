using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField]
    private bool isLocked = true;
    [SerializeField]
    private ItemCollector itemCollector;

    [SerializeField]
    private bool GoldKey = false;

    void Start()
    {
        isLocked = true;
    }

    void Update()
    {
        if (isLocked)
        {
            if (GoldKey)
            {
                if (itemCollector.gold_key >= 1)
                {
                    isLocked = false;
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                if (itemCollector.silver_key >= 1)
                {
                    isLocked = false;
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }
}
