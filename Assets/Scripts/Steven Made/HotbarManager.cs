using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class HotbarManager : MonoBehaviour
{
    [SerializeField] private InventoryManager IM; 
    [SerializeField] private GameObject Hotbar;
    private byte HbarOn = 0;
    
    void Start()
    {
        // Turn hotbar display off
        Hotbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (HbarOn) // Toggle hot bar on/off
            {
                case 0:
                Hotbar.SetActive(true);
                HbarOn = 1; 
                break;
                case 1:
                Hotbar.SetActive(false);
                HbarOn = 0;
                break;
            }
        }

        // Fill hotbar
        for (int i = 0; i < transform.childCount; i++)
        {
            ItemDisplay slot = transform.GetChild(0).GetComponent<ItemDisplay>();
            if (slot.stack == null)
            {
                slot.stack = IM.items[i];
            }
        }
    }
}
