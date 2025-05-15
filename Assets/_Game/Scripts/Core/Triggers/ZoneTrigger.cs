using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class ZoneTrigger : BaseTrigger
    {
        private void OnTriggerEnter(Collider other) => RaiseTriggerEnter();
        private void OnTriggerExit(Collider other) => RaiseTriggerExit();
    }
}