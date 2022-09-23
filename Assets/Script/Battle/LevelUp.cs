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
    [SerializeField] Image[] selectImages;
    [SerializeField] GameObject teleport;
    Data data = new Data();
    BattleManager BM;
    public int skillCount;
    [SerializeField] Sprite[] statIcon;
    public Sprite[] skillIcon;
    List<int> UpList = new List<int>();
    [SerializeField] TextMeshProUGUI reselctCount;
    int[] curReward = new int[3];
    public int magic;
    public int physics;
    [SerializeField] GameObject player;
    private void Awake()
    {
        sm = GameObject.FindWithTag("Player").GetComponent<SkillManager>();
        st = GameObject.FindWithTag("Player").GetComponent<Stat>();
        BM = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        UpList.Add(0);
        UpList.Add(1);
        UpList.Add(2);
        UpList.Add(101);
        UpList.Add(105);       
    }
    IEnumerator SelectCor()
    {
        selectImages[0].color=new Color(0.854902f, 0.7294118f, 0.568627f, 1);
        selectImages[1].color = new Color(0.854902f, 0.7294118f, 0.568627f, 1);
        selectImages[2].color = new Color(0.854902f, 0.7294118f, 0.568627f, 1);
        int t = 0;
        while (t < 10)
        {
            t++;
            
            selectImages[0].color = new Color(0.854902f, 0.7294118f, 0.568627f, 1-0.1f * t);
            yield return new WaitForSecondsRealtime(0.05f);
        }
        t = 0;
        while (t < 10)
        {
            t++;
            selectImages[1].color = new Color(0.854902f, 0.7294118f, 0.568627f, 1 - 0.1f * t);
            yield return new WaitForSecondsRealtime(0.05f);
        }
        t = 0;
        while (t < 10)
        {
            t++;
            selectImages[2].color = new Color(0.854902f, 0.7294118f, 0.568627f, 1 - 0.1f * t);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
   
    public void PopupOn()
    {
       
        gameObject.SetActive(true);
        StartCoroutine("SelectCor");
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
        reselctCount.text = "x" + player.GetComponent<Player>().reselect;
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
        BM.LvUpCount--;
        if (BM.LvUpCount == 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PopupOn();
        }
    }
    public void StatUp(int stat)
    {
        if (stat == 8 && st.Stats[stat] == 0) teleport.SetActive(true);
       st.Stats[stat]++;
       if (st.Stats[stat] == data.statData[stat].max)
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
        st.StatUp(stat);
    }
    public void SkillUp(int skill)
    {
  
        if (sm.Skills[skill] == 0)
        {
            sm.InstSkill(skill);
            skillCount++;
        }
        sm.Skills[skill]++;
        if (skillCount == 8)
        {
           for(int i = UpList.Count-1; i >= 0; i--)
            {
                if (UpList[i] < 100 && sm.Skills[UpList[i]] == 0)
                {
                    UpList.RemoveAt(i);
                }
            }
        }
        if (skill == 9)
        {
            sm.SmashDanceLevelUp(sm.Skills[skill]);
        }
      
        if (data.skillData[skill].type == 0) PhysicsUp();
        if (data.skillData[skill].type == 1) MagicUp();
     
        if (skill == 19)
        {
            sm.MyolLevelUp();
        }
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
        if (magic + physics == 20)
        {
            UpList.Add(106);
        }
        if (magic == 1)
        { UpList.Add(102); }
        if (magic == 3&&skillCount<8)
        {
           
            UpList.Add(3);
            UpList.Add(8);
        }
        if (magic == 5)
        {
            UpList.Add(103);
            
        }
        if (magic == 7 && skillCount < 8)
        {
            UpList.Add(5);
            UpList.Add(10);
        }
        if (magic == 20)
        {
          
          UpList.Add(108);
        }
        if (magic == 15 && skillCount < 8)
        {
            UpList.Add(11);
            UpList.Add(13);

        }
        if (magic == 25 && skillCount < 8)
        {
            UpList.Add(15);
            UpList.Add(16);
        }
        if (magic == 40 && skillCount < 8)
        {
            UpList.Add(21);
            UpList.Add(22);
        }
    }
    public void PhysicsUp()
    {
        physics++;
        if (magic + physics == 20)
        {
            UpList.Add(106);
        }
        if (physics == 3)
        {
            UpList.Add(107);
            if (skillCount < 8)
            {
                UpList.Add(4);
                UpList.Add(6);
            }
        }
        if (physics == 5)
        {
            
            UpList.Add(104);
          
        }
        if (physics == 7 && skillCount < 8)
        {
            UpList.Add(7);
            UpList.Add(9);

        }
        if (physics == 10)
        {
            UpList.Add(100);
           
        }
        if (physics == 15 && skillCount < 8)
        {
            UpList.Add(12);
            UpList.Add(14);
        }
        if (physics == 25 && skillCount < 8)
        {
            UpList.Add(18);
            UpList.Add(17);
        }
        if (physics == 40 && skillCount < 8)
        {
            UpList.Add(19);
            UpList.Add(20);
        }
    }
    public void ReselectButton()
    {
        if (player.GetComponent<Player>().reselect == 0) return;
        else
        {
            player.GetComponent<Player>().reselect--;
            PopupOn();
        }
    }
}
public class Data
{

    public struct statdata
    {
        public string Name;
        public string content;
        public int max;
        public statdata(string name, string content,int max)
        {
            Name = name;
            this.content = content;
            this.max = max;
        }
    }
    public statdata[] statData = new statdata[9]
    {
        new statdata("투명 날개","공중에서 점프 가능한 횟수가 늘어납니다.",5),
        new statdata("날렵한 칼날","물리 공격력이 증가합니다.",20),
        new statdata("마법의 깨달음","마법 공격력이 증가합니다.",20),
        new statdata("암기의 원석","스킬 쿨타임을 감소됩니다.",15),
        new statdata("민첩의 물약","공격속도가 증가합니다.",15),
        new statdata("월등한 방패","피격 데미지가 감소됩니다.",10),
        new statdata("지식의 목걸이","경험치 획득량이 증가합니다.",10),
        new statdata("바람같은 움직임","이동속도가 증가합니다.",5),
        new statdata("텔레포트","텔레포트 사용이 가능합니다.",2),
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
    public skilldata[] skillData = new skilldata[23]
   {
        new skilldata("검술","기본 공격이 강화됩니다.",0),
        new skilldata("물결 파동","직진으로 뻗는 파동을 생성합니다.",1),
        new skilldata("에너지 볼트","플레이어 주변으로 원형으로 발사되는 구체를 생성합니다.",1),
        new skilldata("뿌리 소환","플레이어로 가까운 곳에 있는 적에게 뿌리를 생성하여 공격합니다.",1),
        new skilldata("우드 어택","충돌 시 파편을 생성하는 나무를 던집니다.",0),
        new skilldata("벼락","랜덤한 위치에 벼락을 생성합니다.",1),
        new skilldata("표창","적중 시 주변 적에게 튕기는 표창을 던집니다.",0),
        new skilldata("도끼","주우면 쿨타임이 초기화 되는 도끼를 던집니다.",0),
        new skilldata("고드름","몸 주변에서 순차적으로 퍼져나가는 고드름을 생성합니다.",1),
        new skilldata("칼춤","주변을 보호하는 칼을 생성합니다.",0),
        new skilldata("대지의 분노","적을 띄우는 땅의 정령을 소환합니다.",1),
        new skilldata("신성한 빛","가장 가까운 적에게 성스로운 빛을 떨어뜨립니다.",1),
        new skilldata("지진","거대한 망치를 땅에 내리쳐 주변 적을 공중에 띄웁니다.",0),
        new skilldata("토네이도","통제되지 않는 거대한 토네이도를 생성합니다.",1),
            new skilldata("검술2","기본 공격을 할 때마다 주변 적을 베어버립니다.",0),
            new skilldata("리프 스톰","모든 것을 베어버리는 잎사귀를 날립니다.",1),
            new skilldata("메테오","폭발을 일으키는 운석을 떨어뜨립니다.",1),
            new skilldata("소드 레인","엄청난 수의 칼을 위로 던진 후 떨어뜨립니다.",0),
            new skilldata("자벨린 마스터","가능한 모든 방향으로 표창을 마구 던집니다.",0),
            new skilldata("묠니르","신화속의 전설의 도끼를 소환합니다.",0),
            new skilldata("검술:발도","특정 기본 공격 횟수마다 발도술을 사용합니다.",0),
            new skilldata("체인라이트닝","모든 적을 공격하는 전기마법을 씁니다.",1),
            new skilldata("해수 폭발","땅 밑 깊은곳에서부터 끓는 해수를 폭발시킵니다.",1),
   };
    public struct characterData
    {
        public string Name;
        public string content;
        public bool open;
        public int[] s;
        public characterData(string name, string content, bool open,int[] s)
        {
            Name = name;
            this.content = content;
            this.open = open;
            this.s = s;
        }
    }
    public characterData[] CharacterData = new characterData[7] {
     new characterData("기사","가장 무난한 기사입니다. 본인은 알까요?\n모든 능력치가 모든 사람의 딱 평균이라는 사실을.",true,new int[]{0,0,0,0,0,0,0,0}),
     new characterData("마법사","초보 마법사입니다. 마법력이 있다고는 하지만...\n아직 다른 면이 많이 부족해보이네요.",true,new int[]{0,-1,2,2,-1,-1,0,-1}),
    new characterData("학자","배우는게 가장 행복한 학자입니다.\n남들보다 성장이 훨씬 빠르지만... 그만큼 조금 둔해 보이네요.",true,new int[]{0,0,0,0,-2,-2,5,1}),
    new characterData("광전사","힘, 힘, 힘, 그리고 힘.\n그를 설명할 때 힘을 뺀다면 뭐가 남을까요?",true,new int[]{0,6,-3,-1,1,-3,0,0}),
    new characterData("닌자","문답무용.\n속전속결.",true,new int[]{2,-1,-1,0,4,-4,0,2}),
    new characterData("기마병","전장에 그와 그의 말이 뜨면, 적들은 모조리 도망을 치려고 합니다.\n소용없다는 것을 알면서도 말이죠.",true,new int[]{-1,1,-2,-1,0,3,-2,4}),
     new characterData("언데드","어쩌다가 살아난지 모르겠지만,\n이상하게 사람들보단 주문 외우는 속도가 훨씬 빠르네요.",true,new int[]{0,-2,-2,10,-1,-1,-2,-2}),

    };
}
