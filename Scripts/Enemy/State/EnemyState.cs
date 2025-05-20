public abstract class EnemyState
{
    protected IStateChanger StateChanger;

    public EnemyState(IStateChanger stateChanger)
    {
        StateChanger = stateChanger;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
