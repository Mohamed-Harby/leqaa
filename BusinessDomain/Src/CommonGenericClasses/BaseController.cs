// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommonGenericClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BusinessLogic.Domain;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;

#nullable disable

    [ApiController, Route("api/[controller]")]

    public abstract class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IBaseUnitOfWork<TEntity> _unitOfWork;

        protected IMapper _mapper;
        protected readonly IValidator<TEntity> _validator;

        public BaseController(IBaseUnitOfWork<TEntity> unitOfWork,
                              IMapper mapper,
                              IValidator<TEntity> validator
                             )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {

            TEntity entity = await _unitOfWork.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
            return Ok(_mapper.Map<TDto>(entity));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            IQueryable<TEntity> entities = await _unitOfWork.ReadAllAsync();
            return Ok(entities.Select(product => _mapper.Map<TDto>(product)));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            TEntity entity = await _unitOfWork.ReadByIdAsync(id);
            TDto entityViewModel = _mapper.Map<TDto>(entity);

            return Ok(entityViewModel);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto entityViewModel)
        {
            TEntity entity = _mapper.Map<TEntity>(entityViewModel);

            ValidationResult results = await _validator.ValidateAsync(entity);
            if (!results.IsValid)
                return BadRequest(results.Errors.Select(e => e.ErrorMessage));

            entity = (await _unitOfWork.CreateAsync(entity)).Value;
            try
            {
                await _unitOfWork.SaveAsync();
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var results = _validator.Validate(entity);
            if (!results.IsValid)
                return BadRequest(results.Errors.Select(e => e.ErrorMessage));
            entity = await _unitOfWork.Update(entity);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<TDto>(dto));
        }
    }
}
