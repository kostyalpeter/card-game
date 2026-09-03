using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;

public class Console : MonoBehaviour
{
    private Dictionary<string, Action<string[]>> commands = new Dictionary<string, Action<string[]>>();
    public GameObject consoleUI;
    public TMP_InputField inputField;

    // Amounts
    private int healAmount = 0;
    private int GoldAmount = 0;



    void Awake()
    {
        RegisterCommand("heal", Heal);
        RegisterCommand("gold", Gold);
        RegisterCommand("hp", Hp);
    }

    void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            consoleUI.SetActive(true);
            inputField.ActivateInputField();
        }
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            consoleUI.SetActive(false);
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame && consoleUI.activeSelf)
        {
            SubmitCommand();
        }
    }

    public void SubmitCommand()
    {
        if (inputField == null) return;

        string inputText = inputField.text;

        ProcessCommand(inputText);

        inputField.text = "";
        inputField.ActivateInputField();

    }
    void ProcessCommand(string Input)
    {
        if (string.IsNullOrWhiteSpace(Input)) return;

        string[] parts = Input.Split(' ');
        string command = parts[0].ToLower();

        string[] args = new string[parts.Length - 1];
        Array.Copy(parts, 1, args, 0, args.Length);

        if (commands.ContainsKey(command))
        {
            commands[command].Invoke(args);
        }
        else
        {

        }
    }

    private void RegisterCommand(string name, Action<string[]> action)
    {
        commands[name.ToLower()] = action;
    }

    void Heal(string[] args)
    {
        if (args.Length == 0)
        {
            if (healAmount > 0)
            {
                Damaging.PlayerHp += healAmount;
            }
            else
            {

            }
            return;
        }
        if (args.Length == 1)
        {
            if (int.TryParse(args[0], out int Amount))
            {
                healAmount = Amount;
                Damaging.PlayerHp += healAmount;
            }
            else
            {

            }
            return;
        }
        if (args.Length == 2)
        {
            string target = args[0].ToLower();

            if (int.TryParse(args[1], out int amount))
            {
                if (target == "set")
                {
                    healAmount = amount;
                }
                else if (target == "player")
                {
                    Damaging.PlayerHp += amount;
                }
                else if (target == "enemy")
                {
                    Damaging.EnemyHp += amount;
                }
                else
                {

                }
            }
            else
            {

            }
            return;
        }
    }
    void Gold(string[] args)
    {
        if (args.Length == 0)
        {
            if (GoldAmount > 0)
            {
                Shop.Gold += GoldAmount;
            }
            else
            {

            }
            return;
        }
        if (args.Length == 1)
        {
            if (int.TryParse(args[0], out int Amount))
            {
                GoldAmount = Amount;
                Shop.Gold += GoldAmount;
            }
            else
            {

            }
            return;
        }
        if (args.Length == 2)
        {
            string target = args[0].ToLower();

            if (int.TryParse(args[1], out int amount))
            {
                if (target == "set")
                {
                    GoldAmount = amount;
                }
                else if (target == "add")
                {
                    Shop.Gold += amount;
                }
                else if (target == "remove")
                {
                    Shop.Gold -= amount;
                }
                else
                {
                    
                }
            }
            else
            {

            }
            return;
        }
    }
    void Hp(string[] args)
    {
        if (args.Length == 2)
        {
            string subCommand = args[0].ToLower();

            if (subCommand == "set" && int.TryParse(args[1], out int amount))
            {
                Damaging.PlayerHp = amount;
            }
            else if(subCommand == "remove" && int.TryParse(args[1], out int amount2))
            {
                Damaging.PlayerHp -= amount2;
            }
            return;
        }

        if (args.Length == 3)
        {
            string subCommand = args[0].ToLower();
            string target = args[1].ToLower();

            if (subCommand == "set" && int.TryParse(args[2], out int amount))
            {
                if (target == "player")
                {
                    Damaging.PlayerHp = amount;
                }
                else if (target == "enemy")
                {
                    Damaging.EnemyHp = amount;
                }
            }
            if (subCommand == "remove" && int.TryParse(args[2], out int amount2))
            {
                if (target == "player")
                {
                    Damaging.PlayerHp -= amount2;
                }
                else if (target == "enemy")
                {
                    Damaging.EnemyHp -= amount2;
                }
            }
            return;
        }
    }
}