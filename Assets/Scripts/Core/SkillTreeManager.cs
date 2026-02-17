using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SkillTreeManager
{
    Dictionary<string, SkillNode> skillDictionary;

    public event Action<string> OnSkillUnlocked;

    public SkillTreeManager()
    {
        skillDictionary = new Dictionary<string, SkillNode>();
    }
    public void AddSkill(string Id, string name)
    {
        SkillNode skillNode = new SkillNode(Id, name);
        skillDictionary.Add(Id, skillNode);
    }

    public void ConnectSkills(string parentId, string childId)
    {
        if(skillDictionary.ContainsKey(parentId) && skillDictionary.ContainsKey(childId))
        {
            SkillNode parentNode = skillDictionary[parentId];
            SkillNode childNode = skillDictionary[childId];
            parentNode.Children.Add(childNode);
            childNode.Parents.Add(parentNode);

        }
    }

    public void CanUnlock(string skillId)
    {
        if (skillDictionary.ContainsKey(skillId))
        {
            for (int i = 0; i < skillDictionary[skillId].Parents.Count; i++)
            {
                if (skillDictionary[skillId].Parents[i].IsUnlocked == false){
                    Debug.Log("Bu yetenegi acmak icin " + skillDictionary[skillId].Parents[i].SkillName + " yetenegini acmalisiniz.");
                    return;
                }
                
            }
            skillDictionary[skillId].Unlock();
            OnSkillUnlocked?.Invoke(skillId);
        }
    }
}
