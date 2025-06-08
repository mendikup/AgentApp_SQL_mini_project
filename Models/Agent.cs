namespace SqlAgent.Models
{
    public class Agent
    {
        int Id { get; set; }
        string CodeName { get; set; }
        string RealName { get; set; }
        string Location { get; set; }
        string Status { get; set; }
        int MissionsCompleted { get; set; }


        public Agent(int id, string codeName, string realName, string locatin, string status, int missionsCompleted)
        {
            Id = id;
            CodeName = codeName;
            RealName = realName;
            Location = locatin;
            Status = status;
            MissionsCompleted = missionsCompleted;



        }

        public override string ToString()
        {
            return $"Agent ID: {Id}\n" +
                   $"Code Name: {CodeName}\n" +
                   $"Real Name: {RealName}\n" +
                   $"Location: {Location}\n" +
                   $"Status: {Status}\n" +
                   $"Missions Completed: {MissionsCompleted}\n";
        }

    }


}