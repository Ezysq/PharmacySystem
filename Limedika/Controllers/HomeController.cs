using System.Diagnostics;
using System.Dynamic;
using Limedika.Data;
using Limedika.Http;
using Limedika.Models;
using Microsoft.AspNetCore.Mvc;

namespace Limedika.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ClientsDbContext _context;

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, ClientsDbContext context, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {
            var allClients = _context.Clients.ToList();
            return View(allClients);
        }
        public IActionResult CreateEditClient(Client? model)
        {
            return View(model);
        }
        public IActionResult CreateEditClientForm(Client model)
        {
            Client existingClient = _context.Find<Client>(model.Name);
            if (existingClient != null)
            {
                existingClient.Address = model.Address;
                existingClient.PostCode = model.PostCode;
                _context.ClientsLogs.Add(new ClientLog(model.Name, "Client record updated"));
            }
            else
            {
                _context.Clients.Add(model);
                _context.SaveChanges();
                 _context.ClientsLogs.Add(new ClientLog(model.Name, "New client record created"));
            }
            _context.SaveChanges();
            return RedirectToAction("Clients");
        }
        public IActionResult ImportClientsJson()
        {
            return View();
        }
        public IActionResult ImportClientsFunc(IFormFile json)
        {
            if (json.Length == 0)
            {
                ViewBag.Message = "File is empty!";
                return RedirectToAction("ImportClientsJson");
            }
            ImportClients importClients = new ImportClients(json);
            
            if(importClients.SaveJson(_context))
                return RedirectToAction("Clients");
            return RedirectToAction("ImportClientsJson");
        }

        public IActionResult UpdatePostalIndexes()
        {
            PostService postService = new PostService(_httpClientFactory.CreateClient("PostItClient"));
            postService.UpdatePostalCodes(_context);
            return RedirectToAction("Clients");
        }

        public IActionResult ClientLogs(Client client)
        {
            dynamic myModel = new ExpandoObject();
            myModel.Client = client;
            myModel.ClientLogs = _context.ClientsLogs.Where(x => x.Name == client.Name).ToList();

            return View(myModel);
        }
        public IActionResult RemoveClient(Client client)
        {
            var clientLogs = _context.ClientsLogs.Where(cl => cl.Name == client.Name).ToList();
            _context.ClientsLogs.RemoveRange(clientLogs);
            _context.Remove(client);
            _context.SaveChanges();

            return RedirectToAction("Clients");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
