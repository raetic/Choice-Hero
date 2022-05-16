using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    Player p;
    [SerializeField] GameObject skills;
    [SerializeField] GameObject stats;
    [SerializeField] GameObject PauseView;
    [SerializeField] LevelUp levelUp;
    SkillManager skillManager;
    Stat stat;
    Data d = new Data();
    public void Pause()
    {
        PauseView.SetActive(true);
        Time.timeScale = 0;
        List<int> haveSkill = new List<int>();
        for(int i = 0; i < skillManager.Skills.Length; i++)
        {
            if (skillManager.Skills[i] > 0)
            {
                haveSkill.Add(i * 100 + skillManager.Skills[i]);
            }
        }
        for(int i = 0; i < 8; i++)
        {
            skills.transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 0; i < haveSkill.Count; i++)
        {
            
            skills.transform.GetChild(i).gameObject.SetActive(true);
            skills.transform.GetChild(i).GetComponent<Image>().sprite = levelUp.skillIcon[haveSkill[i] / 100];
            if (haveSkill[i] % 100 == 10) skills.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text ="Max";
            else
            {
                skills.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text ="Lv" + haveSkill[i] % 100;
            }
            skills.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = d.skillData[haveSkill[i] / 100].Name;
        }

        stats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "체력:" + Mathf.CeilToInt(p.Hp) +"/" +Mathf.CeilToInt(p.maxHp);
        stats.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "물리력:" + levelUp.physics;
        stats.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "마법력:" + levelUp.magic;
        stats.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "점프력:Lv" + stat.JumpCount;
        stats.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "물리공격력:Lv" + stat.PhysicsDmg;
        stats.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "마법공격력:Lv" + stat.MagicDmg;
        stats.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "쿨타임:Lv" + stat.Cooltime;
        stats.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "공격속도:Lv" + stat.AttackSpeed;
        stats.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "방어력:Lv" + stat.AttackedDmg;
        stats.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "경험치획득:Lv" + stat.Exp;
        stats.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "이동속도:Lv" + stat.Speed;
        if (stat.Speed == 0) stats.transform.GetChild(11).gameObject.SetActive(false);
        else stats.transform.GetChild(11).GetComponent<TextMeshProUGUI>().text = "텔레포트:Lv" + stat.Teleport;
    }
    public void Resume()
    {
        PauseView.SetActive(false);
        Time.timeScale = 1;
    }















    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        skillManager = p.GetComponent<SkillManager>();
        stat = p.GetComponent<Stat>();
    }
    public void OnLeft()
    {
        p.isLeft = true;
    }
    public void OffLeft()
    {
        p.isLeft = false;
    }
    public void OnRight()
    {
       p.isRight = true;
    }
    public void OffRight()
    {
        p.isRight = false;
    }
    public void Jump()
    {if (Time.timeScale == 0) return;
        p.Jump();
    }
    public void tel()
    {
        p.Tel();
    }
}
