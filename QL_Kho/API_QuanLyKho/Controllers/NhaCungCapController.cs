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
    public class NhaCungCapController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<NhaCungCap> item = NhaCungCapDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] NhaCungCap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaNCC, string TenNCC, string DiaChi, string SDT, string Email)
            NhaCungCapDAO.Instance.Create(x.MaNCC, x.TenNCC, x.DiaChi, x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  NhaCungCap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            NhaCungCapDAO.Instance.Update(x.MaNCC, x.TenNCC, x.DiaChi, x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaNCC)
        {
            NhaCungCapDAO.Instance.Delete(MaNCC);
            return Ok();
        }

    }
}
