using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase 
{
    public event EventHandler OnSkillPointsChanged;
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;
    public class OnSkillUnlockedEventArgs : EventArgs
    {
        public SkillType skillType;
    }
    //bu enumdaki "SkillA_1,2" ve "SkillB_1,2" uygun isimlerle de�i�tirilebilir\\
    //veya SkillC vs eklenebilir ama e�er index kullanacaksan�z s�raya dikkat edin\\
    public enum SkillType
    {
        None,
        SkillA_1,
        SkillA_2,
        SkillB_1,
        SkillB_2,
        Movement_1,
        Movement_2,
        Movement_3,
        HealthMax_1,
        HealthMax_2,
        HealthMax_3,
        Speed_1,
        Speed_2,
        Speed_3,
    };

    private List<SkillType> unlockedSkillsList;
    private int skillPoints;

    
    public SkillBase()
    { 
        unlockedSkillsList = new List<SkillType>();
    }

    public void AddSkillPoint()
    {
        skillPoints++;
        OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    public SkillType GetSkillRequirement(SkillType skillType)
    {
        switch (skillType)
        {
            //Can�n skill tree'deki requirement'lar�
            case SkillType.HealthMax_2: return SkillType.HealthMax_1;
            case SkillType.HealthMax_3: return SkillType.HealthMax_2;
            //H�z�n " " " " "
            case SkillType.Speed_2: return SkillType.Speed_1;
            case SkillType.Speed_3: return SkillType.Speed_3;
            //Ayn�s� SkillA ve SkillB i�in.
            case SkillType.SkillA_2: return SkillType.SkillA_1;
            case SkillType.SkillB_2: return SkillType.SkillB_1;

        }
        return SkillType.None;
    }

    public bool CanUnlock(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (skillRequirement != SkillType.None) //Yetenek a�ac�nda a��k olmas� gereken �nceki bir skill varsa, o skill a��k m� de�il mi kontrol ediyor
        {
            if (IsSkillUnlocked(skillRequirement)) // Bahsi ge�en skill a��k ise true d�nd�r�yor de�ilse false...
            {
                return true;
            }
            else return false;
        }
        else return true; //A��k olmas� gereken bir �nceki skill yoksa, true d�nd�r�yor.
    }

    public void UnlockSkill(SkillType skillType)
    {
        if(!unlockedSkillsList.Contains(skillType))
         unlockedSkillsList.Add(skillType);
        OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
    }

    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillsList.Contains(skillType);
    }

    public bool TryUnlockSkill(SkillType skillType) // bir skill a�may� deniyor, a�abiliyorsa a��yor ve true d�nd�r�yor yoksa false "
    {
        if (CanUnlock(skillType)) // skill a��labiliyor mu
        {
            if (skillPoints > 0) // skill puan� var m�
            {
                skillPoints--;
                OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
                UnlockSkill(skillType);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}

