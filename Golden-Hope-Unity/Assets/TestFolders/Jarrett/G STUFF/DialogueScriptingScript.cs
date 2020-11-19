using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScriptingScript : MonoBehaviour
{
    public GameObject textBox;
    public Text dialogue;

    public TextAsset textFile;

    public string[] textLines;


    public int CurrentLine;
    public int endAtLine;

    public CharacterController player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        //dialogue.text = textLines[CurrentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                CurrentLine += 1;

                if (CurrentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[CurrentLine]));
                }

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }

        }  
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;

        dialogue.text = "";

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && letter < lineOfText.Length - 1)
        {
            dialogue.text += lineOfText[letter];
            letter += 1;

            yield return new WaitForSeconds(typeSpeed);
        }

        dialogue.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if(stopPlayerMovement)
        {
            player.enabled = false;
        }

        StartCoroutine(TextScroll(textLines[CurrentLine]));
    }
    void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.enabled = true;
        
    }
}