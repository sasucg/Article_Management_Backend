using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Article_Management_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DictionaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getArticleCategories")]
        public async Task<List<DictionaryModel>> GetArticleCategoryList(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetArticleCategoryListQueryModel(), cancellationToken);
        }

        [HttpGet]
        [Route("getArticleStatuses")]
        public async Task<List<DictionaryModel>> GetArticleStatusList(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetArticleStatusListQueryModel(), cancellationToken);
        }
    }
}
