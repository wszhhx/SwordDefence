//创建日期：2019/3/27
//版本：    v0.01
//说明：    记录全局数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._02.Scripts
{
    public class World
    {
        private static World _world = null;
        public PlayerCore player;

        public float gameTime = 0;              //游戏时间（秒）
        public float turnTime = 0;              //当前波进行时间
        public float preSpawnTime = 0;          //上一个敌人刷新的时间节点
        public float restTimeStamp = 0;
        public int turnCount = 0;               //波数记录
        public int spawnEnemyCount = 0;         //记录已经生成的敌人数

        public Resource resource;
        public int money = 0;                   //金钱
        public int ore = 0;                     //矿石
        public int wood = 0;                    //木头

        public TurnState turnState = TurnState.spawning;               //记录当前波进行状态
        public GameState gameState = GameState.resume;                 //记录当前游戏状态

        public Vector3 camPosition;             //记录摄像机位置


        public World()                          //这里负责查找/建立存档文件并还原游戏所有状态
        {

        }
        public static World GetInstance()
        {
            if(_world == null)
            {
                _world = new World();
            }
            return _world;
        }
    }
}
