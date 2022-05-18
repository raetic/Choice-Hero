using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Newtonsoft.Json;
public class MainSet : MonoBehaviour
{
    [SerializeField] GameObject[] mountain;
    [SerializeField] GameObject[] ground;
    [SerializeField] TextMeshProUGUI[] stats;
    [SerializeField] TextMeshProUGUI charaterName;
    [SerializeField] TextMeshProUGUI characterContent;
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject curCharacter;
    GameData gameData = new GameData();
    Data data = new Data();
    GameObject newObj;
    int curCharacterNo;
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            mountain[i].transform.Translate(new Vector3(0.2f, 0, 0) * Time.deltaTime);
            if (mountain[i].GetComponent<RectTransform>().position.x > 18)
            {

                mountain[i].transform.position -= new Vector3(17.7778f * 2, 0);
            }
            ground[i].transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
           
            if (ground[i].GetComponent<RectTransform>().position.x > 18)
            {
               
                ground[i].transform.position -= new Vector3(17.7778f*2, 0);
            }
        }
    }
    public void goBattle()
    {
        string gd = JsonConvert.SerializeObject(gameData);
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        File.WriteAllText(path, gd);
        SceneManager.LoadScene("battle");
    }
    private void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        if (File.Exists(path))
        {
            string gamedata = File.ReadAllText(path);
            gameData = JsonConvert.DeserializeObject<GameData>(gamedata);
        }
    }
    public void OnCharacterView()
    {
        curCharacterNo= gameData.curCharacter;
        newObj=Instantiate(characters[curCharacterNo],curCharacter.transform.position,transform.rotation);
        StringChange();
    }
    void StringChange()
    {
        charaterName.text=data.CharacterData[curCharacterNo].Name;
        characterContent.text = data.CharacterData[curCharacterNo].content;
        for(int i = 0; i < 8; i++)
        {if(i!=0)
            stats[i].text = "Lv" + (data.CharacterData[curCharacterNo].s[i]+5);
            else stats[i].text = "Lv" + (data.CharacterData[curCharacterNo].s[i] +2);
        }
    }
    public void ChangeCharacter(int i)
    {
        curCharacterNo += i;
        if (curCharacterNo == 7) curCharacterNo = 0;
        if (curCharacterNo == -1) curCharacterNo = 6;
        Destroy(newObj);
        newObj = Instantiate(characters[curCharacterNo], curCharacter.transform.position, transform.rotation);
        StringChange();
    }
    public void OffCharacterView()
    {if(newObj!=null)
        Destroy(newObj);
        gameData.curCharacter = curCharacterNo;
    }
}
