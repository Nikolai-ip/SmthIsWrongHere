using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class ZoneTrigger2D:BaseTrigger
    {
        private void OnTriggerEnter2D(Collider2D other) => RaiseTriggerEnter(other.gameObject);
        private void OnTriggerStay2D(Collider2D other) => RaiseTriggerStay(other.gameObject);
        private void OnTriggerExit2D(Collider2D other) => RaiseTriggerExit(other.gameObject);
    }
}