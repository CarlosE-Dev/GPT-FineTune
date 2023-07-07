namespace GPT_FineTune.Domain.Exceptions
{
    public class FineTuneJobNotFoundException : Exception
    {
        public FineTuneJobNotFoundException() : base("Fine Tune Job not found.") { }
    }
}
