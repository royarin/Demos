using StackExchange.Redis;

public class RedisConnection
{
    private static Lazy<ConnectionMultiplexer>? lazyConnection;

    public RedisConnection(string connectionString)
    {
        lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(connectionString);
        });
    }

    public ConnectionMultiplexer? Connection
    {
        get
        {
            return lazyConnection?.Value;
        }
    }
}
