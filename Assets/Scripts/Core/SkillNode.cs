using UnityEngine;
using System.Collections.Generic;

public class SkillNode
{
    public string SkillID { get; private set; }
    public string SkillName { get; private set; }
    public bool IsUnlocked { get; private set; }
    //yetenek acildiktan sonra erisilebicek yetenekler
    public List<SkillNode> Children { get; private set; }

    //yetenek acilmasi icin gerekli olan yetenekler
    public List<SkillNode> Parents { get; private set; }

    public SkillNode(string id, string name)
    {
        SkillID = id;
        SkillName = name;
        IsUnlocked = false;
        Children = new List<SkillNode>();
        Parents = new List<SkillNode>();
    }

    public void Unlock()
    {
        IsUnlocked = true;
    }
}
