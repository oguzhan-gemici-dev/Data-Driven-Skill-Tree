using System;

// JSON'daki tek bir yeteneði temsil eden DTO
[Serializable]
public class SkillData
{
    public string id;
    public string name;
    public string[] parentIds; // Birden fazla önkoþul olabileceði için Dizi (Array) kullanýyoruz
}

// JSON'daki tüm listeyi sarmalayan Ana DTO
[Serializable]
public class SkillDatabase
{
    public SkillData[] skills;
}