using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scheduling.DTOs.Empresa;
using Scheduling.Models;
using Scheduling.Service.EmpresaService;

namespace Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaInterface _empresaInterface;

        public EmpresaController(IEmpresaInterface empresaInterface)
        {
            _empresaInterface = empresaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmpresaReadDto>>>> GetEmpresas()
        {
            var result = await _empresaInterface.GetEmpresas();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmpresaReadDto>>> CreateEmpresa([FromBody] EmpresaCreateDto dto)
        {
            var result = await _empresaInterface.CreateEmpresa(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmpresaReadDto>>> GetEmpresaById(int id)
        {
            var result = await _empresaInterface.GetEmpresaById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<EmpresaReadDto>>> UpdateEmpresa([FromBody] EmpresaUpdateDto dto)
        {
            var result = await _empresaInterface.UpdateEmpresa(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteEmpresa(int id)
        {
            var result = await _empresaInterface.DeleteEmpresa(id);
            return Ok(result);
        }
    }
}
