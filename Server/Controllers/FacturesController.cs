using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturesController : Controller
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;

        public FacturesController(ILogger<FacturesController> logger, IBusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Facture> Get()
        {
            return _data.Factures;
        }

        [HttpGet("{reference}")]
        public ActionResult<Facture> Get([FromRoute] string reference)
        {
            var facture = _data.Factures.Where(fac => fac.reference == reference).FirstOrDefault();
            if (facture != null)
                return facture;
            else
                return NotFound();
        }
    }
}
