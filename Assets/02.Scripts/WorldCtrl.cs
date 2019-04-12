//创建日期：2019/3/28
//版本：    v0.01
//说明：    承载内核world，负责world与外壳交互数据

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets._02.Scripts;
using System.Xml;

public class WorldCtrl : MonoBehaviour {
    World world;

    public Text txCountDown;
    public Text showMoney;
    public Text showOre;
    public Text showWood;

    public PlayerControl playerControler;
    public Transform spawnPoint;
    public List<Turn> turnInfoSet;
    public List<GameObject> enemyPrefabs;

    public float spawnInterval = 1.0f;


    
    private int synCount = 1;
    private bool enemyClear;
    private float lastSpawnTime;

    private void Awake()
    {
        world = World.GetInstance();
        StartCoroutine(SynCore());
        showMoney.text = world.money.ToString();
        showWood.text = world.wood.ToString();
        showOre.text = world.ore.ToString();

        InitTurnInfo();
    }
    void Start () {
        world.player = playerControler.playerCore;
        NextTurnActive();
    }
	
    void InitTurnInfo()
    {
        turnInfoSet = new List<Turn>();

        
        string xmlString = Resources.Load("xml/TurnList").ToString();
        
        XmlDocument document = new XmlDocument();
        document.LoadXml(xmlString);
        XmlNode root = document.SelectSingleNode("turns");
        XmlNodeList turns = root.SelectNodes("./turn");
        XmlNode curNode;
        XmlNodeList enemies;
        
        for (int i=0; i<turns.Count; ++i)
        {
            curNode = turns[i];
            enemies = curNode.SelectNodes("./enemy");
            Turn temp;
            temp.enemies = new List<EnemyTurnInfo>();
            temp.spawnTime = float.Parse(curNode.Attributes["spawntime"].Value);
            temp.restTime = float.Parse(curNode.Attributes["resttime"].Value);
            for(int j=0; j<enemies.Count; ++j)
            {
                EnemyTurnInfo temp2;
                temp2.amount = int.Parse(enemies[j].Attributes["amount"].Value);
                temp2.enemyOri = new EnemyCore(int.Parse(enemies[j].Attributes["id"].Value));
                temp2.enemyPrefName = enemies[j].Attributes["pref"].Value.ToString();
                temp.enemies.Add(temp2);
            }
            turnInfoSet.Add(temp);
        }
    }

    IEnumerator SynCore()  //固定间隔同步world内核数据
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
        }
    }

    //IEnumerator SpawnEnemy()    //测试时先设置无限生成敌人，后面需要创建条件生成逻辑
    //{
    //    while (true)
    //    {
    //        Instantiate(enemy01, spawnPoint.position, new Quaternion());
    //        yield return new WaitForSeconds(30.0f);
            
    //    }
    //}

    void Pause()    //暂停游戏
    {

    }

    void Resume()   //继续游戏
    {

    }

    public void EnemyDie(EnemyCore enemy)     //敌人死亡
    {
        world.money += enemy.MONEY;
        showMoney.text = world.money.ToString();
    }

    void TurnFinish()   //当前波数完毕
    {
        world.turnState = TurnState.rest;
        world.restTimeStamp = Time.time;    //记录进入休息的时间节点
        txCountDown.gameObject.SetActive(true);
    }

    void NextTurnActive()   //开始进行下一波
    {
        world.turnCount += 1;
        Debug.Log(world.turnCount);
        txCountDown.gameObject.SetActive(false);
        world.turnState = TurnState.spawning;
        world.spawnEnemyCount = 0;  //用spawntime和间隔替代
        world.preSpawnTime = new List<float>(turnInfoSet[world.turnCount].enemies.Count);   
        world.spawnInterval = new List<float>(turnInfoSet[world.turnCount].enemies.Count);  //为每个敌人分别设置生成间隔
        for (int i=0; i< turnInfoSet[world.turnCount].enemies.Count; ++i)
        {
            world.preSpawnTime.Add(Time.time);
            world.spawnInterval.Add(turnInfoSet[world.turnCount].spawnTime / turnInfoSet[world.turnCount].enemies[i].amount);
        }
        world.spawnBeginTime = Time.time;
    }


    void FixedUpdate()
    {
        if (world.gameState == GameState.resume)
        {
            if (world.turnState == TurnState.spawning)   //若当前波敌人还在刷新进攻
            {
                if (Time.time - world.spawnBeginTime > turnInfoSet[world.turnCount].spawnTime)  //若敌人可以不再产生
                {
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    {
                        TurnFinish();
                    }
                }
                else
                {
                    for (int i = 0; i < world.preSpawnTime.Count; ++i)
                    {
                        if (Time.time - world.preSpawnTime[i] > world.spawnInterval[i])
                        {
                            GameObject tempEnemy = Instantiate((GameObject)Resources.Load(string.Format("prefabs/{0}", turnInfoSet[world.turnCount].enemies[i].enemyPrefName)), spawnPoint.position, new Quaternion());
                            tempEnemy.GetComponent<EnemyControl>().BindCore((EnemyCore)turnInfoSet[world.turnCount].enemies[i].enemyOri.Clone());
                            world.preSpawnTime[i] = Time.time;
                        }
                    }
                }
            }
            else   //当前波进攻结束，正在休息整顿中
            {
                if (world.turnCount == turnInfoSet.Count - 1)  //若当前波为最后一波
                {
                    Debug.Log("所有波都已结束");
                }
                else
                {
                    if (Time.time - world.restTimeStamp < turnInfoSet[world.turnCount].restTime) //休息时间未结束
                    {
                        txCountDown.text = string.Format("<b>整备计时：{0:f0}</b>", turnInfoSet[world.turnCount].restTime - Time.time + world.restTimeStamp);
                    }
                    else    //休息时间结束
                    {
                        NextTurnActive();

                    }
                }

            }


        }
        else    //若游戏处于暂停状态
        {

        }
    }
}
