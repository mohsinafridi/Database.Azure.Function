using System;
using System.IO;
using System.Linq;
using BlobTriggerFunction.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BlobTriggerFunction
{
    public class Function1
    {
        #region Property
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public Function1(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

       // [FunctionName("TriggerWhenFileUpload")]
        //public void Run([BlobTrigger("hisofiles/{name}", Connection = "")] Stream myBlob, string name, ILogger log)
        //{
           // log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
           //appDbContext.FileRecords.Add(new FileRecords
           //{
           //    FileName = name,
           //    IsCompleted = true
           //});
           //appDbContext.SaveChanges();
        //}

        [FunctionName("SaveStudent")]
        public void InsertData([TimerTrigger("%EveryOneMinutes%")] TimerInfo myTimer, ILogger log)
        {
            var employee = new Student { Name = $"Mohsin -  {DateTime.Now.Minute}", IsActive = true, AddMinutes = DateTime.Now };
            _appDbContext.Students.AddAsync(employee);
            _appDbContext.SaveChangesAsync();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
        [FunctionName("FetchStudents")]
        public void FetchData([TimerTrigger("%Every15Sec%")] TimerInfo myTimer, ILogger log)
        {
            var data = _appDbContext.Students.ToList();
            log.LogInformation($"Total Records Count : {data.Count}");
        }
    }
}
