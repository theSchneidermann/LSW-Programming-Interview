using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public static int timesTalked = 1;
    public static bool next =true;

    public Dialogue dialogueOne;
    public Dialogue dialogueTwo;
    public Dialogue dialogueThree;


    public void TriggerDialogue(int dialogueNumber)
    {
        switch (dialogueNumber)
        {
            case 1:
                FindObjectOfType<DialogueSystem>().StartDialogue(dialogueOne);
                break;
            case 2:
                FindObjectOfType<DialogueSystem>().StartDialogue(dialogueTwo);
                break;
            case 3:
                FindObjectOfType<DialogueSystem>().StartDialogue(dialogueThree);
                break;
        }
       

    }
}
