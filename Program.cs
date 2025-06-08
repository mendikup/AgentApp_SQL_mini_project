using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using DataBase;
using SqlAgent.Services;
using SqlAgent.Models;




public class Program
{
    public static void Main(string[] args)
    {

        {
            // Step 1: Create a connection factory with the connection string to the MySQL database
            DbConnectionFactory Connection = new DbConnectionFactory("server=127.0.0.1;user=root;password=;database=eagleeyedb;");

            // Step 2: Create an instance of the service class that handles database operations 
            AgentService agentservice = new AgentService(Connection);

            // // 
            // List<Agent> agents = agentservice.GetAllAgents();

            // foreach (Agent agent in agents)
            // {
            //     agent.ToString();
            // }


            // Agent agent1 = agentservice.GetAgentByID(1);

            // System.Console.WriteLine(agent1.ToString());

            // Agent agent2 = new Agent(4, "Shadow", "Ethan Hunt", "London", "active", 17);



            // agentservice.AddAgent(agent2);

            agentservice.UppdateAgentLocation(1, "Tel Aviv");
            agentservice.DleteAgemt(4);









        }
    }
}