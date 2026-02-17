using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public SkillTreeManager TreeManager;

    public GameObject buttonPrefab;
    public Transform buttonContainer;

    private void Awake()
    {
        TreeManager = new SkillTreeManager();

        SkillDatabase database = JsonUtility.FromJson<SkillDatabase>(jsonFile.text);

        foreach (SkillData skill in database.skills)
        {
            TreeManager.AddSkill(skill.id, skill.name);
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.GetComponent<SkillUIButton>().Initialize(skill.id, this,skill.name);
        }
        foreach(SkillData skill in database.skills)
        {
            if (skill.parentIds != null)
            {
                foreach (string parentId in skill.parentIds)
                {
                    TreeManager.ConnectSkills(parentId, skill.id);
                }
            }
        }
    }
}
