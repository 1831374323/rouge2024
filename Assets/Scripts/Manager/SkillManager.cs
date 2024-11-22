using System.Collections.Generic;
using System.Linq;
using SyTool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace rouge2024
{
    public class SkillManager : SingletonMono<SkillManager>
    {
        Player player;
        public static int maxSkillNumber = 4;
        protected override void Awake()
        {
            base.Awake();
            player = Player.Instance;
        }
        void Start()
        {
            for (int i = 0; i < maxSkillNumber; i++)
            {
                skills.Add(null);
                if (originalSkillDatas[i] != null)
                {
                    AttatchSkill(originalSkillDatas[i], i);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i] != null)
                {
                    if (skills[i].cd >= 0.05f)
                    {
                        skills[i].cd -= Time.deltaTime;
                        skill1CD.text = skills[i].cd.ToString();
                    }
                    else
                    {
                        skill1CD.text = " ";
                        skills[i].isUseable = true;
                    }
                }
            }


        }

        public Text skill1CD;

        public List<SkillData_Base> originalSkillDatas = new List<SkillData_Base>();
        [SerializeField]
        private List<Skill> skills = new List<Skill>();

        public void DoSkill(int index)
        {
            if (skills[index] != null)
            {
                float cd = skills[index].skillData.coolDown * player.playerData.skillHaste;
                skills[index].DoSkill(cd);
            }
        }

        /// <summary>
        /// index : 0-3
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="index"></param>
        public void AttatchSkill(SkillData_Base skill, int index)
        {
            skills[index] = new Skill(skill);
        }
    }
}