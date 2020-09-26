using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository campRepository ,IMapper mapper)
        {
            _campRepository = campRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CampModel[]>> GETCamps ()
        {
            try
            {
                var result = await _campRepository.GetAllCampsAsync();
                return _mapper.Map<CampModel[]>(result);
            }
            catch(Exception) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure");
            }

        }
    }
}
