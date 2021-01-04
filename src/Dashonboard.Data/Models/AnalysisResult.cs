namespace Dashonboard.Data.Models
{
    public class AnalysisResult
    {
        public ActionType Action { get; set; }
        public MetricType Metric { get; set; }
        public string MetricName { get; set; }
    }

    public enum ActionType
    {
        Create,
        Remove
    }

    public enum MetricType
    {
        Timing,
        Datapoints
    }
}
