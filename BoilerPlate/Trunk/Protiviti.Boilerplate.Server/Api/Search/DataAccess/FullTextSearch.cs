using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Search
{
    public class FullTextSearch
    {
        public static ICollection<SearchResult> Execute(string query)
        {
            ICollection<SearchResult> searchResults = new List<SearchResult>();

            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\LuceneIndexes";
            var directory = FSDirectory.Open(directoryPath);
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "SearchBody", analyzer);
            Query searchQuery = parser.Parse(query + "*");

            IndexSearcher searcher = new IndexSearcher(directory);
            TopDocs hits = searcher.Search(searchQuery, 200);
            int results = hits.ScoreDocs.Length;
            for (int i = 0; i < results; i++)
            {
                Document doc = searcher.Doc(hits.ScoreDocs[i].Doc);
                var searchResult = new SearchResult();
                searchResult.EntityId = int.Parse(doc.Get("EntityId"));
                searchResult.EntityTypeName = doc.Get("EntityTypeName");
                searchResult.SearchTitle = doc.Get("SearchTitle");
                searchResult.SearchBody = doc.Get("SearchBody");
                searchResults.Add(searchResult);
            }
            searcher.Dispose();
            directory.Dispose();

            return searchResults;
        }
    }
}