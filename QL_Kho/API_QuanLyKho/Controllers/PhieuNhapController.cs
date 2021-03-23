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
    public class PhieuNhapController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<PhieuNhap> item = PhieuNhapDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] PhieuNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaPN, string NgayNhap,string MaNCC, string DiaChi, string MaNV, string MaKho, string GhiChu)
            PhieuNhapDAO.Instance.Create(x.MaPN, x.NgayNhap, x.MaNCC, x.DiaChi,x.MaNV,x.MaKho,x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  PhieuNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            PhieuNhapDAO.Instance.Update(x.MaPN, x.NgayNhap, x.MaNCC, x.DiaChi, x.MaNV, x.MaKho, x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaPN)
        {
            PhieuNhapDAO.Instance.Delete(MaPN);
            return Ok();
        }

    }
}
