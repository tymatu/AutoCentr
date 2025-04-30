using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using AutoCentr.Model;
using Newtonsoft.Json;

namespace AutoCentr.DataBase;

public static class JsonDataReader
{
    private static string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\DataBase\\";
    public static List<User> ReadUsers()
    {
        List<User> users = new List<User>();
        var filePath = Path.Combine(currentDirectory, "Users.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<User>>(json);
        }

        return users;
    }

    public static User? GetUser(string username, string password)
    {
        var list = ReadUsers();
        return list.Find(u => u.Username == username && u.Password == password);
    }
    public static List<Zakaznik> ReadZakazniky()
    {
        List<Zakaznik> zakazniky = new List<Zakaznik>();
        var filePath = Path.Combine(currentDirectory, "Zakazniky.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            zakazniky = JsonConvert.DeserializeObject<List<Zakaznik>>(json);
        }

        return zakazniky;
    }
    public static List<Oprava> ReadOpravy()
    {
        List<Oprava> opravy = new List<Oprava>();
        var filePath = Path.Combine(currentDirectory, "Opravy.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            opravy = JsonConvert.DeserializeObject<List<Oprava>>(json);
        }

        return opravy;
    }
    public static List<Zakaznik> ReadZakaznikByPracovnikId(string id)
    {
        List<Zakaznik> zakazniky = new List<Zakaznik>();
        var filePath = Path.Combine(currentDirectory, "Zakazniky.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            zakazniky = JsonConvert.DeserializeObject<List<Zakaznik>>(json);
        }

        return zakazniky.Where(m => m.IdPracovnik == id).ToList();
    }
    public static List<Pracovnik> ReadPracovniky()
    {
        List<Pracovnik> pracovniky = new List<Pracovnik>();
        var filePath = Path.Combine(currentDirectory, "Pracovniky.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            pracovniky = JsonConvert.DeserializeObject<List<Pracovnik>>(json);
        }

        return pracovniky;
    }

    public static void SaveZakazniky(List<Zakaznik> list)
    {
        var filePath = Path.Combine(currentDirectory, "Zakazniky.json");
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static void SaveOpravy(List<Oprava> list)
    {
        var filePath = Path.Combine(currentDirectory, "Opravy.json");
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    public static void SavePracovnikyAndUsers(List<Pracovnik> list, List<User> users)
    {
        var filePath = Path.Combine(currentDirectory, "Pracovniky.json");
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);

        List<User> usrs = ReadUsers();
        foreach (var v in users)
        {
            usrs.Add(v);
        }
        var filePath1 = Path.Combine(currentDirectory, "Users.json");
        string json1 = JsonConvert.SerializeObject(usrs, Formatting.Indented);
        File.WriteAllText(filePath1, json1);
    }
    public static void SaveProfile(List<Pracovnik> list, List<User> users)
    {
        var filePath = Path.Combine(currentDirectory, "Pracovniky.json"); string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);

        var filePath1 = Path.Combine(currentDirectory, "Users.json");
        string json1 = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath1, json1);
    }
}
