using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    


    PlayerController p;

    public Sprite Head;
    public Sprite Torso;
    public Sprite Pelvis;
    public Sprite lShoulder;
    public Sprite rShoulder;

    public Sprite lBoot;
    public Sprite rBoot;


    private void Start()
    {
        p = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public void ChangeClothes()
    {
        p.Head.sprite = Head;
        p.Torso.sprite = Torso;
        p.Pelvis.sprite = Pelvis;
        p.lShoulder.sprite = lShoulder;
        p.rShoulder.sprite = rShoulder;
        p.lBoot.sprite = lBoot;
        p.rBoot.sprite = rBoot;

        NPC.timesTalked = 3;

    }



}
