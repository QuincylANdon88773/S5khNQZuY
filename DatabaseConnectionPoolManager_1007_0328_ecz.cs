// 代码生成时间: 2025-10-07 03:28:26
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

// DatabaseConnectionPoolManager class encapsulates the functionality of managing
// database connections using a pool. It is designed to be thread-safe and
// reusable.
public class DatabaseConnectionPoolManager
{
    private readonly ConcurrentBag<DbConnection> _connectionPool;
    private readonly string _connectionString;
    private readonly int _maxPoolSize;
    private readonly Type _connectionType;

    public DatabaseConnectionPoolManager(string connectionString, int maxPoolSize, Type connectionType)
    {
        _connectionString = connectionString;
        _maxPoolSize = maxPoolSize;
        _connectionPool = new ConcurrentBag<DbConnection>();
        _connectionType = connectionType;
    }

    // Initializes the connection pool with the specified number of connections.
    public void InitializePool()
    {
        for (int i = 0; i < _maxPoolSize; i++)
        {
            var connection = (DbConnection)Activator.CreateInstance(_connectionType);
            connection.ConnectionString = _connectionString;
            connection.Open();
            _connectionPool.Add(connection);
        }
    }

    // Retrieves a connection from the pool. If no connection is available, it waits until one becomes available.
    public DbConnection GetConnection()
    {
        while (true)
        {
            if (_connectionPool.TryTake(out DbConnection connection))
            {
                if (connection.State == ConnectionState.Open)
                {
                    return connection;
                }
                else
                {
                    // Close and remove the connection if it's not open.
                    connection.Close();
                    continue;
                }
            }
            // In a real-world scenario, you would implement a timeout here to avoid an infinite loop.
        }
    }

    // Returns a connection to the pool.
    public void ReturnConnection(DbConnection connection)
    {
        if (connection.State == ConnectionState.Open)
        {
            _connectionPool.Add(connection);
        }
        else
        {
            // Handle the case where the connection is not open.
            connection.Close();
        }
    }

    // Releases all connections in the pool and closes them.
    public void ReleaseAllConnections()
    {
        foreach (var connection in _connectionPool)
        {
            connection.Close();
        }
        _connectionPool.Clear();
    }

    // Disposes all connections in the pool and clears the pool.
    public void Dispose()
    {
        ReleaseAllConnections();
    }
}
