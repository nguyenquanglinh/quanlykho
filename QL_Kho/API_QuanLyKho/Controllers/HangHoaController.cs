using DataSource.DAO;
using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyKho.Controllers
{
    public class HangHoaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<HangHoa> item = HangHoaDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] HangHoa x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaHH, string TenHangHoa, string MoTa, string DVT, string MaNH, string MaNCC, string GiaVon, string NgayCapNhat)
            HangHoaDAO.Instance.Create(x.MaHH, x.TenHangHoa, x.MoTa, x.DVT, x.MaNH, x.MaNCC, x.GiaVon, x.NgayCapNhat);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  HangHoa x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            HangHoaDAO.Instance.Update(x.MaHH, x.TenHangHoa, x.MoTa, x.DVT, x.MaNH, x.MaNCC, x.GiaVon, x.NgayCapNhat);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaHH)
        {
            HangHoaDAO.Instance.Delete(MaHH);
            return Ok();
        }

    }
}
