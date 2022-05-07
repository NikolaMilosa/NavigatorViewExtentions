using System.Collections.Generic;
using System.Data;
using Dapper;
using NavigatorViewExtensions.Services.Connection;

namespace NavigatorViewExtensions.Services.Testing
{
    public class DocumentService
    {
        private readonly IDapper _dapper;
        private static readonly string _query = 
            @"select id_dokument as Id, id_def_dokumenta as DocumentDefinitionId, broj_dokumenta as DocumentNumber, datum as Date, last_update as LastUpdate, dok_status as Status
            from dokument 
            offset @Page * 100
            limit 100";

        public DocumentService(IDapper dapper)
        {
            _dapper = dapper;
        }

        public IEnumerable<DocumentDto> GetDocuments(int page)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", page);
            
            return _dapper.GetAll<DocumentDto>(_query, parameters);
        }
    }
}