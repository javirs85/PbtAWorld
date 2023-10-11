using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PbtAWorldApp.Controllers;

[Route("/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	[HttpGet("google-login")]
	public async Task<ActionResult> Google()
	{
		var properties = new AuthenticationProperties
		{
			RedirectUri = "/"
		};
		return Challenge(properties, GoogleDefaults.AuthenticationScheme);
	}

	[HttpGet("google-logout")]
	public IActionResult Logout()
	{
		HttpContext.SignOutAsync("Cookie");
		return Redirect("/");
	}
}
