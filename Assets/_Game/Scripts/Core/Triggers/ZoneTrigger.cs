using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class ZoneTrigger : BaseTrigger
    {
        private void OnTriggerEnter(Collider other) => RaiseTriggerEnter(other.gameObject);
        private void OnTriggerStay(Collider other) => RaiseTriggerStay(other.gameObject);
        private void OnTriggerExit(Collider other) => RaiseTriggerExit(other.gameObject);
    }
}