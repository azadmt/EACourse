namespace Framework.Core.Domain
{
    public interface IGuidProvider
    {
        Guid GetGuid();
    }

    public class DefaultGuidProvider: IGuidProvider
    {
      public  Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
