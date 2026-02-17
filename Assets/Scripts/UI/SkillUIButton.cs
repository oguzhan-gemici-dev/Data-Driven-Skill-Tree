using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillUIButton : MonoBehaviour
{
    public string mySkillId;
    public Image buttonImage;
    public GameManager gameManager;
    public Button mybutton;
    public TextMeshProUGUI buttonText;

    public void Initialize(string id, GameManager managerRef, string name)
    {
        mySkillId = id;
        gameManager = managerRef;
        buttonText.text = name;
    }
    private void Start()
    {
        gameManager.TreeManager.OnSkillUnlocked += CheckIfMySkillUnlocked;
        mybutton.onClick.AddListener(() => gameManager.TreeManager.CanUnlock(mySkillId));
    }
    private void OnDestroy()
    {
        gameManager.TreeManager.OnSkillUnlocked -= CheckIfMySkillUnlocked;
    }
    void CheckIfMySkillUnlocked(string skillId)
    {
        if(skillId == mySkillId)
        {
            buttonImage.color = Color.green;
        }
    }
}
