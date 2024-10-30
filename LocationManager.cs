public class LocationManager
{
    public static Dictionary<string, bool> InvestigatedLocations = new Dictionary<string, bool>()
    {
        {"rug", false},
        {"crowbar", false},
        {"chessboard", false},
        {"mirror", false},
        {"painting", false},
        {"window", false},
        {"coat", false},
        {"wardrobe", false},
        {"table", false},
    };

    public static void Investigated(string location)
    {
        if (InvestigatedLocations.ContainsKey(location))
        {
            InvestigatedLocations[location] = true;
        }
    }
}
