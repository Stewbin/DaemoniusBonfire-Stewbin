using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private QuestProgress QuestBook;
    
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            QuestBook.CollectiblesCollected++;
            Destroy(gameObject);
        }
    }
}
