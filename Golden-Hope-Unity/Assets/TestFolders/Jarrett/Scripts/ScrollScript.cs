using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    public Text Title;
    public Text Note;
    public Canvas NoteCanvas;
    public Collider2D InteractRange;
    public CharacterController player;

    public bool CanOpenNote;

    public TextAsset textAsset;

   // public string ScrollName;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
       // ScrollName = gameObject.name;
    }

    public void Update()
    {
        if (CanOpenNote && Input.GetKeyDown(KeyCode.E))
        {
            OpenNote();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CloseNote();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in Range");
            Title.text = textAsset.name;
            Note.text = textAsset.text;
            CanOpenNote = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is NOT in Range");

            CanOpenNote = false;
        }
    }



    public void OpenNote()
    {
        NoteCanvas.gameObject.SetActive(true);
        player.enabled = false;
    }

    public void CloseNote()
    {
        NoteCanvas.gameObject.SetActive(false);
        player.enabled = true;
    }
}
