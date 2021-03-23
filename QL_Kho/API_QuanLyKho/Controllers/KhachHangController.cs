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
    public class KhachHangController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<KhachHang> item = KhachHangDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] KhachHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaKH, string TenKhachHang, string DiaChi, string SDT, string Email)
            KhachHangDAO.Instance.Create(x.MaKH, x.TenKhachHang, x.DiaChi, x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  KhachHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            KhachHangDAO.Instance.Update(x.MaKH, x.TenKhachHang, x.DiaChi, x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaKH)
        {
            KhachHangDAO.Instance.Delete(MaKH);
            return Ok();
        }

    }
}
