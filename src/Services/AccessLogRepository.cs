using Dapper;
using JovemNerd.Rss.Filter.Models;
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JovemNerd.Rss.Filter.Services
{
    public class AccessLogRepository : IAccessLogRepository
    {
        private const string Database = "access-log.sqlite";
        private static readonly SemaphoreSlim creationLock = new(1, 1);

        public async Task Log(NerdcastKind kind, string userAgent, int downloadTime)
        {
            await CreateDatabaseIfNeeded();

            using var connection = new SqliteConnection($"Data Source={Database};");
            await connection.OpenAsync();

            await connection.ExecuteAsync(@"
                INSERT INTO AccessLog 
                (
                    Timestamp, 
                    NerdcastKind, 
                    UserAgent, 
                    DownloadTime
                ) 
                VALUES 
                (
                    @Timestamp, 
                    @NerdcastKind, 
                    @UserAgent, 
                    @DownloadTime
                )
            ", new
            {
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                NerdcastKind = kind.ToString(),
                UserAgent = userAgent,
                DownloadTime = downloadTime
            });
        }

        private static async Task CreateDatabaseIfNeeded()
        {
            if (File.Exists(Database))
                return;

            await creationLock.WaitAsync();

            try
            {
                if (File.Exists(Database))
                    return;

                File.WriteAllBytes(Database, Array.Empty<byte>());
                
                using var connection = new SqliteConnection($"Data Source={Database};");
                await connection.OpenAsync();

                await connection.ExecuteAsync(@"
                    CREATE TABLE AccessLog 
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp INTEGER NOT NULl,
                        NerdcastKind TEXT NOT NULL,
                        UserAgent TEXT NOT NULL,
                        DownloadTime INTEGER NOT NULL
                    )
                ");
            }
            finally
            {
                creationLock.Release();
            }
        }
    }

    public interface IAccessLogRepository
    {
        Task Log(NerdcastKind kind, string userAgent, int downloadTime);
    }
}