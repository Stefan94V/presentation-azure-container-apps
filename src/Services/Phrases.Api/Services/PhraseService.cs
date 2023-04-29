namespace Phrases.Api.Services;

public class PhraseService : IPhraseService
{
    private readonly IDictionary<string, string[]> _phrasesPerDay = new Dictionary<string, string[]>();


    public PhraseService()
    {
        SetPhrases();
    }

    public string GetPhraseOfDay(string dayOfWeek)
    {
        if (!_phrasesPerDay.ContainsKey(dayOfWeek))
            throw new ArgumentException("Invalid day of week.");

        var phrases = _phrasesPerDay[dayOfWeek];
        var index = new Random().Next(phrases.Length);
        return phrases[index];
    }
    
    private void SetPhrases()
    {
        // Phrases for Monday
        string[] mondayPhrases = new string[]
        {
            "It's a new week and a fresh start!",
            "Monday blues? Turn it into Monday motivation!",
            "Mondays are tough, but so are you!",
            "Rise and shine, it's Monday time!",
        };
        _phrasesPerDay.Add("Monday", mondayPhrases);

        // Phrases for Tuesday
        string[] tuesdayPhrases = new string[]
        {
            "Taco Tuesday, let's eat!",
            "Tuesday is for two things: coffee and coding.",
            "Tuesday is just Monday's slightly better-looking cousin.",
            "Tuesday: the day when everything starts to click.",
        };
        _phrasesPerDay.Add("Tuesday", tuesdayPhrases);

        // Phrases for Wednesday    
        string[] wednesdayPhrases = new string[]
        {
            "Hump day! The week is half over!",
            "Wednesday is a good day to review your goals.",
            "Keep calm, it's only Wednesday.",
            "Wednesday: the bridge between Monday and Friday.",
        };
        _phrasesPerDay.Add("Wednesday", wednesdayPhrases);

        // Phrases for Thursday
        string[] thursdayPhrases = new string[]
        {
            "Thursday is Friday's eve. Let's get excited!",
            "It's almost the weekend, hang in there!",
            "Thursday is a good day to reflect on your week.",
            "Thursday: the day when you can almost taste the weekend.",
        };
        _phrasesPerDay.Add("Thursday", thursdayPhrases);

        // Phrases for Friday
        string[] fridayPhrases = new string[]
        {
            "TGIF! Let's celebrate the end of the week!",
            "Friday is a good day for pizza and beer.",
            "Friday: the day when work is over and fun begins.",
            "It's Friday! Time to relax and unwind.",
        };
        _phrasesPerDay.Add("Friday", fridayPhrases);

        // Phrases for Saturday
        string[] saturdayPhrases = new string[]
        {
            "Saturday vibes: lazy and relaxed.",
            "Weekends are for adventures and exploring.",
            "Saturday is a good day to recharge and rejuvenate.",
            "It's the weekend, let's make the most of it!",
        };
        _phrasesPerDay.Add("Saturday", saturdayPhrases);

        // Phrases for Sunday
        string[] sundayPhrases = new string[]
        {
            "Lazy Sunday: the perfect day for doing nothing.",
            "Sunday is a good day to prep for the week ahead.",
            "Sunday is a day for brunch and mimosas.",
            "Sunday: the day when you can catch up on your reading.",
        };
        _phrasesPerDay.Add("Sunday", sundayPhrases);
    }
}