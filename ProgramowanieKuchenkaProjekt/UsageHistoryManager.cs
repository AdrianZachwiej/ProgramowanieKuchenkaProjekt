using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieKuchenkaProjekt
{
    public class UsageHistoryManager
    {
        public List<string> UsageHistory { get; private set; }

        public UsageHistoryManager()
        {
            UsageHistory = new List<string>();
        }

        public void AddUsage(string usage)
        {
            UsageHistory.Add(usage);
        }

        public void ClearUsageHistory()
        {
            UsageHistory.Clear();
        }

        public void LoadUsageHistory(string filePath)
        {
            if (File.Exists(filePath))
            {
                UsageHistory = new List<string>(File.ReadAllLines(filePath));
            }
        }

        public void SaveUsageHistory(string filePath)
        {
            File.WriteAllLines(filePath, UsageHistory);
        }
    }
}

