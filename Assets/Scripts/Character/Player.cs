using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace rouge2024
{

    public class Player : MonoBehaviour
    {
        public PlayerData playerData;
        public PlayerController controller;

        private bool isMoving;
        private Vector3 targetPosition;
        public void Move(Vector3 _targetPosition)
        {
            isMoving = true;
            targetPosition = _targetPosition;
        }

        public void Update()
        {
            if (isMoving)
            {
                float step = playerData.speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isMoving = false;
                }
            }

        }

        public SkillBase skill1 = null;
        public SkillBase skill2 = null;
        public SkillBase skill3 = null;
        public SkillBase skill4 = null;

        public float skill1CD = 0;
        public float skill2CD = 0;
        public float skill3CD = 0;
        public float skill4CD = 0;

        //方案 创建一个含有处理功能的skill类

        public void DoSkill(SkillBase skill)
        {
            if (skill != null)
            {
                skill.DoSkill();
            }
        }

        public void AttatchSkill(SkillBase skill,int index)
        {
            switch (index)
            {
                case 1:
                    skill1=skill;
                    break;
                case 2:
                    skill2 = skill;
                    break;
                case 3:
                    skill3 = skill;
                    break;
                case 4:
                    skill4 = skill;
                    break;
                default:
                    skill1 = skill;
                    break;
                    
            }
        }
    }
}
