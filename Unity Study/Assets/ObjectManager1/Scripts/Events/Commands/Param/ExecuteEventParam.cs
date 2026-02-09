
using ObjectManager1;

public class ExecuteEventParam : IParam
{
    public ObjectBase TargetObject { get; set; }
    public EventId EventId { get; set; }
}