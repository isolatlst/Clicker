using UnityEngine;

namespace Codebase.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy-", menuName = "Enemies/New Enemy Info")]
    public class EnemyInfo : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _health;
        [SerializeField] private Sprite _sprite;

        public int Id => this._id;
        public int Health => this._health;
        public Sprite Sprite => this._sprite;
    }
}