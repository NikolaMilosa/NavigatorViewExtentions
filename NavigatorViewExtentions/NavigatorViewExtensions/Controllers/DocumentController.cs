using Microsoft.AspNetCore.Mvc;
using NavigatorViewExtensions.Services.Testing;

namespace NavigatorViewExtensions.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DocumentService _documentService;

        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        public IActionResult Get(int page = 0)
        {
            return View(_documentService.GetDocuments(page));
        }
    }
}