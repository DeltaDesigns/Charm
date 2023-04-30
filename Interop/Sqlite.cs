﻿using System.Data.SQLite;
using System.Reflection;
using Tiger;

namespace Interop;

public struct SQLColumn
{
    public string Name { get; }
    public string Type { get; }
    public FieldInfo Field { get; }
    
    private static readonly Dictionary<Type, string> _typeToSqlTypeMap = new()
    {
        {typeof(sbyte), "INTEGER"},
        {typeof(ushort), "INTEGER"},
        {typeof(uint), "INTEGER"},
        {typeof(int), "INTEGER"},
        {typeof(string), "TEXT"},
        {typeof(FileHash), "TEXT"},
        {typeof(TigerHash), "TEXT"},
    };

    public SQLColumn(FieldInfo field)
    {
        Name = field.Name;
        Type = _typeToSqlTypeMap[field.FieldType];
        Field = field;
    }
    
    public override string ToString()
    {
        return $"{Name} {Type}";
    }
}

public struct SQLTable<T> where T : struct
{
    public string TableName { get; }
    public SQLColumn[] Columns { get; }

    public SQLTable()
    {
        var type = typeof(T);
        TableName = type.Name;
        Columns = type.GetFields()
            .Select(f => new SQLColumn(f))
            .ToArray();
    }
    
    public SQLTable(string tableName)
    {
        TableName = tableName;
        Columns = typeof(T).GetFields()
            .Select(f => new SQLColumn(f))
            .ToArray();
    }
    
    public void CreateTable(SQLiteConnection connection)
    {
        string columns = string.Join(", ", Columns);
        using (SQLiteCommand command = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {TableName} ({columns})", connection))
        {
            command.ExecuteNonQuery();
        }
    }
    
    public void InsertValues(SQLiteConnection connection, List<T> valuesList)
    {
        string columns = string.Join(", ", Columns.Select(c => c.Name));
        string values = string.Join(", ", Columns.Select(c => "?"));
        using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO {TableName} ({columns}) VALUES ({values})", connection))
        {
            SQLiteTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            foreach (T valuesObj in valuesList)
            {
                foreach (SQLColumn col in Columns)
                {
                    command.Parameters.AddWithValue($"@{col.Name}", col.Field.GetValue(valuesObj));
                }
                command.ExecuteNonQuery();
            }
            transaction.Commit();
        }
    }
    
    public void InsertValues(SQLiteConnection connection, T valuesObj)
    {
        string columns = string.Join(", ", Columns.Select(c => c.Name));
        string values = string.Join(", ", Columns.Select(c => "?"));
        using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO {TableName} ({columns}) VALUES ({values})", connection))
        {
            SQLiteTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            foreach (SQLColumn col in Columns)
            {
                command.Parameters.AddWithValue($"@{col.Name}", col.Field.GetValue(valuesObj));
            }
            command.ExecuteNonQuery();
            transaction.Commit();
        }
    }
}