using System;
using Configs;

public static class Extensions
{
    private static readonly string EndGameDialogue = "Character/Dialogues/EndGameDialogue";
    private static readonly string ToolsTop = "Character/Sequences/Ending/ToolsTop";
    private static readonly string ToolsBottom = "Character/Sequences/Ending/ToolsBottom";
    private static readonly string AwardsTop = "Character/Sequences/Ending/AwardsTop";
    private static readonly string AwardsBottom = "Character/Sequences/Ending/AwardsBottom";
    private static readonly string SafetyTop = "Character/Sequences/Ending/SafetyTop";
    private static readonly string SafetyBottom = "Character/Sequences/Ending/SafetyBottom";
    private static readonly string MoneyTop = "Character/Sequences/Ending/MoneyTop";
    private static readonly string MoneyBottom = "Character/Sequences/Ending/MoneyBottom";
    private static readonly string Dialogue = "Character/Dialogues/Dialogue";
    private static readonly string EndGameCharacter = "Character/Sequences/EndGameCharacter";
    private static readonly string MorningCharacter = "Character/Sequences/MorningCharacter";
    private static readonly string NightCharacter = "Character/Sequences/NightCharacter";
    private static readonly string Helper = "Character/Sequences/Helper";
    private static readonly string DayZero = "Character/Sequences/ZeroDay";
    private static readonly string DayOne = "Character/Sequences/FirstDay";
    private static readonly string DayTwo = "Character/Sequences/SecondDay";
    private static readonly string DayThree = "Character/Sequences/ThirdDay";
    private static readonly string DayFour = "Character/Sequences/FourthDay";
    private static readonly string DayFive = "Character/Sequences/FifthDay";
    private static readonly string DaySix = "Character/Sequences/SixthDay";
    private static readonly string DaySeven = "Character/Sequences/SeventhDay";
    private static readonly string DayEight = "Character/Sequences/EightDay";
    private static readonly string DayNine = "Character/Sequences/NinthDay";
    private static readonly string DayTen = "Character/Sequences/TenthDay";

    public static string Return(int day)
    {
        switch (day)
        {
            case -5:
                return EndGameDialogue;
            case -4:
                return EndGameCharacter;
            case -3:
                return MorningCharacter;
            case -2:
                return NightCharacter;
            case -1:
                return Helper;
            case 0:
                return DayZero;
            case 1:
                return DayOne;
            case 2:
                return DayTwo;
            case 3:
                return DayThree;
            case 4:
                return DayFour;
            case 5:
                return DayFive;
            case 6:
                return DaySix;
            case 7:
                return DaySeven;
            case 8:
                return DayEight;
            case 9:
                return DayNine;
            case 10:
                return DayTen;
            default:
                return "";
        }
    }

    public static string Return(InfluenceType influenceType)
    {
        switch (influenceType)
        {
            case InfluenceType.None:
                return "";
            case InfluenceType.Money:
                return "";
            case InfluenceType.Safety:
                return "";
            case InfluenceType.Awards:
                return "";
            case InfluenceType.Tools:
                return "";
            case InfluenceType.Agent:
                return "";
            case InfluenceType.NightCharacter:
                return "";
            case InfluenceType.MorningCharacter:
                return "";
            case InfluenceType.EndGame:
                return "";
            case InfluenceType.Dialogue:
                return Dialogue;
            case InfluenceType.EndDialogue:
                return "";
            default:
                throw new ArgumentOutOfRangeException(nameof(influenceType), influenceType, null);
        }
    }

    public static string Return(InfluenceType influenceType, bool isBottom)
    {
        switch (influenceType)
        {
            case InfluenceType.Money:
                if (isBottom)
                {
                    return MoneyBottom;
                }
                else
                {
                    return MoneyTop;
                }
            case InfluenceType.Safety:
                if (isBottom)
                {
                    return SafetyBottom;
                }
                else
                {
                    return SafetyTop;
                }
            case InfluenceType.Awards:
                if (isBottom)
                {
                    return AwardsBottom;
                }
                else
                {
                    return AwardsTop;
                }
            case InfluenceType.Tools:
                if (isBottom)
                {
                    return ToolsBottom;
                }
                else
                {
                    return ToolsTop;
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(influenceType), influenceType, null);
        }
    }
}