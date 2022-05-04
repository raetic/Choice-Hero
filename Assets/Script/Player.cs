using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField]Animator anim;
    [SerializeField] float jumpPower;
    [SerializeField] int maxJumpCount;
    int curJumpCount;
    [SerializeField] GameObject myWeapon;
    Rigidbody2D rigid;
    float attackSpeed;
    float Hp;
    [SerializeField] float maxHp;
    [SerializeField] GameObject dmgPr;
    [SerializeField] int farming;
    [SerializeField] LayerMask expLayer;
    [SerializeField] GameObject hpBar;
    [SerializeField] Image hpImage;
    [SerializeField] Image greenImage;
    [SerializeField] TextMeshProUGUI levelT;
    int Level;
    float curExp;
    float maxExp;
    SkillManager SM;
    Stat stat;
    BattleManager BM;
    private void Start()
    {   
        rigid = GetComponent<Rigidbody2D>();
        SM = GetComponent<SkillManager>();
        stat = GetComponent<Stat>();
        BM = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        Hp = maxHp;
        Level = 1;
        maxExp = 70;       
        StartCoroutine("AttackCor");
        //SM.InstBolt();
    }
    IEnumerator AttackCor()
    {
        while(true)
        {
            
            anim.SetTrigger("Attack");
           
          
          
            yield return new WaitForSeconds(0.1f);
            
            SM.InstSmash();
            
            myWeapon.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            myWeapon.SetActive(false);
            yield return new WaitForSeconds(1.5f-(stat.AttackSpeed*-0.15f)-0.3f);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
        float a = (Hp / maxHp) * 0.8f;
        hpImage.fillAmount = Mathf.Lerp(hpImage.fillAmount, a + 0.1f, Time.deltaTime * 5f);
        greenImage.fillAmount = Mathf.Lerp(greenImage.fillAmount, curExp / maxExp, Time.deltaTime * 5f);
        KeyboardUse();
    }
    public void HpUp(float value)
    {
        Hp += value;
        if (Hp > maxHp) Hp = maxHp;
    }
    void KeyboardUse()
    {
        hpBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
        if (Time.timeScale == 0) return;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 0.07f * (1 + 0.15f * stat.Speed));
            anim.SetFloat("RunState", 0.5f);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 0.07f * (1+0.15f*stat.Speed));
            transform.localScale = new Vector2(-1, 1);
            anim.SetFloat("RunState", 0.5f);
        }
        else
        {
            anim.SetFloat("RunState", 0);
        }
       
          
    }
   
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && (1+stat.JumpCount) > curJumpCount)
        {
            curJumpCount++;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower);
        }
       

    }
    public void onHit(int dmg)
    {
        
        dmg = Mathf.RoundToInt(dmg * (1-0.1f*stat.AttackedDmg));      
        GameObject Dmg = Instantiate(dmgPr, transform.position + new Vector3(0, 1.5f), transform.rotation);
        Dmg.GetComponent<Dmg>().SetText(dmg,true);
        Hp -= dmg;
    }
    public void ExpUp(float mount)
    {
        
        curExp += Mathf.RoundToInt(mount*(1+0.1f*stat.Exp));
        if (curExp > maxExp)
        {           
            LevelUp();           
        }
    }
    public void LevelUp()
    {
        Level++;
        levelT.text = "LV:"+Level;
        BM.LvUp();
        float v = curExp - maxExp;
      
        curExp = 0;
        maxExp += 30;
        ExpUp(v);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Back") curJumpCount = 0;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exp")
        {
            ExpUp(collision.gameObject.GetComponent<Exp>().mount);
            Destroy(collision.gameObject);
        }
    }
}
