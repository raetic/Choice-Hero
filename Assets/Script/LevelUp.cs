using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LevelUp : MonoBehaviour
{
    Stat st;
    SkillManager sm;
    [SerializeField] Image[] images;
    [SerializeField] TextMeshProUGUI[] name;
    [SerializeField] TextMeshProUGUI[] content;
    [SerializeField] TextMeshProUGUI[] lv;
    [SerializeField] TextMeshProUGUI[] type;
    Data data = new Data();
    enum skill
    {
        smash,
        wave,
        bolt,
    }
    enum stat
    {
        jump,
        physicsDmg,
        magicDmg,
        cooltime,
        attackSpeed,
        attackedDmg,
        exp,
        speed,
    }
    int[] skills = new int[30];
    int[] stats = new int[30];
    [SerializeField] Sprite[] statIcon;
    [SerializeField] Sprite[] skillIcon;
    List<int> UpList = new List<int>();

    int[] curReward = new int[3];
    int magic;
    int physics=1;
    private void Awake()
    {
        sm = GameObject.FindWithTag("Player").GetComponent<SkillManager>();
        st = GameObject.FindWithTag("Player").GetComponent<Stat>();
        UpList.Add(0);
        UpList.Add(1);
        UpList.Add(2);
        UpList.Add(101);
        UpList.Add(105);
        UpList.Add(106);
    }

   
    public void PopupOn()
    {
        gameObject.SetActive(true);
        if (UpList.Count > 0)
        {
            int rand1 = Random.Range(0, UpList.Count);
            int rew1 = UpList[rand1];
            if (rew1 >= 100)
            {
                SetStatReward(0, rew1 - 100);
            }
            else
            {
                SetSkillReward(0, rew1);
            }
            if (UpList.Count > 1)
            {
                int rand2 = Random.Range(0, UpList.Count);
                while (rand1 == rand2) rand2 = Random.Range(0, UpList.Count);
                int rew2 = UpList[rand2];
                if (rew2 >= 100)
                {
                    SetStatReward(1, rew2 - 100);
                }
                else
                {
                    SetSkillReward(1, rew2);
                }
                if (UpList.Count > 2)
                {
                    int rand3 = Random.Range(0, UpList.Count);
                    while (rand1 == rand3||rand2==rand3) rand3 = Random.Range(0, UpList.Count);
                    int rew3 = UpList[rand3];
                    if (rew3 >= 100)
                    {
                        SetStatReward(2, rew3 - 100);
                    }
                    else
                    {
                        SetSkillReward(2,rew3);
                    }
                }
            }
        }
        Time.timeScale = 0;
    }
    
    public void SetSkillReward(int num,int rew)
    {
      
        curReward[num] = rew;
        images[num].sprite = skillIcon[rew];
        name[num].text = data.skillData[rew].Name;
        content[num].text = data.skillData[rew].content;
        if (sm.Skills[rew] == 0) lv[num].text = "NEW!";
        else
        lv[num].text = "LV:"+(sm.Skills[rew]+1) + "";
        if (data.skillData[rew].type == 0) type[num].text = "물리";
        else type[num].text = "마법";
    }
    public void SetStatReward(int num,int rew)
    {
        curReward[num] = rew + 100;
        images[num].sprite = statIcon[rew];
        name[num].text = data.statData[rew].Name;
        content[num].text = data.statData[rew].content;
        if (st.Stats[rew] == 0) lv[num].text = "NEW!";
        else
        lv[num].text = "LV:" + (st.Stats[rew]+1) + "";
        type[num].text = "패시브";
 
    }
    public void SelectReward(int rew)
    {
        if (curReward[rew] >= 100)
        {
            StatUp(curReward[rew] - 100);
        }
        else
        {
            SkillUp(curReward[rew]);
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void StatUp(int stat)
    {
       
       st.Stats[stat]++;
       if (st.Stats[stat] == 5)
        {
            for(int i = 0; i < UpList.Count; i++)
            {
                if (UpList[i] == 100 + stat)
                {                
                    UpList.RemoveAt(i);
                    break;
                }
            }
        }
        st.StatUp();
    }
    public void SkillUp(int skill)
    {
        if (sm.Skills[skill] == 0)
        {
            sm.InstSkill(skill);
        }
        if (data.skillData[skill].type == 0) PhysicsUp();
        if (data.skillData[skill].type == 1) MagicUp();
        sm.Skills[skill]++;
        if (sm.Skills[skill] == 10)
        {
            for (int i = 0; i < UpList.Count; i++)
            {
                if (UpList[i] ==  skill)
                {
                    Debug.Log(skill + "은 10레벨");
                    UpList.RemoveAt(i);
                    break;
                }
            }
        }
    }
    public void MagicUp()
    {
        magic++;
        if (magic == 1)
            UpList.Add(102);
        if (magic == 3)
        {
            UpList.Add(103);
        }
    }
    public void PhysicsUp()
    {
        physics++;
        if (physics == 3)
        {
            UpList.Add(107);
        }
        if (physics == 5)
        {
            UpList.Add(100);
            UpList.Add(104);
        }
    }
}
class Data
{
    public struct statdata
    {
        public string Name;
        public string content;
        public statdata(string name, string content)
        {
            Name = name;
            this.content = content;
        }
    }
    public statdata[] statData = new statdata[8]
    {
        new statdata("투명 날개","공중에서 점프 가능한 횟수가 늘어납니다."),
        new statdata("날렵한 칼날","물리 공격력이 증가합니다."),
        new statdata("마법의 깨달음","마법 공격력이 증가합니다."),
        new statdata("암기의 원석","스킬 쿨타임을 감소됩니다."),
        new statdata("민첩의 물약","공격속도가 증가합니다."),
        new statdata("월등한 방패","피격 데미지가 감소됩니다."),
        new statdata("지식의 목걸이","경험치 획득량이 증가합니다."),
        new statdata("바람같은 움직임","이동속도가 증가합니다."),
    };
   public struct skilldata
    {
        public string Name;
        public string content;
        public int type;
        public skilldata(string name, string content,int type)
        {
            Name = name;
            this.content = content;
            this.type = type;
        }
    }
    public skilldata[] skillData = new skilldata[3]
   {
        new skilldata("검술","기본 공격이 강화됩니다.",0),
        new skilldata("물결 파동","직진으로 뻗는 파동을 생성합니다.",1),
        new skilldata("에너지 볼트","플레이어 주변으로 원형으로 발사되는 구체를 생성합니다.",1),
       
   };
}
