public abstract class DayState
{
    private string stateName;
    public string StateName { get => stateName; }
    private int grantedActionPoints;

    private int spentActionPoints;
    public int SpentActionPoints { get => spentActionPoints; set { if (value + spentActionPoints > grantedActionPoints) spentActionPoints = grantedActionPoints;} }
    public int GrantedActionPoints { get => grantedActionPoints; }

    public virtual void Init(string statename, int grantedactionpoints)
    {
        stateName = statename;
        grantedActionPoints = grantedactionpoints;
    }
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}
