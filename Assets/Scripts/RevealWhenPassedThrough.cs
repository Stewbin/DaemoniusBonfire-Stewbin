using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RevealWhenPassedThrough : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private Color OrigiColor, TargetColor;
    [SerializeField] private float TransitionSpeed = 1.0f;
    private float t = 0;
    [SerializeField] private float DimAlphaBy = 0.3f; // 1 = Decrease opacity by 100%; 0 = No decrease at all
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // Link Sprite Renderer

        OrigiColor = sprite.color;
        TargetColor = OrigiColor - new Color(0, 0, 0, DimAlphaBy);
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (1 - DimAlphaBy < sprite.color.a)
            {
                sprite.color = Color.Lerp(OrigiColor, TargetColor, t);
                t += Time.deltaTime * TransitionSpeed;
            }
            //Debug.Log("Oh god, someone's INSIDE me!!");
        }
    }

    void OnTriggerExit2D()
    {
        sprite.color = OrigiColor;
    }
}
