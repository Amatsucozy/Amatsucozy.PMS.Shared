using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amatsucozy.PMS.Shared.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class SecuredController : ControllerBase
{
}
