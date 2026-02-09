namespace ObjectManager1
{
    public class DoActionParam : IParam
    {
        public ObjectId ObjectId { get; set; }
        public EventId EventId { get; set; }
        public EventDataBase EventData { get; set; }
    }
}