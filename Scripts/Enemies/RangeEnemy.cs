using AbstractClasses;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class RangeEnemy: Enemy, IShootable
    {
        public GameObject Bullet { get; set; }
        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }
}