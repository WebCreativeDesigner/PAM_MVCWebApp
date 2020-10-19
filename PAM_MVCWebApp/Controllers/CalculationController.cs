using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Web;
using PAM_MVCWebApp.Models;
using System.Collections.Immutable;
using ClosedXML.Excel;
using System.Text;

namespace PAM_MVCWebApp.Controllers
{
    public class CalculationController : Controller
    {
        private List<CalculatedDataModel> CalculatedDateModelList = null;
        private ICalculatedDataRepository repository = null;

        private readonly ILogger<CalculationController> _logger;
        //private static List<CalculatedDataModel> _CalculatedDataList = CreateCalculatedDataList();

        public CalculationController(ILogger<CalculationController> logger, ICalculatedDataRepository _repository)
        {
            _logger = logger;
            this.repository = _repository;
            this.CalculatedDateModelList = new List<CalculatedDataModel>();
        }
        /*
        static decimal Function1_ToCalculateY(decimal m, decimal x, decimal c)
        {
            decimal Y;
            return Y = (m * x) + c;
        }

        static decimal Function3_ToCalculateA(decimal x)
        {
            decimal A;
            return A = 1 / x;
        }

        static decimal Function2_ToCalculateb(decimal A, decimal Y, List<decimal> X)
        {
            decimal B = A + Y;
            decimal b = B / X.Count();
            return b;
        }

        static decimal Function4_ToCalculate_SpecificValue_for_Output_ArrayListC(decimal SpecificValue_of_ArrayListX, decimal b)
        {
            decimal C = SpecificValue_of_ArrayListX + b;
            return C;
        }

        static List<decimal> ReadParamFile(string Path)
        {
            decimal m = 0;
            decimal c = 0;

            try
            {
                List<string> allLinesText = System.IO.File.ReadAllLines(Path).ToList();

                foreach (var line in allLinesText)
                {
                    Console.WriteLine("\t" + "Line is " + line);
                    string Value = line.Substring(4);
                    if (line.Contains("m ="))
                    {
                        m = Convert.ToDecimal(line.Substring(4));
                    }
                    if (line.Contains("c ="))
                    {
                        c = Convert.ToDecimal(line.Substring(4));
                    }
                }

                List<decimal> ListVarsMandC = new List<decimal> { m, c };
                return ListVarsMandC;

                /*
                Console.WriteLine("Value of m is " + m);
                Console.WriteLine("Value of c is " + c);
                
            }
            catch (IOException e)
            {
                Console.WriteLine("The Params file could not be read:");
                Console.WriteLine(e.Message);
                List<decimal> ListVarsMandC = new List<decimal> { m, c };
                return ListVarsMandC;
            }

        }

        static List<decimal> ReadRawDataFile(string DataPath)
        {
            List<string> allLinesText = System.IO.File.ReadAllLines(DataPath).ToList();
            //split the text with the commas
            //decimal mos = 0;
            List<decimal> RawDataListItems = allLinesText[1].Split(',')
                                        .Where(m => decimal.TryParse(m, out _))
                                        .Select(m => decimal.Parse(m))
                                        .ToList();
            Console.WriteLine("The number of items in Raw Data File: " + RawDataListItems.Count());
            return RawDataListItems;
        }

        static List<decimal> Calculate_New_Data_Results(List<decimal> RawDataListX, decimal m, decimal c, string Outputfilepath)
        {
            int RawDataCount = RawDataListX.Count();
            List<decimal> NewDataResults = new List<decimal>();

            for (int i = 0; i < RawDataListX.Count; i++)
            {
                decimal RawDataValueX = RawDataListX[i];

                //static decimal Function1_ToCalculateY(decimal m, decimal x, decimal c)
                decimal Y = Function1_ToCalculateY(m, RawDataValueX, c);
                //static decimal Function3_ToCalculateA(decimal x)
                decimal A = Function3_ToCalculateA(RawDataValueX);
                //static decimal Function2_ToCalculateb(decimal A, decimal Y, List<decimal> X)
                decimal b = Function2_ToCalculateb(A, Y, RawDataListX);
                //static decimal Function4_ToCalculate_SpecificValue_for_Output_ArrayListC(decimal SpecificValue_of_ArrayListX, decimal b)
                decimal C = Function4_ToCalculate_SpecificValue_for_Output_ArrayListC(RawDataValueX, b);

                NewDataResults.Add(C);
            }

            // declare variable before for loop.

            // ExportDataToFile(NewDataResults, Outputfilepath);

            return NewDataResults;
        }
        */
        static void ExportDataToFile(List<decimal> DataList, string OutputFilePath)
        {
            try
            {
                for (int i = 0; i < DataList.Count; i++)
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@OutputFilePath, true))
                    {
                        file.WriteLine(DataList[i]);
                    }
                Console.WriteLine("Number of items calculated was " + DataList.Count() + " and exported to " + OutputFilePath + ".");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
/*
        static List<CalculatedDataModel> CreateCalculatedDataList()
        {
            string ParamPath = "Inputs\\param.txt";
            string ExportDataPath = "Exports\\Results.txt";

            List<decimal> ListVarsMandC;
            ListVarsMandC = ReadParamFile(ParamPath);
            int NoOfItems = ListVarsMandC.Count;
            //Console.WriteLine("Number of items is " + NoOfItems);

            decimal m = ListVarsMandC[0];
            decimal c = ListVarsMandC[1];

            List<decimal> RawDataList = ReadRawDataFile("Inputs\\rawdata.txt");
            List<decimal> CalculatedData = Calculate_New_Data_Results(RawDataList, m, c, ExportDataPath);

            List<CalculatedDataModel> CalculatedDataList = new List<CalculatedDataModel>();

            for (int i = 0; i < RawDataList.Count; i++)
            {
                CalculatedDataModel OutputData1 = new CalculatedDataModel
                {
                    Id = i + 1,
                    RawData = RawDataList[i],
                    c = ListVarsMandC[1],
                    m = ListVarsMandC[0],
                    Calculated = CalculatedData[i]
                };
                CalculatedDataList.Add(OutputData1);

            }

            return CalculatedDataList;

        }
*/
        public IActionResult Index()
        {
            /* List<CalculatedDataModel> CalculatedDataList = new List<CalculatedDataModel>();
         CalculatedDataList = CreateCalculatedDataList; */

            /*var vm = new CalculationDataListViewModel();
            vm.CalculatedDataModel = _CalculatedDataList;
            return View(vm);*/

            // List<CalculatedDataModel> model = (List<CalculatedDataModel>)repository.GetAllCalculatedDataRepository();
            // return View(model.ToList());
            CalculatedDateModelList = (List<CalculatedDataModel>)repository.GetAllCalculatedDataRepository();
            return View(CalculatedDateModelList.ToList());
        }
        
        public IActionResult Excel()
        {
            // this needs the NUGET package ClosedXML installed.
            CalculatedDateModelList = (List<CalculatedDataModel>)repository.GetAllCalculatedDataRepository();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CalculatedDataList");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "RawData";
                worksheet.Cell(currentRow, 3).Value = "c";
                worksheet.Cell(currentRow, 4).Value = "m";
                worksheet.Cell(currentRow, 5).Value = "Calculated";
                foreach (var CalculatedData_ in CalculatedDateModelList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = CalculatedData_.Id;
                    worksheet.Cell(currentRow, 2).Value = CalculatedData_.RawData;
                    worksheet.Cell(currentRow, 3).Value = CalculatedData_.c;
                    worksheet.Cell(currentRow, 4).Value = CalculatedData_.m;
                    worksheet.Cell(currentRow, 5).Value = CalculatedData_.Calculated;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "CalculatedData.xlsx");
                }
            }
        }

        public IActionResult Csv()
        {
            CalculatedDateModelList = (List<CalculatedDataModel>)repository.GetAllCalculatedDataRepository();
            var builder = new StringBuilder();
            builder.AppendLine("Id,RawData,c,m,Calculated");
            foreach (var CalculatedData in CalculatedDateModelList)
            {
                builder.AppendLine($"{CalculatedData.Id},{CalculatedData.RawData},{CalculatedData.c},{CalculatedData.m},{CalculatedData.Calculated}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "CalculatedData.csv");
        }
  
  /*
        public IActionResult Indexworks()
        {
            string ParamPath = "Inputs\\param.txt";
            string ExportDataPath = "Exports\\Results.txt";

            List<decimal> ListVarsMandC;
            ListVarsMandC = ReadParamFile(ParamPath);
            int NoOfItems = ListVarsMandC.Count;
            /*Console.WriteLine("Number of items is " + NoOfItems);*/
        /*
            decimal m = ListVarsMandC[0];
            decimal c = ListVarsMandC[1];

            var vm = new CalculatedListViewModel();
            vm.RawData = ReadRawDataFile("Inputs\\rawdata.txt");
            vm.CalculatedData = Calculate_New_Data_Results(vm.RawData, m, c, ExportDataPath);
            return View(vm);

        }

        public IActionResult Index1()
        {
            List<decimal> RawDataListItems = ReadRawDataFile("Inputs\\rawdata.txt");
            return View(RawDataListItems);
        }
        */
    }
}
