//创建日期：2019/3/27
//版本：    v0.01
//说明：    记录敌人的内核数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;

namespace Assets._02.Scripts
{
    public class EnemyCore:ICloneable
    {
        private int _atk;
        private int _def;
        private int _maxhealth;
        private int _health;
        private float _speed;
        private int _money;
        public int ATK
        {
            get
            {
                return _atk;
            }
        }
        public int DEF
        {
            get
            {
                return _def;
            }
        }
        public int HP
        {
            get
            {
                return _health;
            }
        }
        public float SPD
        {
            get
            {
                return _speed;
            }
        }
        public int MAXHP
        {
            get
            {
                return _maxhealth;
            }
        }
        public int MONEY
        {
            get
            {
                return _money;
            }
        }
        public myVector3 position;

        public EnemyCore(int id)
        {
            Debug.Log(id);
            string xmlString = Resources.Load("xml/EnemyList").ToString();
            string xPath = string.Format("./enemy[@id='{0:D3}']", id);
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);
            XmlNode root = document.SelectSingleNode("enemies");
            XmlNode aimNode = root.SelectSingleNode(xPath);


            _atk = int.Parse(aimNode.Attributes["atk"].Value);
            _def = int.Parse(aimNode.Attributes["def"].Value);
            _maxhealth = int.Parse(aimNode.Attributes["hp"].Value);
            _health = _maxhealth;
            _speed = float.Parse(aimNode.Attributes["spd"].Value);
            _money = int.Parse(aimNode.Attributes["money"].Value);
        }

        public bool BloodDeduction(float hp)
        {
            _health -= (int)hp;
            if (_health <= 0)
                return true;
            else
                return false;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
