namespace RavenDBDemo
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, FullName: {1} name: {2}", Id, FullName, Name);
        }
    }
}