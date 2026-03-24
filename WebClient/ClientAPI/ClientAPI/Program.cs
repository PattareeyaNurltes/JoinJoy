using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DB
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
builder.Services.AddDbContext<JoinJoyDbContext>(options =>
    options.UseNpgsql(connectionString, o =>
    {
        o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    }));

//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer((Action<JwtBearerOptions>)(options =>
    {
        options.Authority = "https://tprtntkrpvumdukryall.supabase.co/auth/v1";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://tprtntkrpvumdukryall.supabase.co/auth/v1",
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var userId = context.Principal.FindFirst("sub")?.Value;

                if (!Guid.TryParse(userId, out var userGuid))
                {
                    return;
                }

                var db = context.HttpContext.RequestServices
                    .GetRequiredService<JoinJoyDbContext>();

                var user = await db.Users.FindAsync(Guid.Parse(userId));

                if (user != null)
                {
                    var identity = context.Principal.Identity as ClaimsIdentity;
                    if (identity == null) return;

                    if (!identity.HasClaim(c => c.Type == ClaimTypes.Role))
                    {
                        foreach (var role in user.Roles)
                        {
                            identity.AddClaim(new Claim(ClaimTypes.Role, role));
                        }
                    }
                }
            }
        };
    }));

//Controller
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
