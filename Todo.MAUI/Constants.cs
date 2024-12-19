namespace Todo.MAUI;

public static class Constants
{
    // URL of REST service (Android does not use localhost)
    // Use http cleartext for local deployment. Change to https for production
    // Change "192.168.1.148" to your local computer's IP address
    // if your debug target is a physical android device
    public static string LocalhostUrl =
    DeviceInfo.Platform == DevicePlatform.Android
    ? (DeviceInfo.DeviceType == DeviceType.Physical ? "192.168.1.148" : "10.0.2.2")
    : "localhost";
    public static string Scheme = "https"; // or http
    public static string Port = "44316"; // or 5000
    public static string BaseUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/Concerts";

    // URL with dynamic ID for operations like getting by ID or deleting
    public static string RestUrl => $"{Scheme}://{LocalhostUrl}:{Port}/api/Concerts/{{0}}";
}