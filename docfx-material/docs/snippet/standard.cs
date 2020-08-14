public class DocumentApiController
{

    public FileStreamResult GetDocumentFromAzureOrMipe1ForRp(Guid id)
    {
        var documentEngine = _BusinessEngineFactory.GetBusinessEngine<IDocumentEngine>();

        var document = documentEngine.GetDocumentFromCloudOrDatabase(id, DocumentTables.Rp);

        var stream = new MemoryStream(document.Content);

        var fileStream = new FileStreamResult(stream, document.ContentType)
        {
            FileDownloadName = document.Filename
        };

        return fileStream;
    }

    people.DataSource = CurrentCompany.Employees.GetList(

    connection, metaClass, GetFilter(), null

    );
}