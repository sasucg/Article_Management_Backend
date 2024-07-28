using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Article_Management_Backend.Models.DTOs.ArticleDTO;
using Article_Management_Backend.Commands;
using Article_Management_Backend.Models.FilterModels.ArticleFilters;

namespace Article_Management_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getArticlesByFilters")]
        public async Task<List<ArticleModel>> GetArticleListByFilters([FromQuery] ArticleListFilterModel filters, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetArticleListFiltersQueryModel(filters), cancellationToken);
        }


        [HttpGet]
        [Route("getArticleDetails")]
        public async Task<ArticleDetailsModel> GetArticleById([FromQuery] Guid articleId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetArticleDetailsQueryModel(articleId), cancellationToken);
        }

        [HttpPost]
        [Route("saveArticle")]
        public async Task<ActionResult<SaveArticleResponse>> SaveArticle(SaveArticleCommand command)
        {
            SaveArticleResponse response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpPut]
        [Route("updateArticle")]
        public async Task<ActionResult<UpdateArticleResponse>> UpdateArticle(UpdateArticleCommand command)
        {
            UpdateArticleResponse response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpDelete]
        [Route("deleteArticle")]
        public async Task<ActionResult<DeleteArticleResponse>> DeleteArticle([FromQuery] DeleteArticleCommand command)
        {
            DeleteArticleResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
