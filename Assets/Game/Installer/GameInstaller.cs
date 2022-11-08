using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerMove>().AsSingle();
        Container.Bind<PlayerExtringuishing>().AsSingle();
    }
}
