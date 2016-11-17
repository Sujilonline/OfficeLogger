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
    public  List<UserAccount_temp> userAccounts;
    public bool isNoLocalAccounts;
    public int lastIndex = 120;
    public static TestApp GetInstance ()
    {
        return instance;
    }
    public UserAccount_temp[] GetUserAccounts ()
    {
        return userAccounts.ToArray();
    }

    public void AddUser (UserAccount_temp newUser)
    {
        if (userAccounts == null)
            userAccounts = new List<UserAccount_temp>();

        userAccounts.Add(newUser);
    }
}
