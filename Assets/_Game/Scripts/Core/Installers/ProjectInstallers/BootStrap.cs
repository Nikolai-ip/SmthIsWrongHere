using UnityEngine;
using Zenject;

namespace _Game.Scripts.Core.Installers.ProjectInstallers
{
    public class BootStrap:MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("BootStrap Installer");
        }
    }
}