using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Search
{
    public class SearchInitializer
    {
        public static void Initialize()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\LuceneIndexes";
            var directory = FSDirectory.Open(directoryPath);
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            IndexBuilder.Build(writer);
            directory.Dispose();
        }
    }
}