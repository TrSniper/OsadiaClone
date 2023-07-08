using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSkillOnCollide : MonoBehaviour
{
    private SkillManager skillManager;
    private SkillBase skillBase;
    public SkillBase.SkillType skillToUnlock;
    [SerializeField]private int cost;

    void Start()
    {
        skillManager = FindObjectOfType<SkillManager>();
        skillBase = skillManager.GetSkillBase();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Demo
        if(skillBase.TryUnlockSkill(skillToUnlock))
            Debug.Log("G��lendirme Sat�n al�nd�!");
        else
        {
            Debug.Log(skillBase.GetSkillPoints());
            Debug.Log("Yetersiz Arcadium. Gereken miktar: " + (cost - skillBase.GetSkillPoints())); 
        }
        ////Destroy(gameObject);
        //Demo

        //Hedef
        //1.Text ��kar : "E ye bas, shop a��ls�n vs."
        //2.input.getbutton(e)
        //3.if(e):text gider, Shop a��l�r, mouselock kalkar, cursor visible true
        //Hedef
    }

    /*ontriggerexit
        1.text gider
        2. mouselock a��l�r cursor gider

    */
}
