using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using Bootcamp.Models.SignInPage;
using Bootcamp.Models.ApiResponse;
using System.IdentityModel.Tokens.Jwt;

namespace Bootcamp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public SignInController(IConfiguration configuration)
        {

            this._configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignIn login)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(login);
                    var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{_baseUrl}/api/Authentication/login", requestBody);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                        if (apiResponse.Success)
                        {
                            string token = apiResponse.Data.Token;
                            string fullName = apiResponse.Data.FullName.ToString();
                            string userId = apiResponse.Data.Id;
                            string email = apiResponse.Data.Email;

                            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                            // Decode the JWT token to access its claims, including expiration
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var jwtToken = tokenHandler.ReadJwtToken(token);

                            // Extract the expiration from the JWT token
                            var expiration = jwtToken.ValidTo;
                            var tokenLifetime = (int)(expiration - DateTime.UtcNow).TotalSeconds;
                            var expirationTime = DateTimeOffset.UtcNow.AddSeconds(tokenLifetime);

                            // Save the token in an HttpOnly cookie
                            Response.Cookies.Append("token", token, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict,
                            });


                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, userId),
                                new Claim(ClaimTypes.Name, fullName),
                                new Claim(ClaimTypes.Email, email)
                                // Add other claims as needed
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties
                            {
                                ExpiresUtc = expirationTime
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);

                            TempData["SuccessMessage"] = apiResponse.Message;

                            string returnUrl = TempData["ReturnUrl"] as string;
                            if (returnUrl != null)
                            {
                                return Redirect(string.IsNullOrEmpty(returnUrl) ? "/default" : returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "BreakInto");
                            }
                        }
                        else
                        {
                            TempData["ErrorMessage"] = apiResponse.Message;
                            return RedirectToAction("Index", "User");
                        }
                    }
                    else
                    {
                        // Handle HTTP request error (e.g., display an error message)
                        TempData["ErrorMessage"] = "Invalid Credentials";
                        return RedirectToAction("Index", "User");
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
        }
    }

}
