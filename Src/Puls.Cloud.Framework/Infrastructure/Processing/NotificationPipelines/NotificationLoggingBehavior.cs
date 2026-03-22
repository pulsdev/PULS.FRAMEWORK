using System;
using System.Threading;
using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Events;
using Puls.Cloud.Framework.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Puls.Cloud.Framework.Infrastructure.Processing.NotificationPipelines;

internal class NotificationLoggingBehavior<T, TResult> : IPipelineBehavior<T, TResult>
	where T : IDomainNotificationRequest
{
	private readonly ILogger _logger;

	public NotificationLoggingBehavior(ILogger logger)
	{
		_logger = logger;
	}

	public async Task<TResult> Handle(T request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
	{
		_logger.LogInformation("{requestName} is processing: {environment}{request}",
			request.GetType().Name,
			Environment.NewLine,
			JsonConvert.SerializeObject(request, Formatting.Indented)
		);
		try
		{
			TResult result = await next();
			if (typeof(TResult) != typeof(Unit))
			{
				_logger.LogInformation("Result: {environment}{result}",
					Environment.NewLine,
					result);
			}
			return result;
		}
		catch (EntityAlreadyExistsException ex)
		{
			_logger.LogError(ex.ToString());
			throw;
		}
		catch (EntityNotFoundException ex)
		{
			_logger.LogError(ex.ToString());
			throw;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex.ToString());
			throw;
		}
		finally
		{
			_logger.LogInformation($"request {request.GetType().Name} is processed.");
		}
	}
}