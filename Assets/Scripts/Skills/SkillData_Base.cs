using System;
using UnityEngine;

namespace rouge2024
{

    public abstract class SkillData_Base : ScriptableObject
    {
        public abstract float coolDown { get; }
        public abstract void DoSkill();

    }

}