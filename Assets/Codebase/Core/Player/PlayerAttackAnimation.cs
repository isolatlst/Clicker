using Codebase.Infrastructure.Utils;
using Codebase.UI.TextAnimation;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Codebase.Core.Player
{
    public class PlayerAttackAnimation : MonoBehaviour
    {
        [SerializeField] private WaveAnimation _textPrefab;
        [SerializeField] private Transform _parent;
        private ObjectPool<WaveAnimation> _textPool;

        private void Awake()
        {
            _textPool = new ObjectPool<WaveAnimation>(_textPrefab, 5, _parent);
        }

        public void Play(int damage)
        {
            var dmgGo = _textPool.GetFromPool();

            if (dmgGo.TryGetComponent<TMP_Text>(out var text))
                text.text = damage.ToString();

            dmgGo.gameObject.SetActive(true);
            dmgGo.Sequence.AppendCallback(() =>
            {
                dmgGo.gameObject.SetActive(false);
                _textPool.ReturnToPool(dmgGo);
            });
        }
    }
}