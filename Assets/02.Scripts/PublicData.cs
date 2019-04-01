//创建日期：2019/3/29
//版本：    v0.01
//说明：    记录公用的静态数据及数据类型

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public struct Turn
    {
        public UnityEngine.GameObject enemy;
        public int enemyCount;
        public float restTime;
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
