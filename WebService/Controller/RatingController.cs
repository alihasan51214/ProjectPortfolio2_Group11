using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private DataServiceFacade _dataService;
        private IMapper _mapper;

        public RatingController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
    }
}