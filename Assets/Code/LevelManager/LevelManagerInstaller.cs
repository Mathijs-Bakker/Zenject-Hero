using Code;
using Zenject;

public class LevelManagerInstaller : MonoInstaller<LevelManagerInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle();
    }
}