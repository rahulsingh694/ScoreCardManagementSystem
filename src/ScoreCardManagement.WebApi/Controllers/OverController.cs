using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Contracts;
using ScoreCardManagement.WebApi.Routes;
using ScoreCardManagement.WebApi.Service.Interface;

namespace ScoreCardManagement.WebApi.Controllers
{
    [ApiController]
    public class OverController : ControllerBase
    {
        public readonly IOverService overService;
        public IMapper mapper;
        public OverController(IOverService _overService,IMapper _mapper)
        {
          overService=_overService;
          mapper=_mapper;
        }

        [HttpPost(ApiRoutes.Over.over)]
        public async Task <IActionResult> CreateOverAsync([FromBody]Over over)
        {
            
            try
            {
            await overService.CreateOverAsync(mapper.Map<Models.Over>(over));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Over.over)]
        public async Task<ActionResult> GetOverAsync(int overId)
        {
        //  throw new Exception("error from player controller");
        try
         {
          var over = await overService.GetOverAsync(overId);
          return Ok(over);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(ApiRoutes.Over.over)]
        public async Task <IActionResult> UpdateOverAsync([FromBody]Over over)
        {
            try
            {
            await overService.UpdateOverAsync(mapper.Map<Models.Over>(over));
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(ApiRoutes.Over.over)]
        public async Task <IActionResult> DeleteOverAsync(int overId)
        {
            try
            {
            await overService.DeleteOverAsync(overId);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Over.allOver)]
        public async Task<ActionResult> GetAllOverAsync([FromQuery] OverFilter? overFilter = null)
        {
            try
              {
                var over =await overService.GetAllOverAsync(overFilter);
                 return Ok(over);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        }
 
    }
}