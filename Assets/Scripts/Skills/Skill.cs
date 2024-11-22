using System;
using UnityEngine;

namespace rouge2024
{
    [Serializable]
    public class Skill 
    {
        public SkillData_Base skillData;
        public Skill(SkillData_Base _skillData_Base)
        {
            skillData = _skillData_Base;
        }

        public bool isUseable = true;
        public float cd = 0;

        void Update()
        {
            
        }

        public void DoSkill(float _cd)
        {
            if (isUseable)
            {
                cd = _cd;
                isUseable = false;
                skillData.DoSkill();
            }
        }
    }
}