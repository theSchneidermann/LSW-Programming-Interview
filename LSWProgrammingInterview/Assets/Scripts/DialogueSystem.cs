using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    private Queue<string> sentences;
    public CanvasGroup textBox;
    public Text nameTxt;
    public Text DialogueTxt;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        textBox.alpha = 1;
        textBox.blocksRaycasts = true;
        textBox.interactable = true;

        nameTxt.text = dialogue.Name;

        sentences.Clear();

        foreach(string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string sentence = sentences.Dequeue();
            DialogueTxt.text = sentence;
        }

        
    }


    void EndDialogue()
    {
        textBox.alpha = 0;
        textBox.blocksRaycasts = false;
        textBox.interactable = false;
        if (NPC.next)
        {
            NPC.timesTalked = 2;
            NPC.next = false;
        }

        PlayerController.canMove = true;

        Debug.Log("End of dialogue");
    }
}
