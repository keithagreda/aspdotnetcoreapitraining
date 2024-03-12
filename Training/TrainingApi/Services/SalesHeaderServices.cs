using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;
using TrainingApi.ApiResponse;
using TrainingApi.Entities;
using TrainingApi.Models;

namespace TrainingApi.Services
{
    public class SalesHeaderServices : ISalesHeaderServices
    {
        private readonly TrainingDbContext _trainingDbContext;

        public SalesHeaderServices(TrainingDbContext trainingDbContext)
        {
            _trainingDbContext = trainingDbContext;
        }

        public async Task<ApiResponse<string>> CreateHeaderDetails(SalesHeaderDetailsDto input)
        {
            try
            {
                var _salesHeader = new SalesHeader
                {
                    TotalAmount = input.TotalAmount,
                    SalesHeaderid = input.SalesHeaderid,
                };

                var _salesDetailsTemp = await _trainingDbContext.SalesDetailsTemps.Where(x => x.CreatedBy == input.CreatedBy)
                    .Select(x => new SalesDetails
                    {
                        Quantity = x.Quantity,
                        Price = x.Price,
                        CreatedBy = 1,
                        CreatedStamp = DateTime.Now,
                    }).ToListAsync();

                _salesHeader.SalesDetails = _salesDetailsTemp;

                var _salesDeleteTemp = await _trainingDbContext.SalesDetailsTemps.Where(x => x.CreatedBy == input.CreatedBy).ToListAsync();
                _trainingDbContext.SalesDetailsTemps.RemoveRange(_salesDeleteTemp);
                await _trainingDbContext.SalesHeaders.AddAsync(_salesHeader);
                await _trainingDbContext.SaveChangesAsync();

                var res = new ApiResponse<string>
                {
                    Data = "Saved!",
                    isSuccess = true,
                    ErrorMessage = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponse<string>
                {
                    Data = "",
                    isSuccess = true,
                    ErrorMessage = ex.Message
                };
                return res;
            }
        }

        public async Task<string> UpdateHeaderDetails(SalesHeaderDetailsV2Dto input)
        {
            var _salesHeader = await _trainingDbContext.SalesHeaders.FirstOrDefaultAsync(e => e.SalesHeaderid == input.SalesHeaderid);

            _salesHeader.TotalAmount = input.TotalAmount;

            var _salesDetailsTemp = await _trainingDbContext.SalesDetailsTemps.Where(x => x.CreatedBy == input.CreatedBy)
                .Select(x=> new SalesDetails
                {
                    Quantity = x.Quantity,
                    Price = x.Price,
                    CreatedBy = x.CreatedBy,
                    CreatedStamp = x.CreatedStamp,
                    SalesDetailsId = 0,
                    SalesHeaderId = _salesHeader
                })
                .ToListAsync();

            _salesHeader.SalesDetails = _salesDetailsTemp;

            var _salesTempDelete = await _trainingDbContext.SalesDetailsTemps.Where(x => x.CreatedBy == input.CreatedBy).ToListAsync();
            var _salesTempDetails = await _trainingDbContext.SalesDetails.Where(x => x.SalesHeaderId.SalesHeaderid == input.SalesHeaderid).ToListAsync();

            _trainingDbContext.SalesDetailsTemps.RemoveRange(_salesTempDelete);
            _trainingDbContext.SalesDetails.RemoveRange(_salesTempDetails);
            _trainingDbContext.SalesHeaders.Update(_salesHeader);
            await _trainingDbContext.SaveChangesAsync();

            return "updated!";
        }

        public async Task<string> InsertTemp(long salesId, long createdBy)
        {
            var _temp = await _trainingDbContext.SalesDetailsTemps.Where(x => x.CreatedBy == createdBy).ToListAsync();
            var _fromDetails = await _trainingDbContext.SalesDetails.Where(x => x.SalesHeaderId.SalesHeaderid == salesId).ToListAsync();
            var _insert = (from a in _fromDetails
                           select new SalesDetailsTemp
                           {
                               CreatedBy = a.CreatedBy,
                               CreatedStamp = a.CreatedStamp,
                               Price = a.Price,
                               Quantity = a.Quantity,
                               SalesDetailsTempId = 0
                           }).ToList();
            _trainingDbContext.SalesDetailsTemps.RemoveRange(_temp);
            await _trainingDbContext.SalesDetailsTemps.AddRangeAsync(_insert);
            await _trainingDbContext.SaveChangesAsync();
            return "success";
        }


        public async Task<List<SalesHeaderDetailsV2Dto>> GetAllSalesHeaderDetails()
        {
            var _data = await (from a in _trainingDbContext.SalesHeaders
                         join b in _trainingDbContext.SalesDetails on a.SalesHeaderid equals b.SalesHeaderId.SalesHeaderid
                         select new SalesHeaderDetailsV2Dto
                         {
                             SalesHeaderid = a.SalesHeaderid,
                             CreatedBy = a.CreatedBy,
                             Price = b.Price,
                             Quantity = b.Quantity,
                             TotalAmount = a.TotalAmount,
                             CreatedStamp = a.CreatedStamp
                         }).ToListAsync();

            return _data;
        }

        public async Task<string> DeleteHeader(long id)
        {
            var _headerId = await _trainingDbContext.SalesHeaders.FirstOrDefaultAsync(e => e.SalesHeaderid == id);
            _trainingDbContext.Remove(_headerId);
            await _trainingDbContext.SaveChangesAsync();

            return "Success!";
        }

    }
}
