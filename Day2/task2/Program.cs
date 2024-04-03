
Dictionary<string, int> WordFreqCount(string words)
{
    Dictionary<string, int> wordFreq = new Dictionary<string, int>();
    words.Split(' ').ToList().ForEach(word =>
    {
        if (wordFreq.ContainsKey(word.ToLower()))
            wordFreq[word.ToLower()]++;
        else
            wordFreq[word.ToLower()] = 1;
    });
    return wordFreq;
}
Dictionary<string, int> wordFreqCount = WordFreqCount("I am a boy");
IEnumerable<string> wordFreqPairs =
from wordFreq in wordFreqCount
select $"{wordFreq.Key}: {wordFreq.Value}";

foreach (var item in wordFreqPairs)
{
    Console.WriteLine(item);
}
