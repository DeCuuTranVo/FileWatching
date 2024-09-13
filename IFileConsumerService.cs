namespace FileWatching
{
    public interface IFileConsumerService
    {
        Task ConsumeFile(string pathToFile);
    }
}