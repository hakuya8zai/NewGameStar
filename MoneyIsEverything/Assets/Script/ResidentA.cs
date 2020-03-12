using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ResidentA : MonoBehaviour
{
    public Component PlayerController;
    private GameObject Dialogue;
    private Text DialogueText;
    public static bool InterActing;
    // Start is called before the first frame update
    void Awake()
    {
        Dialogue = GameObject.Find("/Canvas/Dialogue");
        Dialogue.SetActive(false);
        InterActing = false;
    }
    void Start()
    {
        DialogueText = Dialogue.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        print(InterActing);
        if(InterActing == false)
        {
            if(other.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    InterActing = true;
                    Dialogue.SetActive(true);
                    DialogueText.DOText(("歡迎光臨啦!"),1.0f);
                }
                else if(Input.GetKeyDown(KeyCode.E))
                {
                }    
            }
        }
        else
        {
            if(other.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    InterActing = false;
                    Dialogue.SetActive(false);
                    DialogueText.text =("");
                }
                else if(Input.GetKeyDown(KeyCode.E))
                {
                }    
            }
        }
    }
}
