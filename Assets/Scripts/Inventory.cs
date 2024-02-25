using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryManager inventory;
    public Text display;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        display.text = inventory.TestDisplay().ToString();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.tag == "item")
        {

            if (inventory.Add(other.gameObject.GetComponent<ItemPrefabScript>().itemType))
                Destroy(other.gameObject); //temporary. instead the spawn manager will be incharge of this

        }
    }
}
