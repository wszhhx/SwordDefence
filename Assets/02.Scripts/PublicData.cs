//创建日期：2019/3/29
//版本：    v0.01
//说明：    记录公用的静态数据及数据类型

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._02.Scripts
{
    [Serializable]
    public struct myVector3
    {
        public float x;
        public float y;
        public float z;
        public myVector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [Serializable]
    public struct EnemyTurnInfo
    {
        public EnemyCore enemyOri;
        /// <summary>
        /// 敌人的内核实体原本
        /// </summary>

        public string enemyPrefName;
        /// <summary>
        /// 敌人的游戏实体预设
        /// </summary>

        public int amount;
        ///<summary>
        ///该敌人产生的数量
        ///</summary>
    }

    [Serializable]
    public struct Turn
    {
        public List<EnemyTurnInfo> enemies;
        /// <summary>
        /// 记录敌人基础信息（不带实体）
        /// </summary>
        public float spawnTime;
        /// <summary>
        /// 该波产生敌人的时间
        /// </summary>
        public float restTime;
        ///<summary>
        ///该波结束后的休息时间
        ///</summary>
       
    }

    [Serializable]
    public struct Resource
    { 
        public int money;
        public int wood;
        public int ore;
        public Resource(int m, int w, int o)
        {
            money = m;
            wood = w;
            ore = o;
        }
    }

    public enum GameState { resume = 0, pause };
    public enum TurnState { spawning = 0, rest };
    public enum towerState { building = 0, exist, attack };
    public enum towerAtkOption {distance = 0,health };

    public delegate void VoidVoid();

    static public class PublicData
    {
         
    }
}
