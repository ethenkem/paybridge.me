using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Users.Dtos;
using PayBridge.Infrastructure.Auth;
using PayBridge.Infrastructure.Data;
using PayBridge.Shared;

namespace PayBridge.Features.Users;

// public class UserService
// {
//     private readonly AppDbContext _db;
//     private readonly JwtTokenService _jwtTokenService;

//     public UserService(AppDbContext db, JwtTokenService jwtTokenService)
//     {
//         this._db = db;
//         this._jwtTokenService = jwtTokenService;
//     }

//     public async Task<ApiResponse<object>> RegisterHandler(RegisterDto data)
//     {
//         var exists = await _db.Users.AnyAsync(x => x.Email == data.Email);
//         if (exists)
//         {
//             return new ApiResponse<object>
//             {
//                 success = false,
//                 message = "User with this email already exists",
//                 data = null,
//             };
//         }
//         var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);
//         var newUser = new User
//         {
//             Email = data.Email,
//             Password = hashedPassword,
//             FullName = data.FullName,
//         };
//         this._db.Users.Add(newUser);
//         await this._db.SaveChangesAsync();
//         return new ApiResponse<object>
//         {
//             success = true,
//             message = "Please verify your account with the code sent to " + data.Email,
//             data = null
//         };
//     }
//     // public async Task<ApiResponse<object>> ObtainTokenHandler(LoginDto data)
//     // {
//     //     var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == data.Email);
//     //     if (user == null)
//     //     {
//     //         return new ApiResponse<object>
//     //         {
//     //             success = false,
//     //             message = "Invalid credentials",
//     //             data = null,
//     //         };
//     //     }
//     //     var isPasswordValid = BCrypt.Net.BCrypt.Verify(data.Password, user.Password);
//     //     if (!isPasswordValid)
//     //     {
//     //         return new ApiResponse<object>
//     //         {
//     //             success = false,
//     //             message = "Invalid credentials",
//     //             data = null,
//     //         };
//     //     }
//     //     var token = _jwtTokenService.CreateToken(user);
//     //     return new ApiResponse<object>
//     //     {
//     //         success = true,
//     //         message = "Token generated successfully",
//     //         data = new { token },
//     //     };

//     // }

// }