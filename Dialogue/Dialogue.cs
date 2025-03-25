using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Dialogue: UIBase
{
    [SerializeField] Button nextButton;
    private void Update() {
        if(DialogueManager.instance.enableNextButton){
            nextButton.gameObject.SetActive(true);
        }
        else{
            nextButton.gameObject.SetActive(false);
        }
    }
    public override void Show(){
        base.Show();

        GetComponentInChildren<RectTransform>().DOAnchorPosY(300, 0.5f).SetEase(Ease.OutBack);
    }
    public override void Hide()
    {
        if(DialogueManager.instance.enableUIAfterDialogue){
            UIManager.instance.ShowUIForCutscene();
        }

        GetComponentInChildren<RectTransform>().DOAnchorPosY(-300, 0.5f).SetEase(Ease.InBack).OnComplete(()=>base.Hide());  
    }
}
