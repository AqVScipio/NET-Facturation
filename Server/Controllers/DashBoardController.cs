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
    [Route("api/overview")]
    public class DashBoardController : Controller
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;

        public DashBoardController(ILogger<FacturesController> logger, IBusinessData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public Overview Get()
        {
            return new Overview(_data.Factures);
        }
    }
}
