using Betgrab.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Betgrab.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BetgrabController : Controller
	{
		public BetgrabContext Ctx { get; set; }

		public BetgrabController()
		{
		}

		
	}
}
