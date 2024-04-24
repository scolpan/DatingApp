namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob) 
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var age = today.Year - dob.Year;

        //If before bday, subtract a year so age is not +1
        if (dob > today.AddYears(-age)) age--;

        return age;

    }
}
