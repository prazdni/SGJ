public static class Extensions
{ 
    private static readonly string Boss = "Character/Sequences/Boss";
    private static readonly string Helper = "Character/Sequences/Helper";
    private static readonly string DayZero = "Character/Sequences/ZeroDay";
    private static readonly string DayOne = "Character/Sequences/FirstDay";
    private static readonly string DayTwo = "Character/Sequences/SecondDay";
    private static readonly string DayThree = "Character/Sequences/ThirdDay";
    private static readonly string DayFour = "Character/Sequences/FourthDay";
    private static readonly string DayFive = "Character/Sequences/FifthDay";
    private static readonly string DaySix = "Character/Sequences/SixDay";
    private static readonly string DaySeven = "Character/Sequences/SeventhDay";
    private static readonly string DayEight = "Character/Sequences/EightDay";
    private static readonly string DayNine = "Character/Sequences/NinthDay";
    private static readonly string DayTen = "Character/Sequences/TenthDay";

    public static string Return(int day)
    {
        switch (day)
        {
            case -2:
                return Boss;
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
}