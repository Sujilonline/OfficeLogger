using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OfficeLogger;
public class TestApp : MonoBehaviour
{
    private static TestApp instance;
    private void Awake ()
    {
        instance = this;
    }
    public  List<UserAccount> userAccounts;
    public bool isNoLocalAccounts;
    public int lastIndex = 120;
    public static TestApp GetInstance ()
    {
        return instance;
    }
    public UserAccount[] GetUserAccounts ()
    {
        return userAccounts.ToArray();
    }

    public void AddUser (UserAccount newUser)
    {
        if (userAccounts == null)
            userAccounts = new List<UserAccount>();

        userAccounts.Add(newUser);
    }
}
