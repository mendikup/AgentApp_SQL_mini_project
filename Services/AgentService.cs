using DataBase;
using SqlAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Data;


namespace SqlAgent.Services
{
    public class AgentService
    {
        private DbConnectionFactory Connection;

        public AgentService(DbConnectionFactory connection)
        {
            Connection = connection;
        }


        public void AddAgent(Agent agent)
        {
            using (var conn = Connection.GetOpenConnection())
            using (var command = new MySqlCommand("INSERT INTO agents(codeName, realName, location, st, missionCompleted) VALUES (@codeName, @realName, @location, @st, @missionCompleted)", conn))
            {
                command.Parameters.AddWithValue("@codeName", agent.CodeName);
                command.Parameters.AddWithValue("@realName", agent.RealName);
                command.Parameters.AddWithValue("@location", agent.Location);
                command.Parameters.AddWithValue("@st", agent.Status);
                command.Parameters.AddWithValue("@missionCompleted", agent.MissionsCompleted);

                command.ExecuteNonQuery();
            }





        }



        public void UppdateAgentLocation(int agentId, string location)
        {
            using (var conn = Connection.GetOpenConnection())
            using (var command = new MySqlCommand("UPDATE agents SET location = @location WHERE id = @id", conn))
            {
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@id", agentId);
                command.ExecuteNonQuery();
            }
        }

        public void DleteAgemt(int agentId)
        {
            using (var conn = Connection.GetOpenConnection())
            using (var command = new MySqlCommand("DELETE FROM agents WHERE id = @id", conn))
            {

                command.Parameters.AddWithValue("@id", agentId);
                command.ExecuteNonQuery();
            }
        }


        public Agent GetAgentByID(int agentid)
        {

            Agent agent = null;
            using (var conn = Connection.GetOpenConnection())
            using (var command = new MySqlCommand($"SELECT * FROM agents WHERE agents.id ={agentid}", conn))
            using (var reader = command.ExecuteReader())

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string codeName = reader.GetString("codeName");
                    string realName = reader.GetString("realName");
                    string location = reader.GetString("location");
                    string status = reader.GetString("st");
                    int missionsCompleted = reader.GetInt32("missionCompleted");


                    agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                    return agent;




                }
            return agent;

        }





        public List<Agent> GetAllAgents()
        {
            var agents = new List<Agent>();

            try
            {
                using (var conn = Connection.GetOpenConnection())
                using (var command = new MySqlCommand("SELECT * FROM agents", conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string codeName = reader.GetString("codeName");
                        string realName = reader.GetString("realName");
                        string location = reader.GetString("location");
                        string status = reader.GetString("st");
                        int missionsCompleted = reader.GetInt32("missionCompleted");


                        var agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                        agents.Add(agent);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error while uploading data from-DB:");
                Console.WriteLine(ex.Message);

            }

            return agents;
        }
    }
}
