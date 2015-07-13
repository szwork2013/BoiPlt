using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class CdsInitiativeDbInitializer : DropCreateDatabaseIfModelChanges<InitiativeDbContext>
    {
        protected override void Seed(InitiativeDbContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            InitializeInitiativeForEF(context);
            base.Seed(context);
        }

        public static void InitializeInitiativeForEF(InitiativeDbContext context)
        {
            context.Initiatives.AddOrUpdate(
                                        p => p.Id,
                                        new Initiative { Id = 1, Name = "Sales" },
                                        new Initiative { Id = 2, Name = "Onboarding" },
                                        new Initiative { Id = 3, Name = "Knowledge Base" },
                                        new Initiative { Id = 4, Name = "Training and Certifications" }
                                        );

            context.Persons.AddOrUpdate(
                p => p.Id,
                new Person() { Id = 1, FirstName = "Mike", LastName = "Wzorek", Gender = "M", Email = "michael.wzorek@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 2, FirstName = "Doug", LastName = "Sellers", Gender = "M", Email = "doug.sellers@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 3, FirstName = "Stewart", LastName = "Armbrecht", Gender = "M", Email = "stewart.armbrecht@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 4, FirstName = "Ben", LastName = "Bloomfield", Gender = "M", Email = "ben.bloomfield@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 5, FirstName = "Hanna", LastName = "Parker", Gender = "F", Email = "hanna.parker@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 6, FirstName = "Julia", LastName = "Bliss", Gender = "F", Email = "julia.bliss@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 7, FirstName = "Alok", LastName = "Gupta", Gender = "M", Email = "alok.gupta@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 8, FirstName = "Pradeep", LastName = "Katta", Gender = "M", Email = "pradeep.katta@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 9, FirstName = "Shira", LastName = "Hammann", Gender = "F", Email = "shira.hammann@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 10, FirstName = "Chandana", LastName = "Koti", Gender = "M", Email = "chandana.koti@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" },
                new Person() { Id = 11, FirstName = "Ehsan", LastName = "Adra", Gender = "M", Email = "ehsan.adra@protiviti.com", Bio = "", Twitter = "", Blog = "", ImageSource = "" }
            );

            context.InitiativeTasks.AddOrUpdate(

                p => p.Id,
                new InitiativeTask()
                {
                    Id = 1,
                    InitiativeId = 1,
                    ContactId = 1,
                    TaskName = "Find Proposals",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 2,
                    InitiativeId = 1,
                    ContactId = 2,
                    TaskName = "Pitch PSS Value",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 3,
                    InitiativeId = 2,
                    ContactId = 3,
                    TaskName = "Read Employee Manual",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 4,
                    InitiativeId = 2,
                    ContactId = 4,
                    TaskName = "Build Sample App",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 5,
                    InitiativeId = 2,
                    ContactId = 5,
                    TaskName = "Online Training",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 6,
                    InitiativeId = 3,
                    ContactId = 6,
                    TaskName = "Develop Boilerplate Solution",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 7,
                    InitiativeId = 3,
                    ContactId = 7,
                    TaskName = "Research Emerging Technologies",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 8,
                    InitiativeId = 4,
                    ContactId = 8,
                    TaskName = "Collect Team Certs",
                    Description = "Go get that work"
                },
                new InitiativeTask()
                {
                    Id = 9,
                    InitiativeId = 4,
                    ContactId = 9,
                    TaskName = "Identify Relevant Trainings",
                    Description = "Go get that work"
                }
                );
        }
    }
}