using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : ScriptableObject
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [Header("Object Inputs - Dialogue Box Object for Both")]
    [SerializeField] private GameObject dialogueBox;
    public Animator textDisplayAnim;

    private int index;

    void Start()
    {
        //sentences = new Queue<string>();
        textDisplayAnim.SetTrigger("Open");
        textComponent.text = string.Empty;
        StartDialogue();
    }

    //public void StartDialogue(Dialogue dialogue)
    //{
    //    Debug.Log("Starting conversation with " + dialogue.name);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StopAllCoroutines();
            index = 0;
            textComponent.text = lines[index];
            dialogueBox.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
