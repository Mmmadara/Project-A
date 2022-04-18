using UnityEngine;

namespace Interfaces
{
    public interface IShootable
    {
        GameObject Bullet { get; set; }

        void Shoot();
    }
}