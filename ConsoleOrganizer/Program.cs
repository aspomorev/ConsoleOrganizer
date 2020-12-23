﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);

            MySqlConnection connection = new MySqlConnection("server = localhost; user = root; database = organizerdata; password = 1234");

            List<Group> groups = new List<Group>()
            {
                new Group("Status", "statuses"),
                new Group("Category", "categories"),
                new Group("Criticality", "criticalities")
            };
            Group sort = new Group("Sort", "sort");

            View v = new View();

            v.GroupBy(groups);
            v.SortBy(sort);
            Console.WriteLine(v.sql);

            MTask mt = new MTask(connection);
            mt.GetTasks(v.sql);
            Console.SetWindowSize(150, 40);
            mt.ShowMultiTask();

            Console.ReadKey();
        }
    }
}
