using System.Threading.Tasks;

public interface ITurretStrategy
{
    Task StartMove();
    Task StopMove();
    void Update(float deltaTime);
}
