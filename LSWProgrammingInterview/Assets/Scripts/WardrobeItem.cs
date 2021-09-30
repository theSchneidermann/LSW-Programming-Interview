using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeItem : MonoBehaviour
{
    public string piecePart;
    public int price;

   

    [HideInInspector]
    public Sprite piece;
    private Text priceTag;

    public Button buy, sell;

    PlayerController p;

    private void Start()
    {
        p = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    public void Show()
    {
        
        piece = GetComponent<Image>().sprite;
        priceTag = GetComponentInChildren<Text>();
        OpenBuy();
        gameObject.name = piece.name + "_UI";
        Wardrobe w = FindObjectOfType<Wardrobe>();
        if (!w.clothes.Contains(piece))
            w.clothes.Add(piece);

      
            

    }



    private void Update()
    {
        if (p.allClothes.Contains(piece))
        {
            buy.GetComponentInChildren<Text>().text = "Try";
            sell.interactable = true;
        }
        else
        {
            buy.GetComponentInChildren<Text>().text = "Buy";
            sell.interactable = false;
        }
    }


    public void Buy()
    {
         
        if (!p.allClothes.Contains(piece))
        {
            
            p.UpdateClothes(piecePart, piece);
            p.allClothes.Add(piece);
            p.money -= price;
            CancelBuy();
        }
        else
        {
            
            p.UpdateClothes(piecePart, piece);
           
        }
            


    }

 

    public void Sell()
    {
        
        if (p.allClothes.Contains(piece))
        {
            
            p.allClothes.Remove(piece);
            p.money += price;
            OpenBuy();
        }
       
    }

   


    public void CancelBuy()
    {
        priceTag.text = "Bought!";
        priceTag.color = Color.green;
    }


    public void OpenBuy()
    {
        priceTag.text = "$" + price.ToString();
        priceTag.color = Color.red;
    }

    
}
