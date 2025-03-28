using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    public PlayableDirector playableDirectorTrigger;
}
 
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
   [SerializeField] bool isPlayInStart = false;
   public bool isPlayed = false;
   [SerializeField] bool enableNextDialogueLine;
   [SerializeField] bool enableUIAfterDialogueLine;
   [SerializeField] bool enableNextButton;
    private void Start() {
        if (isPlayInStart)
        {
            TriggerDialogue();
        }
        
    }
 
    public virtual void TriggerDialogue()
    {

        isPlayed = true;
        FindObjectOfType<Player>().DisableControls();
        DialogueManager.instance.StartDialogue(dialogue);

    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(!isPlayed){
                TriggerDialogue();
            }
        }
    }
}