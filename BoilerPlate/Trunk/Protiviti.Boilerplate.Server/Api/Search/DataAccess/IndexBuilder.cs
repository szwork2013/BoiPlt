using Lucene.Net.Documents;
using Lucene.Net.Index;
using Protiviti.Boilerplate.Server.Api.ApplicationWizard;
using Protiviti.Boilerplate.Server.Api.Initiatives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Search
{
    public class IndexBuilder
    {
        public static void Build(IndexWriter writer)
        {
            writer.DeleteAll();

            Populate(GetPrograms(), writer);
            Populate(GetApplications(), writer);
            Populate(GetInitiatives(), writer);
            Populate(GetInitiativeTasks(), writer);

            writer.Optimize();
            writer.Commit();
            writer.Dispose();
        }

        private static IEnumerable<SearchResult> GetApplications()
        {
            var context = new ApplicationWizardContext();
            var applications = context.Applications.ToList();
            return applications.Select(application =>
                new SearchResult
                {
                    EntityId = application.Id,
                    EntityTypeName = "Applications",
                    SearchTitle = application.Name,
                    SearchBody = application.Name + " " + application.Status
                });
        }

        private static IEnumerable<SearchResult> GetPrograms()
        {
            var context = new ApplicationWizardContext();
            var programs = context.Programs.ToList();
            return programs.Select(program =>
                new SearchResult
                {
                    EntityId = program.Id,
                    EntityTypeName = "Programs",
                    SearchTitle = program.Name,
                    SearchBody = program.Name + " " + program.Location + " " + program.Cost + " " + program.Duration
                });
        }
        private static IEnumerable<SearchResult> GetInitiatives()
        {
            var context = new InitiativeDbContext();
            var initiatives = context.Initiatives.ToList();
            return initiatives.Select(initiative =>
                new SearchResult
                {
                    EntityId = initiative.Id,
                    EntityTypeName = "Initiatives",
                    SearchTitle = initiative.Name,
                    SearchBody = initiative.Name
                });
        }
        private static IEnumerable<SearchResult> GetInitiativeTasks()
        {
            var context = new InitiativeDbContext();
            var initiativeTasks = context.InitiativeTasks.ToList();
            return initiativeTasks.Select(initiativeTask =>
                new SearchResult
                {
                    EntityId = initiativeTask.Id,
                    EntityTypeName = "InitiativeTasks",
                    SearchTitle = initiativeTask.TaskName,
                    SearchBody = initiativeTask.TaskName + " " + initiativeTask.Description
                });
        }

        private static void Populate(IEnumerable<SearchResult> results, IndexWriter writer)
        {
            foreach (var result in results)
            {
                var doc = new Document();
                doc.Add(new Field("EntityId", result.EntityId.ToString(), Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("EntityTypeName", result.EntityTypeName, Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("SearchTitle", result.SearchTitle, Field.Store.YES, Field.Index.NO));
                doc.Add(new Field("SearchBody", result.SearchBody, Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(doc);
                doc = null;
            }
        }
    }
}