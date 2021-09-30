using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeItem : MonoBehaviour
{
    public string piecePart;
    public int price;
    public Sprite piece;
    private Text priceTag;

    // Start is called before the first frame update


    public void Show()
    {
        
        piece = GetComponent<Image>().sprite;
        priceTag = GetComponentInChildren<Text>();
        priceTag.text = "$" + price.ToString();
        gameObject.name = piece.name + "_UI";
        Wardrobe w = FindObjectOfType<Wardrobe>();
        if (!w.clothes.Contains(piece))
            w.clothes.Add(piece);
        
    }


    public void Buy()
    {
        
        FindObjectOfType<PlayerController>().UpdateClothes(piecePart, piece);
        
    }


   


    public void CancelBuy()
    {
        priceTag.text = "Bought!";
        priceTag.color = Color.green;
    }

    
}
