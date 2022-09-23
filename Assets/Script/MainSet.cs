using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Newtonsoft.Json;
public class MainSet : MonoBehaviour
{
    [SerializeField] MeshRenderer mountain;
    [SerializeField] MeshRenderer ground;
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
      
            mountain.material.mainTextureOffset += new Vector2(0.05f * Time.deltaTime, 0);

        ground.material.mainTextureOffset += new Vector2(0.2f * Time.deltaTime, 0);




    }
    public void goBattle()
    {
        string battleData = JsonUtility.ToJson(gameData);
        string path = Path.Combine(Application.persistentDataPath, "MyData.json");
        File.WriteAllText(path, battleData);
        SceneManager.LoadScene("battle");
    }
    private void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "MyData.json");
        if (File.Exists(path))
        {
            string battleData = File.ReadAllText(path);
            gameData= JsonUtility.FromJson<GameData>(battleData);

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
