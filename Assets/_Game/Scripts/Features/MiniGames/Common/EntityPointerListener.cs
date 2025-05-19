using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class EntityPointerListener:MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
    {
        public Action<PointerEventData> onPointerDown;
        public Action<PointerEventData> onPointerUp;

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUp?.Invoke(eventData);
        }
    }
}