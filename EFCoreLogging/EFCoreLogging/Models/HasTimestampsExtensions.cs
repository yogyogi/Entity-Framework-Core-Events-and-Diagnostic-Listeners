namespace EFCoreLogging.Models
{
    public static class HasTimestampsExtensions
    {
        public static string ToStampString(this IHasTimestamps entity)
        {
            return $"{GetStamp("Added", entity.Added)}{GetStamp("Modified", entity.Modified)}{GetStamp("Deleted", entity.Deleted)}";
        }

        static string GetStamp(string state, DateTime? dateTime) => dateTime == null ? "" : $" {state} on: {dateTime}";
    }
}
