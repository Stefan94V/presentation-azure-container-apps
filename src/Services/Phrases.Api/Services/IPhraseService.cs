namespace Phrases.Api.Services;

public interface IPhraseService
{
    string GetPhraseOfDay(string dayOfWeek);
}