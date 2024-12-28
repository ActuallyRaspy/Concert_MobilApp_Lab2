namespace Todo.MAUI;

public static class Constants
{
    // URL of REST service (Android does not use localhost)
    // Use http cleartext for local deployment. Change to https for production
    // Change "192.168.1.148" to your local computer's IP address
    // if your debug target is a physical android device
    public static string LocalhostUrl =
    DeviceInfo.Platform == DevicePlatform.Android
    ? (DeviceInfo.DeviceType == DeviceType.Physical ? "localhost:" : "localhost:")
    : "localhost";
    public static string Scheme = "https"; // or http
    public static string Port = "44316"; // or 5000
    public static string BaseUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/";

    // URL with dynamic ID for operations like getting by ID or deleting
    public static string ConcertUrl => $"{Scheme}://{LocalhostUrl}:{Port}/api/Concerts/{{0}}";
    public static string BookingUrl => $"{Scheme}://{LocalhostUrl}:{Port}/api/Bookings/{{0}}";
    public static string PerformanceUrl => $"{Scheme}://{LocalhostUrl}:{Port}/api/Performances/{{0}}";

}