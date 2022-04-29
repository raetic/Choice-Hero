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
    private void Start()
    {   attackSpeed = 1.5f;
        rigid = GetComponent<Rigidbody2D>();
        SM = GetComponent<SkillManager>();
        StartCoroutine("AttackCor");       
        Hp = maxHp;
        Level = 1;
        maxExp = 70;
        //SM.InstBolt();
    }
    IEnumerator AttackCor()
    {
        while(true)
        {
            
            anim.SetTrigger("Attack");
           
          
          
            yield return new WaitForSeconds(0.1f);
            if (SM.smash > 1)
            {
                SM.InstSmash();
            }
            myWeapon.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            myWeapon.SetActive(false);
            yield return new WaitForSeconds(1/attackSpeed-0.3f);
        }
    }
    // Update is called once per frame
    void KeyboardUse()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 0.01f * speed);
            anim.SetFloat("RunState", 0.5f);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 0.01f * speed);
            transform.localScale = new Vector2(-1, 1);
            anim.SetFloat("RunState", 0.5f);
        }
        else
        {
            anim.SetFloat("RunState", 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && maxJumpCount > curJumpCount)
        {
            curJumpCount++;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower);
        }
    }
    void FindExp()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, farming,expLayer);
        if (colls.Length > 0)
        {
           foreach(var i in colls)
            {
                i.GetComponent<Exp>().ComeTo(gameObject);
            }
        }
    }
    void Update()
    {
        hpBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
        float a = (Hp / maxHp) * 0.8f;
       
        hpImage.fillAmount = Mathf.Lerp(hpImage.fillAmount, a+0.1f, Time.deltaTime * 5f);
        greenImage.fillAmount = Mathf.Lerp(greenImage.fillAmount, curExp / maxExp, Time.deltaTime * 5f);
        KeyboardUse();
        FindExp();
    }
    public void onHit(int dmg)
    {
        GameObject Dmg = Instantiate(dmgPr, transform.position + new Vector3(0, 1.5f), transform.rotation);
        Dmg.GetComponent<Dmg>().SetText(dmg,true);
        Hp -= dmg;
    }
    public void ExpUp(int mount)
    {
        curExp += mount;
        curExp += mount;
        if (curExp > maxExp)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        Level++;
        levelT.text = "LV:"+Level;
        curExp = 0;
        maxExp += 30;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back") curJumpCount = 0;
        if (collision.gameObject.tag == "Exp")
        {
            ExpUp(collision.gameObject.GetComponent<Exp>().mount);
            Destroy(collision.gameObject);
        }
    }
    
}
