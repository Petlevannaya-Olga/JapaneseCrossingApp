namespace JapaneseCrossingApp
{
    public static class GameRules
    {
        public static void ValidateBoatCanMove(IReadOnlyCollection<Person> passengers)
        {
            if (passengers.Count == 0)
            {
                throw new InvalidOperationException("Лодка не может двигаться без пассажиров");
            }

            if (!passengers.Any(passenger => passenger.CanOperateBoat))
            {
                throw new InvalidOperationException("В лодке нет персонажа, который может ей управлять");
            }

            if (passengers.OfType<Criminal>().Any() && !passengers.OfType<Police>().Any())
            {
                throw new InvalidOperationException("Преступника нельзя перевозить без полицейского");
            }
        }

        public static void ValidateRiverSide(IEnumerable<Person> passengers)
        {
            var list = passengers.ToList();

            var hasPolice = list.OfType<Police>().Any();
            var hasCriminal = list.OfType<Criminal>().Any();
            var hasMother = list.OfType<Mother>().Any();
            var hasFather = list.OfType<Father>().Any();
            var hasSon = list.OfType<Son>().Any();
            var hasDaughter = list.OfType<Daughter>().Any();

            if (hasCriminal && list.Count > 1 && !hasPolice)
            {
                throw new InvalidOperationException("Преступника нельзя оставлять с другими персонажами без полицейского");
            }

            if (hasMother && hasSon && !hasFather)
            {
                throw new InvalidOperationException("Сыновей нельзя оставлять с матерью без отца");
            }

            if (hasFather && hasDaughter && !hasMother)
            {
                throw new InvalidOperationException("Дочерей нельзя оставлять с отцом без матери");
            }
        }
    }
}
