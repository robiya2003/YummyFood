﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using YummyFood.Application.UseCases.Promo.Commands;
using YummyFood.Application.UseCases.Promo.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePromo(CreatePromoCommand command,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPromo(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetAllPromoCommandQuery(), cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }
       
        [HttpPut]
        public async Task<IActionResult> UpdatePromo(UpdatePromoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePromo(int id,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new DeletePromoCommand() { Id = id }, cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
    }
}
