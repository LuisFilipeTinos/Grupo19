using Microsoft.Win32.SafeHandles;
using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class DatabaseConnection : IDisposable
{
    public SqliteConnection con { get; private set; } = new SqliteConnection();
    public string connectionString { get; private set; }

    private bool _disposedValue;

    private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    public DatabaseConnection(string connectionString)
    {
        this.con.ConnectionString = connectionString;
    }

    public async Task<SqliteConnection> ConnectAsync()
    {
        if (con.State == System.Data.ConnectionState.Closed)
            await con.OpenAsync();

        return con;
    }

    public async Task<SqliteConnection> DisconnectAsync()
    {
        if (con.State == System.Data.ConnectionState.Open)
            await con.CloseAsync();

        return con;
    }

    //Faz o dispose do objeto após o uso
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _safeHandle?.Dispose();
                _safeHandle = null;
            }

            _disposedValue = true;
        }
    }
}
