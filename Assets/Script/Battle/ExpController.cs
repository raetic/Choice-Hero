using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{   
    [SerializeField] private GameObject expPrefebs;
    Queue<Exp> expQueue = new Queue<Exp>(); //exp를 담을 큐
    public static ExpController instance = null; 

    void Awake()
    {
        if (null == instance)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
            for(int i = 0; i < 30; i++)
            {
                CreateObject(); //초기에 30개의 exp를 생성함
            }
        }
        else
        {        
            Destroy(this.gameObject);
        }
    }
    Exp CreateObject()
    {
        Exp newExp = Instantiate(expPrefebs).GetComponent<Exp>();
        newExp.gameObject.SetActive(false);
        newExp.transform.SetParent(instance.transform);
        return newExp; 
    }
    public Exp GetObject(Transform tra) //exp오프젝트가 필요할 때 다른 스크립트에서 불러오면 됨
    {      
        if (expQueue.Count > 0)
        {
            Exp expInQueue = expQueue.Dequeue();
            expInQueue.gameObject.SetActive(true);
            expInQueue.transform.SetParent(null);
            expInQueue.transform.position = tra.position;
            return expInQueue;
        }
        else
        {
            Exp newExp= instance.CreateObject();
            newExp.gameObject.SetActive(true);
            newExp.transform.SetParent(null);
            newExp.transform.position = tra.position;
            return newExp;
        }
    }
    public void ReturnObjectToQueue(Exp exp)
    {
        exp.gameObject.SetActive(false);
        exp.transform.SetParent(instance.transform);
        instance.expQueue.Enqueue(exp);
    }
}
