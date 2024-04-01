using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemStack stack;
    public Image artwork; 

    void Start()
    {
        artwork.sprite = stack.GetItem().sprite;
    }
}
