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
    public class PhieuXuatController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<PhieuXuat> item = PhieuXuatDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] PhieuXuat x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaPX, string NgayXuat, string MaKH, string DiaChi, string MaNV, string MaKho, string GhiChu)
            PhieuXuatDAO.Instance.Create(x.MaPX, x.NgayXuat, x.MaKH, x.DiaChi, x.MaNV, x.MaKho, x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  PhieuXuat x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            PhieuXuatDAO.Instance.Update(x.MaPX, x.NgayXuat, x.MaKH, x.DiaChi, x.MaNV, x.MaKho, x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaPX)
        {
            PhieuXuatDAO.Instance.Delete(MaPX);
            return Ok();
        }

    }
}
