using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    
    // Start is called before the first frame update
    [Header("Set in Insepector")]
    public GameObject targetPrefab;
    public float speed;
    public GameObject BackWall;
    public Text speedGT;
    public int MaxTargetsOnScreen;
    public List<GameObject> targetList;
    

    private float WallX = 14f;
    private float WallY = 8f;
    private int targetNum = 0;

    private float z = -0.5f;
    void Start()
    {
        targetList = new List<GameObject>();
        Invoke("SpawnTarget", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetList.Count >= MaxTargetsOnScreen)
        {
            SceneManager.LoadScene("Scene_0");
        }
    }

    private void FixedUpdate()
    {
   
        speedGT.text = speed.ToString("F2") + "/s";
        speed = speed + 0.002f;
        if(speed > HighScore.score)
        {
            HighScore.score = speed;
        }
       
    }

    public void SpawnTarget()
    {
        GameObject target = Instantiate<GameObject>(targetPrefab);
   
        target.name = "target"+targetNum;
        targetNum = targetNum + 1;
        Vector3 pos = Vector3.zero;
        var hitColliders = Physics.OverlapSphere(pos, 0.5f);
        do
        {
            pos.z = z;
            pos.x = getXPos(target);
            pos.y = getYPos(target);
            //Debug.Log("POS :" + pos);
            hitColliders = Physics.OverlapSphere(pos, 0.5f);
        }
        while (hitColliders.Length > 0);
        
        target.transform.position = pos;
        targetList.Add(target);
  
        Invoke("SpawnTarget", 1/speed);
     
    }

    public void removeTarget(int index)
    {
        targetList.RemoveAt(index);
    }

    public float getXPos(GameObject target)
    {
        //Debug.Log("XXXXX:  " + Random.Range(BackWall.transform.position.x - (WallX / 2) + (target.GetComponent<SphereCollider>().radius * 2), BackWall.transform.position.x + (WallX / 2) - (target.GetComponent<SphereCollider>().radius * 2)));
       float xval =Random.Range(BackWall.transform.position.x-(WallX/2)+(target.GetComponent<SphereCollider>().radius*2), BackWall.transform.position.x+(WallX/2) - (target.GetComponent<SphereCollider>().radius * 2));
        
      
       return xval;
    
    }
    public float getYPos(GameObject target)
    {
        //Debug.Log("YYYYY:   " + Random.Range(BackWall.transform.position.y - (WallY / 2) + (target.GetComponent<SphereCollider>().radius * 2), BackWall.transform.position.y + (WallY / 2) - (target.GetComponent<SphereCollider>().radius * 2)));
        return Random.Range(BackWall.transform.position.y-(WallY/2)+(target.GetComponent<SphereCollider>().radius*2), BackWall.transform.position.y+(WallY/2) - (target.GetComponent<SphereCollider>().radius *2));
    }
}
