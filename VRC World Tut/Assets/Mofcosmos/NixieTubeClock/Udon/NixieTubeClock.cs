using System;
using UdonSharp;
using UnityEngine;

namespace Mofcosmos.NixieTubeClock
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class NixieTubeClock : UdonSharpBehaviour
    {
        [SerializeField]
        [Tooltip("更新対象のマテリアル参照値")]
        int materialIndex;

        [SerializeField]
        [Tooltip("更新対象のRenderer")]
        Renderer[] renderers;

        /// <summary>
        /// 初期化。
        /// </summary>
        void Start()
        {
            UpdateClock();
        }

        /// <summary>
        /// 時計を更新する。
        /// </summary>
        public void UpdateClock()
        {
            var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
            SetTextureOffset(renderers[0], 0f, currentTime.Hour / 10 * 0.1f);
            SetTextureOffset(renderers[1], 0f, currentTime.Hour % 10 * 0.1f);
            SetTextureOffset(renderers[2], 0f, currentTime.Minute / 10 * 0.1f);
            SetTextureOffset(renderers[3], 0f, currentTime.Minute % 10 * 0.1f);
            SendCustomEventDelayedSeconds(nameof(UpdateClock), 60 - currentTime.Second);
        }

        /// <summary>
        /// TextureOffsetを設定する。
        /// </summary>
        /// <param name="renderer">Renderer</param>
        /// <param name="x">オフセットx</param>
        /// <param name="y">オフセットy</param>
        void SetTextureOffset(Renderer renderer, float x, float y)
        {
            renderer.materials[materialIndex].SetTextureOffset("_MainTex", new Vector2(x, y));
        }
    }
}
