using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    bool bought;

    [SerializeField]int price;

    PlayerController p;

    public Sprite Head;
    public Sprite Torso;
    public Sprite Pelvis;



    private void Start()
    {
        p = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public void ChangeClothes()
    {
        if (!p.allClothes.Contains(Head) || !p.allClothes.Contains(Torso) || !p.allClothes.Contains(Pelvis))
        {
            p.allClothes.Add(Head);
            p.allClothes.Add(Torso);
            p.allClothes.Add(Pelvis);
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
