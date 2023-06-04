using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yone
{
    public class SkillData
    {
        public enum SkillKey { Q, W, E, R };

        public struct SkillDatas
        {
            public SkillKey Key; // 스킬 사용 버튼
            public float coolTime; // 스킬 쿨타임
            public int damage; // 스킬 데미지
            public string name; // 스킬 이름
            public string toolTip; // 스킬 툴팁
            public int skillDir; // 스킬 사정거리
            public float delay; // 스킬 시전 시간
        }

        public string skillKey; // 스킬 키
        public float coolTime; // 스킬 쿨타임
        public int damage; // 스킬 데미지
        public string lastKey; // 스킬 사용 버튼
        public string name; // 스킬 이름
        public string toolTip; // 스킬 툴팁
        public int skillDir; // 스킬 사정거리
        public float delay; // 스킬 시전 시간
        public static SkillDatas[] skillData = new SkillDatas[4];
        
        public int px, py; // 플레이어의 x, y 좌표
        public bool isDalay = false;
        public virtual void QSkill(){ }
        public virtual void WSkill(){ }
        public virtual void ESkill(){ }
        public virtual void RSkill(){ }
        public virtual void SkillDataUpDate()
        {

        }

    }
}
