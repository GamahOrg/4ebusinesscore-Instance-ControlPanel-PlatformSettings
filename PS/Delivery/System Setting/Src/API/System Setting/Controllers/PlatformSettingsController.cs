

using Newtonsoft.Json;
using PlatformSettings.Application.DTOs;
using PlatformSettings.Application.Features.MainSettings.Query.GetAllMainSettings;
using PlatformSettings.Application.Features.MainSettings.Query.GetMainSettingsInfoLogin;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using SystemSetting.Features.MainSettings.Command.DeleteMainSettingHeaders;
using SystemSetting.Features.MainSettings.Command.DeleteMainSettingLogin;
using SystemSetting.Features.MainSettings.Command.PutMainSettingHeaders;
using SystemSetting.Features.MainSettings.Command.PutMainSettingLogin;
using SystemSetting.Features.MainSettings.Command.PutMainSettingsIsThem;
using SystemSetting.Helpers.Paginations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace System_Setting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlatformSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlatformSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region PostPlatformSettings
        [HttpPost]
        [Route("PostPlatformSettings")]
        public async Task<ResponseDTO> PostPlatformSettings([FromForm] MainSettingsCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region PutPlatformSettings
        [HttpPut]
        [Route("PutPlatformSettings")]
        public async Task<ResponseDTO> PutPlatformSettings([FromForm] PutMainSettingsCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut]
        [Route("PutMainSettingHeaders")]
        public async Task<ResponseDTO> PutMainSettingHeaders(PutMainSettingHeadersCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        [Route("DeleteMainSettingHeaders/{id}")]
        public async Task<ResponseDTO> DeleteMainSettingHeaders(Guid id)
        {
            return await _mediator.Send(new DeleteMainSettingHeadersCommand { Id = id});
        }
        [HttpPut]
        [Route("PutMainSettingLogin")]

        public async Task<ResponseDTO> PutMainSettingLogin([FromForm] MainSettingBasicLoginDto basicLogin, [FromForm] string jsonString, [FromForm] IFormFileCollection? files)
        {
            var login = JsonConvert.DeserializeObject<List<MainSettingLoginDto>>(jsonString);
            
            if (files.Any())
            {
                login.ForEach(x =>
                {
                    x.ImageFile = files.Any(n=>n.FileName == x.FileName) == true ? files.FirstOrDefault(n => n.FileName == x.FileName) : null;
                });
            }

            var command = new PutMainSettingLoginCommand
            {
                MainSettingBasicLogin = basicLogin,
                MainSettingLogins = login
            };

            return await _mediator.Send(command);
        }
        [HttpDelete]
        [Route("DeleteMainSettingLogin/{id}")]
        public async Task<ResponseDTO> DeleteMainSettingLogin(Guid id)
        {
            return await _mediator.Send(new DeleteMainSettingLoginCommand { Id = id });
        }
        [HttpPut]
        [Route("PutMainSettingsIsThem")]
        public async Task<ResponseDTO> PutMainSettingsIsThem(PutMainSettingsIsThemCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region GetPlatformSettingsMainInfo
        [HttpGet]
        [Route("GetPlatformSettingsMainInfo")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetPlatformSettingsMainInfo([FromQuery] Guid? subSystemId = null)
        {
            return await _mediator.Send(new GetMainSettingsInfoQuery(){SubSystemId = subSystemId});
        }
 
        [HttpGet]
        [Route("GetInfoToLogin")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetInfoToLogin([FromQuery] Guid? subSystemId = null)
        {
            return await _mediator.Send(new GetMainSettingsInfoLoginQuery() { SubSystemId = subSystemId });
        }
        [HttpGet]
        [Route("GetAllMainSettings")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetAllMainSettings(string? searhTerm, int pagesize, int pagenumber)
        {
            return await _mediator.Send(new GetAllMainSettingsQuery() {
                SearchTerm = searhTerm,
                PaginatedInputModel = new PaginatedInputModel
                {
                    PageNumber = pagenumber,
                    PageSize = pagesize
                }
            });
        }
        #endregion

        #region GetPlatformSettingssDepartment
        [HttpGet]
        [Route("GetPlatformSettingssDepartment")]
        public async Task<ResponseDTO> GetPlatformSettingssDepartment(int pageIndex, int pageSize)
        {
            return await _mediator.Send(new MainSettingsDepartmentQuery()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
        }
        #endregion

        #region PostPlatformSettingsSites
        [HttpPost]
        [Route("PostPlatformSettingsSites")]
        public async Task<ResponseDTO> PostPlatformSettingsSites(PostMainSettingsSitesCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region PutPlatformSettingsSites
        [HttpPut]
        [Route("PutPlatformSettingsSites")]
        public async Task<ResponseDTO> PutPlatformSettingsSites(PutMainSettingsSitesCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region DeletePlatformSettingsSites
        [HttpDelete]
        [Route("DeletePlatformSettingsSites/{id}")]
        public async Task<ResponseDTO> DeletePlatformSettingsSites(Guid id)
        {
            return await _mediator.Send(new DeleteMainSettingsSitesCommand() { Id = id });
        }
        #endregion

        #region GetPlatformSettingsSites
        [HttpGet]
        [Route("GetPlatformSettingsSites")]
        public async Task<ResponseDTO> GetPlatformSettingsSites(int pageIndex, int pageSize)
        {
            return await _mediator.Send(new GetMainSettingsSitesQuery()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
        }
        #endregion

        #region PostPlatformSettingsDepartmentItems
        [HttpPost]
        [Route("PostPlatformSettingsDepartmentItems")]
        public async Task<ResponseDTO> PostPlatformSettingsDepartmentItems(PostMainSettingsDeptItemsCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region PostPlatformSettingsDepartmentIcons
        [HttpPost]
        [Route("PostPlatformSettingsDepartmentIcons")]
        public async Task<ResponseDTO> PostPlatformSettingsDepartmentIcons(PostMainSettDeptsIconsCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

     
    }
}
