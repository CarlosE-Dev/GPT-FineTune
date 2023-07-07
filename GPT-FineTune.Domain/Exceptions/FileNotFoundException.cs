namespace GPT_FineTune.Domain.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException() : base("File not found.") { }
    }
}
