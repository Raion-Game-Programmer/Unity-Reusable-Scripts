using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
{
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    private Queue<DialogueLine> lines;
    public UIDialog  uiDialog;
    public float typingSpeed = 0.2f;
    public Dialogue currentDialogue;
    public PlayerInputActions playerInputActions;
    public InputAction nextDialogueAction;
    [Header("Bools")]
    public bool isDialogueActive = false;
    public bool enableNextDialogueAction = true;
    public bool enableUIAfterDialogue = true;
    public bool enableNextButton;

    public static event Action onDialogueEnd;

    public override void Awake()
    {
        base.Awake();
        lines = new Queue<DialogueLine>();
        playerInputActions = new PlayerInputActions();
    }
    private void OnEnable() {
        nextDialogueAction = playerInputActions.UI.NextDialogue;
        nextDialogueAction.performed += ctx => {
            if(isDialogueActive)
                DisplayNextDialogueLine();
        };
    }
    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        
        isDialogueActive = true;
 
        uiDialog.Show();
 
        lines.Clear();
 
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
 
        DisplayNextDialogueLine();

    }
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
 
        DialogueLine currentLine = lines.Dequeue();
 
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
 
        StopAllCoroutines();
 
        StartCoroutine(TypeSentence(currentLine));
    }
 
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue()
    {
        if(currentDialogue.playableDirectorTrigger != null){
            currentDialogue.playableDirectorTrigger.Play();
        }
        isDialogueActive = false;
        // uiDialog.Hide();

    }
    public void OnDialogueEnd(){
        onDialogueEnd?.Invoke();
    }
    public void DisableCharacterIcon(){
        characterIcon.enabled = false;
    }
    public void EnableCharacterIcon(){
        characterIcon.enabled = true;
    }
    public void EnableNextDialogueAction(){
        nextDialogueAction.Enable();
    }
    public void DisableNextDialogueAction(){
        nextDialogueAction.Disable();
    }
    public void EnableUIAfterDialogue(){
        enableUIAfterDialogue = true;
    }
    public void DisableUIAfterDialogue(){
        enableUIAfterDialogue = false;
    }
   
}