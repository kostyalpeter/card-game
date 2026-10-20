using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Console : MonoBehaviour
{
    private Dictionary<string, Action<string[]>> commands =
        new Dictionary<string, Action<string[]>>();

    [Header("UI Elements")]
    public GameObject consoleUI;
    public TMP_InputField inputField;
    public TMP_Text logText;

    private List<string> commandHistory = new List<string>();
    private int historyIndex = -1;

    [Header("Amounts")]
    private int healAmount = 0;
    private int GoldAmount = 0;
    public static bool console = true;

    void Awake()
    {
        RegisterCommand("heal", Heal);
        RegisterCommand("gold", Gold);
        RegisterCommand("hp", Hp);
        RegisterCommand("console", Commands);
        RegisterCommand("time", Timer);
        RegisterCommand("game", Fix);
    }

    void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame && console)
        {
            consoleUI.SetActive(true);
            inputField.ActivateInputField();
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            consoleUI.SetActive(false);
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame && consoleUI.activeSelf && console)
        {
            SubmitCommand();
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && consoleUI.activeSelf && console)
        {
            NavigateHistory(1);
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame && consoleUI.activeSelf && console)
        {
            NavigateHistory(-1);
        }
        if (!console)
        {
            consoleUI.SetActive(false);
        }
    }

    public void LogToConsole(string message)
    {
        if (logText != null)
        {
            logText.text += "\n" + message;
        }
    }

    private void NavigateHistory(int direction)
    {
        if (commandHistory.Count == 0)
            return;

        historyIndex -= direction;
        historyIndex = Mathf.Clamp(historyIndex, 0, commandHistory.Count - 1);

        inputField.text = commandHistory[historyIndex];
        inputField.caretPosition = inputField.text.Length;
    }

    public void SubmitCommand()
    {
        if (inputField == null || string.IsNullOrWhiteSpace(inputField.text))
            return;

        string inputText = inputField.text;

        commandHistory.Add(inputText);
        historyIndex = commandHistory.Count;

        ProcessCommand(inputText);

        inputField.text = "";
        inputField.ActivateInputField();
    }

    void ProcessCommand(string Input)
    {
        if (string.IsNullOrWhiteSpace(Input))
            return;

        string[] parts = Input.Split(' ');
        string command = parts[0].ToLower();

        string[] args = new string[parts.Length - 1];
        Array.Copy(parts, 1, args, 0, args.Length);

        if (commands.ContainsKey(command))
        {
            commands[command].Invoke(args);
        }
        else { }
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
                LogToConsole(
                    $"Player healed by {healAmount} points. Current PlayerHp: {Damaging.PlayerHp}"
                );
            }
            else
            {
                LogToConsole("");
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
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
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
                    LogToConsole(
                        "Unknown argument or wrong letter case. Use full lower case letters."
                    );
                }
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
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
                LogToConsole(
                    $"Gold amount raised by {GoldAmount}. Current Gold Amount {Shop.Gold}"
                );
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
            }
            return;
        }
        if (args.Length == 1)
        {
            if (int.TryParse(args[0], out int Amount))
            {
                GoldAmount = Amount;
                Shop.Gold = GoldAmount;
                LogToConsole($"Gold amount set to {GoldAmount}. Current Gold Amount {Shop.Gold}");
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
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
                    Shop.Gold = GoldAmount;
                    LogToConsole(
                        $"Gold amount set to {GoldAmount}. Current Gold Amount {Shop.Gold}"
                    );
                }
                else if (target == "add")
                {
                    Shop.Gold += amount;
                    LogToConsole(
                        $"Gold amount raised by {GoldAmount}. Current Gold Amount {Shop.Gold}"
                    );
                }
                else if (target == "remove")
                {
                    Shop.Gold -= amount;
                    LogToConsole(
                        $"Gold amount lowered by {GoldAmount}. Current Gold Amount {Shop.Gold}"
                    );
                }
                else
                {
                    LogToConsole(
                        "Unknown argument or wrong letter case. Use full lower case letters."
                    );
                }
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
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
                LogToConsole($"PlayerHp raised by {amount}. Current Hp {Damaging.PlayerHp}");
            }
            else if (subCommand == "remove" && int.TryParse(args[1], out int amount2))
            {
                Damaging.PlayerHp -= amount2;
                LogToConsole($"PlayerHp lowered by {amount2}. Current Hp {Damaging.PlayerHp}");
            }
            else if (subCommand == "add" && int.TryParse(args[1], out int amount3))
            {
                Damaging.PlayerHp += amount3;
                LogToConsole($"PlayerHp raised by {amount3}. Current Hp {Damaging.PlayerHp}");
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
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
                    LogToConsole($"PlayerHp set to {amount}. Current Hp {Damaging.PlayerHp}");
                }
                else if (target == "enemy")
                {
                    Damaging.EnemyHp = amount;
                    LogToConsole($"EnemyHp set to {amount}. Current Hp {Damaging.EnemyHp}");
                }
            }
            if (subCommand == "remove" && int.TryParse(args[2], out int amount2))
            {
                if (target == "player")
                {
                    Damaging.PlayerHp -= amount2;
                    LogToConsole($"PlayerHp lowered by {amount2}. Current Hp {Damaging.PlayerHp}");
                }
                else if (target == "enemy")
                {
                    Damaging.EnemyHp -= amount2;
                    LogToConsole($"EnemyHp lowered by {amount2}. Current Hp {Damaging.EnemyHp}");
                }
                else
                {
                    LogToConsole(
                        "Unknown argument or wrong letter case. Use full lower case letters."
                    );
                }
            }
            return;
        }
    }

    void Commands(string[] args)
    {
        if (args.Length == 1)
        {
            if (args[0] == "off")
            {
                console = false;
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
            }
            return;
        }
        else
        {
            LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
        }
    }
    void Fix(string[] args)
    {
        if (args.Length == 1)
        {
            if (args[0] == "fix")
            {
                DoubleClick.CoolDown = false;
                DoubleClick.Countdown = false;
                DoubleClick.canPlay = true;
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
            }
            return;
        }
        else
        {
            LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
        }
    }

    void Timer(string[] args)
    {
        if (args.Length == 1)
        {
            if (args[0] == "stop")
            {
                Time.canTime = false;
                LogToConsole("Timer stopped!");
            }
            else if (args[0] == "unstop")
            {
                Time.canTime = true;
                LogToConsole("Timer unstopped!");
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
            }
            return;
        }

        if (args.Length == 2)
        {
            string subCommand = args[0].ToLower();

            if (subCommand == "set" && int.TryParse(args[1], out int amount))
            {
                Time.Timer = amount;
                LogToConsole($"Timer updated! Set to {amount} seconds");
            }
            else if (subCommand == "add" && int.TryParse(args[1], out int amount2))
            {
                Time.Timer += amount2;
                LogToConsole($"Timer updated! Plus {amount2} seconds");
            }
            else if (subCommand == "remove" && int.TryParse(args[1], out int amount3))
            {
                Time.Timer -= amount3;
                LogToConsole($"Timer updated! Minus {amount3} seconds");
            }
            else if (subCommand == "speed" && float.TryParse(args[1], out float amount4))
            {
                Time.speed = amount4;
            }
            else
            {
                LogToConsole("Unknown argument or wrong letter case. Use full lower case letters.");
            }
            return;
        }
    }
}
