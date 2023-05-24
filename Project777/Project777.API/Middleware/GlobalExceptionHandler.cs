using System;
using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Project777.Shared.Exceptions;

namespace Project777.API.Middleware
{
	public class GlobalExceptionHandler
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandler(RequestDelegate next)
		{
			_next = next;
		}

        public object JSONSerializer { get; private set; }

        public async Task Invoke (HttpContext context)
		{
			try
			{
				await _next(context);

			} catch (Exception ex)
			{
				var res = context.Response;

				res.ContentType = "application/json";

				string errorMessage = string.Empty;

				switch (ex)
				{
                    case NotFoundException e:
						res.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = e.Message;
                        break;
                    case DbUpdateException: res.StatusCode = (int)HttpStatusCode.InternalServerError;
						errorMessage = "Sorry we are not able to complete your request, please try again later!";
						break;
                    case PostgresException: res.StatusCode = (int)HttpStatusCode.InternalServerError;
						errorMessage = "Sorry we are not able to complete your request, please try again later!";
                        break;
					
					default: res.StatusCode = (int)HttpStatusCode.InternalServerError;
						errorMessage = "Sorry your request cannot be completed";
                        break;
				}

				var result = JsonSerializer.Serialize(new { message = errorMessage });

				await res.WriteAsync(result);
			}
		}
	}
}

