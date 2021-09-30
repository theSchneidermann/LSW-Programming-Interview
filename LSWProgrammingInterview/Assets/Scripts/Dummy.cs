using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    bool bought;

    
    public int price;

    PlayerController p;

    public Sprite Head;
    public Sprite Torso;
    public Sprite Pelvis;

    public List<WardrobeItem> prices;

    private void Start()
    {
        p = GameObject.Find("Player").GetComponent<PlayerController>();

        foreach (WardrobeItem wi in prices)
        {
            price += wi.price;
        }
    }

    public void ChangeClothes()
    {
        if (!p.allClothes.Contains(Head) || !p.allClothes.Contains(Torso) || !p.allClothes.Contains(Pelvis))
        {
            p.allClothes.Add(Head);
            p.allClothes.Add(Torso);
            p.allClothes.Add(Pelvis);
        }
        else
        {
            bought = true;
        }
        

        p.Head.sprite = Head;
        p.Torso.sprite = Torso;
        p.Pelvis.sprite = Pelvis;

        if (!bought)
        {
            p.money -= price;
            NPC.timesTalked = 3;
            bought = true;

        }
            

    }



}
