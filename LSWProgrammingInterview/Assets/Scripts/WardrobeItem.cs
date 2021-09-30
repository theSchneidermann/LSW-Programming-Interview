using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeItem : MonoBehaviour
{
    
    int price;
    public Sprite piece;


    // Start is called before the first frame update


    private void OnEnable()
    {
        piece = GetComponent<UnityEngine.UI.Image>().sprite;
        
        gameObject.name = piece.name + "_UI";
        Wardrobe w = FindObjectOfType<Wardrobe>();
        w.clothes.Add(piece);
        
    }


    public void Buy()
    {
       
        
    }

    
}
