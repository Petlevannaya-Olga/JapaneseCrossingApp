namespace JapaneseCrossingApp
{
	public static class GameRules
	{
		public static void ValidateBoatCanMove(
			IReadOnlyCollection<Person> passengers)
		{
			if (passengers.Count == 0)
			{
				throw new InvalidOperationException(
					"Лодка не может двигаться без пассажиров");
			}

			if (passengers.All(person => !person.CanOperateBoat))
			{
				throw new InvalidOperationException(
					"В лодке нет персонажа, который умеет управлять лодкой");
			}
		}

		public static void ValidateRiverSide(
			IReadOnlyCollection<Person> passengers)
		{
			ValidateCriminalRule(passengers);
			ValidateFatherAndDaughtersRule(passengers);
			ValidateMotherAndSonsRule(passengers);
		}

		private static void ValidateCriminalRule(
			IReadOnlyCollection<Person> passengers)
		{
			bool hasCriminal = passengers.OfType<Criminal>().Any();
			bool hasPolice = passengers.OfType<Police>().Any();

			if (!hasCriminal || hasPolice)
				return;

			bool hasSomeoneElse = passengers.Any(
				person => person is not Criminal);

			if (hasSomeoneElse)
			{
				throw new InvalidOperationException(
					"Преступника нельзя оставлять с другими персонажами без полицейского");
			}
		}

		private static void ValidateFatherAndDaughtersRule(
			IReadOnlyCollection<Person> passengers)
		{
			bool hasFather = passengers.OfType<Father>().Any();
			bool hasMother = passengers.OfType<Mother>().Any();
			bool hasDaughter = passengers.OfType<Daughter>().Any();

			if (hasFather && hasDaughter && !hasMother)
			{
				throw new InvalidOperationException(
					"Отца нельзя оставлять с дочерьми без матери");
			}
		}

		private static void ValidateMotherAndSonsRule(
			IReadOnlyCollection<Person> passengers)
		{
			bool hasMother = passengers.OfType<Mother>().Any();
			bool hasFather = passengers.OfType<Father>().Any();
			bool hasSon = passengers.OfType<Son>().Any();

			if (hasMother && hasSon && !hasFather)
			{
				throw new InvalidOperationException(
					"Мать нельзя оставлять с сыновьями без отца");
			}
		}
	}
}