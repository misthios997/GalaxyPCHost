using System.IO;

namespace GalaxyPCHost
{
    public static class HostManager
    {
        static string hosts = @"C:\Windows\System32\drivers\etc\hosts";
        static string backup = @"C:\Windows\System32\drivers\etc\hosts.galaxy.bak";

        static string gtps =
@"91.134.85.13 growtopia1.com
91.134.85.13 growtopia2.com
91.134.85.13 www.growtopia1.com
91.134.85.13 www.growtopia2.com";

        public static void Connect()
        {
            if (!File.Exists(backup))
                File.Copy(hosts, backup, true);

            if (!File.ReadAllText(hosts).Contains("growtopia1.com"))
                File.AppendAllText(hosts, "\n" + gtps);
        }

        public static void Disconnect()
        {
            if (File.Exists(backup))
                File.Copy(backup, hosts, true);
        }
    }
}
