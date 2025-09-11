using static System.Enum;

namespace AirlinePassengerDiscountPolicy
{
    public class AirlineDiscountPolicy
    {
        public static decimal CalculateDiscounted(int age, Destination destination, DaysOfWeek dayOfWeek, int days = 1)
        {
            if (age is < 0 or > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 120.");
            }
            if (days <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(days), "Days must be non-negative.");
            }
            if (!IsDefined(typeof(Destination), destination))
            {
                throw new ArgumentOutOfRangeException(nameof(destination), "Invalid destination.");
            }
            if (!IsDefined(typeof(DaysOfWeek), dayOfWeek))
            {
                throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Invalid day of the week.");
            }

            return dayOfWeek switch
            {
                //TC1
                var d when destination == Destination.India && age > 18 && d != DaysOfWeek.Monday &&
                           d != DaysOfWeek.Friday && days < 6 => 0.20m // 20% discount
                ,
                //TC2
                DaysOfWeek.Monday or DaysOfWeek.Friday when destination == Destination.India && age > 18 && days >= 6 =>
                    0.10m // 10% discount
                ,
                //TC3
                var d when destination == Destination.India && age > 18 && days >= 6 && d != DaysOfWeek.Monday &&
                           d != DaysOfWeek.Friday => 0.30m // 30% discount
                ,
                //TC4
                DaysOfWeek.Monday or DaysOfWeek.Friday when destination == Destination.India && age > 18 && days < 6 =>
                    0 // No discount
                ,
                //TC5
                var d when destination == Destination.International && age > 18 && days < 6 && d != DaysOfWeek.Monday &&
                           d != DaysOfWeek.Friday => 0.25m // 25% discount
                ,
                //TC6
                var d when destination == Destination.International && age > 18 && days >= 6 &&
                           d != DaysOfWeek.Monday && d != DaysOfWeek.Friday => 0.35m // 35% discount
                ,
                //TC7
                DaysOfWeek.Monday or DaysOfWeek.Friday when destination == Destination.International && age > 18 &&
                                                            days >= 6 => 0.10m // 10% discount
                ,
                //TC8
                DaysOfWeek.Monday or DaysOfWeek.Friday when destination == Destination.International && age > 18 &&
                                                            days < 6 => 0.00m // 10% discount
                ,
                //TC9
                _ when age is > 2 and < 18 && days < 6 => 0.40m // 40% discount
                ,
                //TC10
                _ when age is > 2 and < 18 && days >= 6 => 0.50m // 50% discount
                ,
                //TC11
                _ when age <= 2 => 1.00m // 100% discount (free ticket)
                ,
                _ => 0.0m
            };
        }

    }
}

public enum Destination
{
    India,
    International
}
public enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}