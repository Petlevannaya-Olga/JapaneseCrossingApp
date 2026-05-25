namespace JapaneseCrossingApp
{
    public class RiverSide
    {
        private readonly List<Person> _passengers = new();

        public RiverSide(SideKind side)
        {
            Side = side;
        }

        public SideKind Side { get; }
        public IReadOnlyList<Person> Passengers => _passengers;

        public void Add(Person person)
        {
            if (!_passengers.Contains(person))
            {
                _passengers.Add(person);
            }
        }

        public void AddRange(IEnumerable<Person> passengers)
        {
            foreach (var passenger in passengers)
            {
                Add(passenger);
            }
        }

        public void Remove(Person person)
        {
            _passengers.Remove(person);
        }
    }
}
